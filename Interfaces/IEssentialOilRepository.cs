using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using api.Dtos;
namespace api.Interfaces
{
    public interface IEssentialOilRepository
    {
        Task<List<EssentialOil>> GetAllAsync();
        Task<EssentialOil> GetByIdAsync(int id);
        Task<EssentialOil> CreateAsync(EssentialOil essentialOil);
        Task<EssentialOil> UpdateAsync(int id, UpdateEssentialOilRequestDto essentialOil);
        Task<bool> DeleteAsync(int id);

    }
}