using System.Collections.Generic;
using System.Threading.Tasks;
using FarmManager.Domain.Entities;

namespace FarmManager.Domain.Repositories
{
    public interface IFieldRepository
    {
        Task<Field> GetByIdAsync(int id);
        Task<IEnumerable<Field>> GetAllAsync();
        Task<Field> AddAsync(Field field);
        Task UpdateAsync(Field field);
        Task DeleteAsync(int id);
    }
}
