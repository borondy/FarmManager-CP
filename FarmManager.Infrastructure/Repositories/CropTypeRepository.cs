using FarmManager.Domain.Entities;
using FarmManager.Domain.Repositories;
using FarmManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmManager.Infrastructure.Repositories
{
    public class CropTypeRepository : ICropTypeRepository
    {
        private readonly FarmManagerDbContext _context;

        public CropTypeRepository(FarmManagerDbContext context)
        {
            _context = context;
        }

        public async Task<CropType> GetByIdAsync(int id)
        {
            return await _context.CropTypes
                .Include(c => c.SeedingPeriods)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<CropType>> GetAllAsync()
        {
            return await _context.CropTypes
                .Include(c => c.SeedingPeriods)
                .ToListAsync();
        }

        public async Task<CropType> AddAsync(CropType cropType)
        {
            _context.CropTypes.Add(cropType);
            await _context.SaveChangesAsync();
            return cropType;
        }

        public async Task UpdateAsync(CropType cropType)
        {
            _context.Entry(cropType).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var cropType = await _context.CropTypes.FindAsync(id);
            if (cropType != null)
            {
                _context.CropTypes.Remove(cropType);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<CropType>> GetBySeedingMonthAsync(int month)
        {
            return await _context.CropTypes
                .Include(c => c.SeedingPeriods)
                .Where(c => c.SeedingPeriods.Any(p => 
                    p.PeriodStartingMonth <= month && p.PeriodEndingMonth >= month))
                .ToListAsync();
        }
    }
}
