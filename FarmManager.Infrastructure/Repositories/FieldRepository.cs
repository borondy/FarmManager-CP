using FarmManager.Domain.Entities;
using FarmManager.Domain.Repositories;
using FarmManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FarmManager.Infrastructure.Repositories
{
    public class FieldRepository : IFieldRepository
    {
        private readonly FarmManagerDbContext _context;

        public FieldRepository(FarmManagerDbContext context)
        {
            _context = context;
        }

        public async Task<Field> GetByIdAsync(int id)
        {
            return await _context.Fields
                .Include(f => f.CropRotationPlan)
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<IEnumerable<Field>> GetAllAsync()
        {
            return await _context.Fields
                .Include(f => f.CropRotationPlan)
                .ToListAsync();
        }

        public async Task<Field> AddAsync(Field field)
        {
            _context.Fields.Add(field);
            await _context.SaveChangesAsync();
            return field;
        }

        public async Task UpdateAsync(Field field)
        {
            _context.Entry(field).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var field = await _context.Fields.FindAsync(id);
            if (field != null)
            {
                _context.Fields.Remove(field);
                await _context.SaveChangesAsync();
            }
        }
    }
}
