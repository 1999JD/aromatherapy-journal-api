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
        public async Task<List<EssentialOil>> GetAllAsync()
        {
            var essentialOils = await _context.EssentialOils
                .Include(e => e.Tags)
                .ThenInclude(et => et.Tag)
                .ToListAsync();
            return essentialOils;
        }

        public async Task<EssentialOil> GetByIdAsync(int id)
        {
            var essentialOil = await _context.EssentialOils
                .Include(e => e.Tags)
                .ThenInclude(et => et.Tag)
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
                .FirstAsync(e => e.Id == essentialOilModel.Id);
        }
        public async Task<EssentialOil> UpdateAsync(int id, UpdateEssentialOilRequestDto essentialOilDto)
        {
            var existingEssentialOil = await _context.EssentialOils.Include(e => e.Tags)
                .ThenInclude(et => et.Tag).FirstOrDefaultAsync(x => x.Id == id);
            if (existingEssentialOil == null)
            {
                throw new KeyNotFoundException($"Essential oil with ID {id} not found.");
            }

            existingEssentialOil.Note = essentialOilDto.Note;
            existingEssentialOil.Tags = essentialOilDto.Tags
                .Select(tagId => new EssentialOilTag { TagId = tagId, EssentialOilId = existingEssentialOil.Id })
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

