using NutritionistPreview.Api.Core.Domain.Entities.Base;

namespace NutritionistPreview.Api.Core.Domain.Entities
{
    public class Appointment : BaseEntity
    {
        public DateTime DatePeformed { get; set; }
        public double Weight { get; set; }
        public double BodyFatPercent { get; set; }
        public string PhysicalSensation { get; set; }
        public List<string> FoodRestrictions { get; set; }
    }
}
