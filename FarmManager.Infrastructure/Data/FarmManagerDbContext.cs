using FarmManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FarmManager.Infrastructure.Data
{
    public class FarmManagerDbContext : DbContext
    {
        public FarmManagerDbContext(DbContextOptions<FarmManagerDbContext> options)
            : base(options)
        {
        }

        public DbSet<Field> Fields { get; set; }
        public DbSet<CropType> CropTypes { get; set; }
        public DbSet<CropRotationPlan> CropRotationPlans { get; set; }
        public DbSet<MonthPeriod> MonthPeriods { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Field>()
                .HasOne(f => f.CropRotationPlan)
                .WithOne(c => c.Field)
                .HasForeignKey<CropRotationPlan>(c => c.FieldId);

            modelBuilder.Entity<CropType>()
                .HasMany(c => c.SeedingPeriods)
                .WithOne();
        }
    }
}
