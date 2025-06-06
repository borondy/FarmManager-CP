using System.Collections.Generic;
using System.Threading.Tasks;
using FarmManager.Core.DTOs;
using FarmManager.Domain.Entities;

namespace FarmManager.Core.Interfaces
{
    public interface IFieldService
    {
        Task<IEnumerable<Field>> GetFieldsAsync();
        Task<Field> GetFieldByIdAsync(int id);
        Task<Field> CreateFieldAsync(CreateFieldDto createFieldDto);
        Task UpdateFieldAsync(int id, Field field);
        Task DeleteFieldAsync(int id);
    }
}
