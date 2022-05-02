using NutritionistPreview.Api.Core.Domain.Entities.Base;

namespace NutritionistPreview.Api.Core.Domain.Entities
{
    public class Client : BaseEntity
    {
        public string Name { get; set; }
        public long DocumentNumber { get; set; }
        public Address Address { get; set; }
        public long AddressId { get; set; }
        public long? TelephoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public List<Appointment> Appointments { get; set; }

    }
}
