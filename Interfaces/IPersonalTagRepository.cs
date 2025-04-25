using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using api.Dtos;

namespace api.Interfaces
{
    public interface IPersonalTagRepository
    {
        Task<List<PersonalTag>> GetAllAsync();
        Task<PersonalTag> GetByIdAsync(int id);
        Task<PersonalTag> CreateAsync(PersonalTag personalTag);
        Task<PersonalTag> UpdateAsync(int id, UpdatePersonalTagRequestDto personalTag);
        Task<bool> DeleteAsync(int id);
    }
}