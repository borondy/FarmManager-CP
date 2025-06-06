using System.Collections.Generic;
using System.Threading.Tasks;
using FarmManager.Core.DTOs;
using FarmManager.Core.Interfaces;
using FarmManager.Domain.Entities;
using FarmManager.Domain.Repositories;

namespace FarmManager.Core.Services
{
    public class FieldService : IFieldService
    {
        private readonly IFieldRepository _fieldRepository;

        public FieldService(IFieldRepository fieldRepository)
        {
            _fieldRepository = fieldRepository;
        }

        public async Task<IEnumerable<Field>> GetFieldsAsync()
        {
            return await _fieldRepository.GetAllAsync();
        }

        public async Task<Field> GetFieldByIdAsync(int id)
        {
            return await _fieldRepository.GetByIdAsync(id);
        }

        public async Task<Field> CreateFieldAsync(CreateFieldDto createFieldDto)
        {
            var field = new Field
            {
                Name = createFieldDto.Name,
                AreaInHectares = createFieldDto.AreaInHectares
            };

            return await _fieldRepository.AddAsync(field);
        }

        public async Task UpdateFieldAsync(int id, Field field)
        {
            if (id != field.Id)
            {
                throw new System.ArgumentException("Id mismatch between parameter and entity", nameof(id));
            }

            await _fieldRepository.UpdateAsync(field);
        }

        public async Task DeleteFieldAsync(int id)
        {
            await _fieldRepository.DeleteAsync(id);
        }
    }
}
