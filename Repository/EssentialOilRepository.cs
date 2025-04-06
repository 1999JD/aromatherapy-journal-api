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
            var essentialOils = await _context.EssentialOils.ToListAsync();
            return essentialOils;
        }

        public async Task<EssentialOil> GetByIdAsync(int id)
        {
            return await _context.EssentialOils.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<EssentialOil> CreateAsync(EssentialOil essentialOilModel)
        {
            await _context.EssentialOils.AddAsync(essentialOilModel);
            await _context.SaveChangesAsync();
            return essentialOilModel;
        }
        public async Task<EssentialOil> UpdateAsync(int id, UpdateEssentialOilRequestDto essentialOilDto)
        {
            var exisingEssentialOil = await _context.EssentialOils.FirstOrDefaultAsync(x => x.Id == id);
            if (exisingEssentialOil == null)
            {
                return null;
            }

            exisingEssentialOil.Note = essentialOilDto.Note;
            exisingEssentialOil.Tags = essentialOilDto.Tags;
            exisingEssentialOil.PersonalTags = essentialOilDto.PersonalTags;

            await _context.SaveChangesAsync();
            return exisingEssentialOil;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var exisingEssentialOil = await _context.EssentialOils.FirstOrDefaultAsync(x => x.Id == id);
            if (exisingEssentialOil == null)
            {
                return false;
            }
            _context.EssentialOils.Remove(exisingEssentialOil);
            await _context.SaveChangesAsync();
            return true;
        }




    }
}