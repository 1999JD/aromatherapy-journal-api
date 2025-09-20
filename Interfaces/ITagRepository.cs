using System.Threading.Tasks;
using api.Models;
using api.Dtos;
using api.Helpers;

namespace api.Interfaces
{
    public interface ITagRepository
    {
        Task<PagedResult<Tag>> GetAllAsync(int pageNumber, int pageSize);
        Task<Tag> GetByIdAsync(int id);
        Task<Tag> CreateAsync(Tag tag);
        Task<Tag> UpdateAsync(int id, UpdateTagRequestDto tag);
        Task<bool> DeleteAsync(int id);
    }
}
