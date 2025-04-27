using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class EssentialOilRepository : IEssentialOilRepository
    {
        private readonly ApplicationDbContext _context;
        public EssentialOilRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<EssentialOil>> GetAllAsync(string userId)
        {
            var essentialOils = _context.EssentialOils
                .Include(e => e.Tags)
                    .ThenInclude(et => et.Tag)
                .Include(e => e.PersonalTags.Where(et => et.PersonalTag.AppUserId == userId)) // 🎯
                    .ThenInclude(et => et.PersonalTag)
                .AsQueryable();
            return await essentialOils.ToListAsync();
        }

        public async Task<EssentialOil> GetByIdAsync(int id)
        {
            var essentialOil = await _context.EssentialOils
                .Include(e => e.Tags)
                .ThenInclude(et => et.Tag)
                .Include(e => e.PersonalTags)
                .ThenInclude(et => et.PersonalTag)
                .FirstOrDefaultAsync(x => x.Id == id);

            return essentialOil ?? throw new InvalidOperationException($"Essential oil with ID {id} not found.");
        }

        public async Task<EssentialOil> CreateAsync(EssentialOil essentialOilModel)
        {
            await _context.EssentialOils.AddAsync(essentialOilModel);
            await _context.SaveChangesAsync();
            return await _context.EssentialOils
                .Include(e => e.Tags)
                .ThenInclude(et => et.Tag)
                .Include(e => e.PersonalTags)
                .ThenInclude(et => et.PersonalTag)
                .FirstAsync(e => e.Id == essentialOilModel.Id);
        }
        public async Task<EssentialOil> UpdateAsync(int id, UpdateEssentialOilRequestDto essentialOilDto, string userId)
        {
            var existingEssentialOil = await _context.EssentialOils.Include(e => e.Tags)
                .ThenInclude(et => et.Tag).Include(e => e.PersonalTags)
                .ThenInclude(et => et.PersonalTag).FirstOrDefaultAsync(x => x.Id == id);
            if (existingEssentialOil == null)
            {
                throw new KeyNotFoundException($"Essential oil with ID {id} not found.");
            }

            existingEssentialOil.Note = essentialOilDto.Note;
            existingEssentialOil.Tags = essentialOilDto.Tags
                .Select(tagId => new EssentialOilTag { TagId = tagId, EssentialOilId = existingEssentialOil.Id })
                .ToList();

            // (2) 驗證 PersonalTags
            var validPersonalTagIds = await _context.PersonalTags
                .Where(pt => essentialOilDto.PersonalTags.Contains(pt.Id) && pt.AppUserId == userId)
                .Select(pt => pt.Id)
                .ToListAsync();

            if (validPersonalTagIds.Count != essentialOilDto.PersonalTags.Count)
            {
                throw new UnauthorizedAccessException("Some PersonalTagIds do not belong to the current user.");
            }

            existingEssentialOil.PersonalTags = essentialOilDto.PersonalTags
                .Select(personalTagId => new EssentialOilPersonalTag { PersonalTagId = personalTagId, EssentialOilId = existingEssentialOil.Id })
                .ToList();
            await _context.SaveChangesAsync();
            return existingEssentialOil;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existingEssentialOil = await _context.EssentialOils.FirstOrDefaultAsync(x => x.Id == id);
            if (existingEssentialOil == null)
            {
                return false;
            }
            _context.EssentialOils.Remove(existingEssentialOil);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

