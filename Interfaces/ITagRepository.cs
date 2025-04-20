using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using api.Dtos;

namespace api.Interfaces
{
    public interface ITagRepository
    {

        Task<List<Tag>> GetAllAsync();
        Task<Tag> GetByIdAsync(int id);
        Task<Tag> CreateAsync(Tag tag);
        Task<Tag> UpdateAsync(int id, UpdateTagRequestDto tag);
        Task<bool> DeleteAsync(int id);

    }
}