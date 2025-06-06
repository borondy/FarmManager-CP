using System.Collections.Generic;
using System.Threading.Tasks;
using FarmManager.Domain.Entities;

namespace FarmManager.Domain.Repositories
{
    public interface ICropTypeRepository
    {
        Task<CropType> GetByIdAsync(int id);
        Task<IEnumerable<CropType>> GetAllAsync();
        Task<CropType> AddAsync(CropType cropType);
        Task UpdateAsync(CropType cropType);
        Task DeleteAsync(int id);
        Task<IEnumerable<CropType>> GetBySeedingMonthAsync(int month);
    }
}
