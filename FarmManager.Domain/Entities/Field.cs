namespace FarmManager.Domain.Entities
{
    public class Field
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double AreaInHectares { get; set; }
        public CropRotationPlan CropRotationPlan { get; set; } 
    }
}
