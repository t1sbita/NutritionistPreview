using NutritionistPreview.Api.Core.Domain.Entities.Base;

namespace NutritionistPreview.Api.Core.Domain.Entities
{
    public class Client : BaseEntity
    {
        public string Name { get; set; }
        public Address Address { get; set; }
        public int TelephoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public List<Appointment> Appointments { get; set; }

    }
}
