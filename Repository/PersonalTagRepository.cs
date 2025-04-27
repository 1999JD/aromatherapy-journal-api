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

        public async Task<List<PersonalTag>> GetAllAsync(string userId)
        {

            var personalTags = _context.PersonalTags
                .Include(a => a.AppUser).Where(b => b.AppUser.Id == userId).ToListAsync();
            return await personalTags;
        }

        public async Task<PersonalTag> GetByIdAsync(int id, string userId)
        {
            var personalTag = await _context.PersonalTags.Include(a => a.AppUser).Where(b => b.AppUser.Id == userId).FirstOrDefaultAsync(x => x.Id == id);
            return personalTag;
        }

        public async Task<PersonalTag> CreateAsync(PersonalTag personalTagModel)
        {
            await _context.PersonalTags.AddAsync(personalTagModel);
            await _context.SaveChangesAsync();
            return personalTagModel;
        }
        public async Task<PersonalTag> UpdateAsync(int id, UpdatePersonalTagRequestDto personalTagDto, string userId)
        {

            var exisingPersonalTag = await _context.PersonalTags.FirstOrDefaultAsync(x => x.Id == id);
            if (exisingPersonalTag == null)
            {
                return null;
            }
            if (exisingPersonalTag.AppUserId != userId)
            {
                return null;
            }
            exisingPersonalTag.Name = personalTagDto.Name;
            await _context.SaveChangesAsync();
            return exisingPersonalTag;
        }

        public async Task<bool> DeleteAsync(int id, string userId)
        {
            var exisingPersonalTag = await _context.PersonalTags.FirstOrDefaultAsync(x => x.Id == id);
            if (exisingPersonalTag == null)
            {
                return false;
            }
            if (exisingPersonalTag.AppUserId != userId)
            {
                return false;
            }
            _context.PersonalTags.Remove(exisingPersonalTag);
            await _context.SaveChangesAsync();
            return true;
        }



    }
}