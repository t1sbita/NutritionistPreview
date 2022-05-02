using NutritionistPreview.Api.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionistPreview.Api.Test.Mocks
{
    public static class ClientTestSeed
    {
        public static Client GetClientDb()
        {
            return new Client()
            {
                Id = 10,
                Name = "NomeDoCliente",
                DocumentNumber = 123456,
                Address = AddressTestSeed.GetAddress(),
                TelephoneNumber = 7192345675,
                Email = "em@il",
                BirthDate = DateTime.Now.Date,
                Appointments = AppointmentTestSeed.GetListAppointments()
            };
        }

        public static Client GetNewClient()
        {
            return new Client()
            {
                Id = 0,
                Name = "NomeDoCliente",
                DocumentNumber = 123456,
                Address = AddressTestSeed.GetAddress(),
                TelephoneNumber = 7192345675,
                Email = "em@il",
                BirthDate = DateTime.Now.Date,
                Appointments = AppointmentTestSeed.GetListEmptyAppointments()
            };
        }

        public static List<Client> GetListClient()
        {
            return new List<Client>()
            {
                new Client()
                {
                    Id = 10,
                    Name = "NomeDoCliente",
                    DocumentNumber = 123456,
                    Address = AddressTestSeed.GetAddress(),
                    TelephoneNumber = 7192345675,
                    Email = "em@il",
                    BirthDate = DateTime.Now.Date,
                    Appointments = AppointmentTestSeed.GetListAppointments()
                }
            };
        }
    }
}
