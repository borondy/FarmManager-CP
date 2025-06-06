using System.Collections.Generic;

namespace FarmManager.Domain.Entities
{
    public class CropRotationPlan
    {
        public int Id { get; set; }
        public int FieldId { get; set; }
        public Field Field { get; set; }
        public List<CropType> PlannedCrops { get; set; } = new List<CropType>();
    }
}
