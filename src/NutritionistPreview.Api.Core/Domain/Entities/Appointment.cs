using NutritionistPreview.Api.Core.Domain.Entities.Base;

namespace NutritionistPreview.Api.Core.Domain.Entities
{
    public class Appointment : BaseEntity
    {
        public DateTime? DatePerformed { get; set; }
        public double Weight { get; set; }
        public double BodyFatPercent { get; set; }
        public string PhysicalSensation { get; set; }
        public string FoodRestrictions { get; set; }
        public Client Client { get; set; }
        public long ClientId { get; set; }
    }
}
