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
    public class PersonalTagRepository : IPersonalTagRepository
    {
        private readonly ApplicationDbContext _context;
        public PersonalTagRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<PersonalTag>> GetAllAsync()
        {
            var personalTags = _context.PersonalTags.Include(a => a.AppUser).AsQueryable();
            return await personalTags.ToListAsync();
        }

        public async Task<PersonalTag> GetByIdAsync(int id)
        {
            var personalTag = await _context.PersonalTags.FirstOrDefaultAsync(x => x.Id == id);
            return personalTag;
        }

        public async Task<PersonalTag> CreateAsync(PersonalTag personalTagModel)
        {
            await _context.PersonalTags.AddAsync(personalTagModel);
            await _context.SaveChangesAsync();
            return personalTagModel;
        }
        public async Task<PersonalTag> UpdateAsync(int id, UpdatePersonalTagRequestDto personalTagDto)
        {
            var exisingPersonalTag = await _context.PersonalTags.FirstOrDefaultAsync(x => x.Id == id);
            if (exisingPersonalTag == null)
            {
                return null;
            }
            exisingPersonalTag.Name = personalTagDto.Name;
            await _context.SaveChangesAsync();
            return exisingPersonalTag;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var exisingPersonalTag = await _context.PersonalTags.FirstOrDefaultAsync(x => x.Id == id);
            if (exisingPersonalTag == null)
            {
                return false;
            }
            _context.PersonalTags.Remove(exisingPersonalTag);
            await _context.SaveChangesAsync();
            return true;
        }



    }
}