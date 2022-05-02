using NutritionistPreview.Api.Core.Domain.Entities;

namespace NutritionistPreview.Api.Models.ViewModels
{
    public class ClientViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public long DocumentNumber { get; set; }
        public AddressViewModel Address { get; set; }
        public long? TelephoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public List<AppointmentViewModel> Appointments { get; set; }

    }
}
