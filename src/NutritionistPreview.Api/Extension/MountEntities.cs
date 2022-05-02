using NutritionistPreview.Api.Core.Domain.Entities;
using NutritionistPreview.Api.Models.ViewModels;

namespace NutritionistPreview.Api.Extension
{
    public static class MountEntities
    {
        public static Client MountClient(ClientViewModel client)
        {
            return new Client()
            {
                Id = client.Id,
                Name = client.Name,
                DocumentNumber = client.DocumentNumber,
                Address = MountAddress(client.Address),
                TelephoneNumber = client.TelephoneNumber,
                Email = client.Email,
                BirthDate = client.BirthDate,
                Appointments = MountAppointmentList(client.Appointments)
            };
        }
        public static Address MountAddress(AddressViewModel address)
        {
            return new Address()
            {
                Id = address.Id,
                DescriptionAddress = address.DescriptionAddress,
                Number = address.Number,
                ZipCode = address.ZipCode,
                City = address.City,
                State = address.State
            };
        }
        
        public static List<Appointment> MountAppointmentList(List<AppointmentViewModel> appointments)
        {
            List<Appointment> result = new();

            if (appointments == null)
                return result;

            foreach (AppointmentViewModel appointment in appointments)
            {
                result.Add(MountAppointment(appointment));
            }
            return result;
        }

        public static Appointment MountAppointment(AppointmentViewModel appointment)
        {
            return new Appointment()
            {
                ClientId = appointment.ClientId,
                Id = appointment.Id,
                BodyFatPercent = appointment.BodyFatPercent,
                DatePerformed = appointment?.DatePerformed,
                PhysicalSensation = appointment?.PhysicalSensation,
                FoodRestrictions = appointment?.FoodRestrictions,
                Weight = appointment.Weight,
            };
        }

    }
}
