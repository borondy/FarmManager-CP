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

            modelBuilder.Entity<Field>().HasData(
                new Field { Id = 1, Name = "95", AreaInHectares = 14.7 },
                new Field { Id = 2, Name = "96", AreaInHectares = 4.8 },
                new Field { Id = 3, Name = "97", AreaInHectares = 2.3 },
                new Field { Id = 4, Name = "102", AreaInHectares = 1.4 },
                new Field { Id = 5, Name = "103", AreaInHectares = 3.6 },
                new Field { Id = 6, Name = "106", AreaInHectares = 2.9 },
                new Field { Id = 7, Name = "169", AreaInHectares = 8.9 },
                new Field { Id = 8, Name = "196", AreaInHectares = 2.1 },
                new Field { Id = 9, Name = "Kaszáló", AreaInHectares = 11.82 },
                new Field { Id = 10, Name = "10236", AreaInHectares = 7.9 },
                new Field { Id = 11, Name = "199", AreaInHectares = 5.15 },
                new Field { Id = 12, Name = "201", AreaInHectares = 8.46 },
                new Field { Id = 13, Name = "207", AreaInHectares = 6.82 }
            );
        }
    }
}
