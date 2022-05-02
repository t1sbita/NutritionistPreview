using NutritionistPreview.Api.Core.Domain.Entities;
using NutritionistPreview.Api.Core.Util;
using NutritionistPreview.Api.Models.ViewModels;

namespace NutritionistPreview.Api.Extension
{
    public static class MountViewModels
    {
        public static ClientViewModel MountClientViewModel(Client client)
        {
            return new ClientViewModel()
            {
                Id = Convert.ToInt64(client?.Id),
                Name = client?.Name,
                DocumentNumber = Convert.ToInt64(client?.DocumentNumber),
                Address = MountAddressViewModel(client?.Address),
                TelephoneNumber = client?.TelephoneNumber,
                Email = client?.Email,
                BirthDate = client?.BirthDate,
                Appointments = MountAppointmentViewModelList(client?.Appointments)
            };
        }
        public static AddressViewModel MountAddressViewModel(Address address)
        {
            if (address == null)
                return new AddressViewModel();

            return new AddressViewModel()
            {
                Id = Convert.ToInt64(address?.Id),
                DescriptionAddress = address?.DescriptionAddress,
                Number = address?.Number,
                ZipCode = address?.ZipCode,
                City = address?.City,
                State = address?.State
            };
        }

        public static List<AppointmentViewModel> MountAppointmentViewModelList(List<Appointment> appointments)
        {
            List<AppointmentViewModel> result = new();

            if (appointments == null)
                return result;

            foreach (Appointment appointment in appointments)
            {
                result.Add(MountAppointmentViewModel(appointment));
            }
            return result;
        }

        public static AppointmentViewModel MountAppointmentViewModel(Appointment appointment)
        {
            return new AppointmentViewModel()
            {
                Id = Convert.ToInt64(appointment?.Id),
                ClientId = Convert.ToInt64(appointment?.ClientId),
                BodyFatPercent = Convert.ToInt64(appointment?.BodyFatPercent),
                DatePerformed = appointment?.DatePerformed,
                PhysicalSensation = appointment?.PhysicalSensation,
                FoodRestrictions = appointment?.FoodRestrictions,
                Weight = Convert.ToInt64(appointment?.Weight),
            };
        }

        public static PageConsultation<AppointmentViewModel> MountPageConsultation(PageConsultation<Appointment> pageConsultation)
        {
            List<AppointmentViewModel> list = new();

            foreach (var item in pageConsultation.List)
            {
                list.Add(MountAppointmentViewModel(item));
            }

            return new PageConsultation<AppointmentViewModel>()
            {
                List = list,
                TotalRecords = list.Count,
                NumberPage = pageConsultation.NumberPage,
                SizePage = pageConsultation.SizePage,
                TotalPages = pageConsultation.TotalPages,
            };

        }
    }
}
