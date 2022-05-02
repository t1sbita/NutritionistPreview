using NutritionistPreview.Api.Core.Domain.Entities;

namespace NutritionistPreview.Api.Models.ViewModels
{
    public class AppointmentViewModel : BaseViewModel
    {
        public DateTime? DatePerformed { get; set; }
        public double Weight { get; set; }
        public double BodyFatPercent { get; set; }
        public string PhysicalSensation { get; set; }
        public string FoodRestrictions { get; set; }
        public long ClientId { get; set; }  

    }
}
