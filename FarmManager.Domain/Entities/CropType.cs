using System.Collections.Generic;

namespace FarmManager.Domain.Entities;

public class CropType
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<MonthPeriod> SeedingPeriods { get; set; } = new List<MonthPeriod>();
    public MonthPeriod HarvestingPeriod { get; set; }
}