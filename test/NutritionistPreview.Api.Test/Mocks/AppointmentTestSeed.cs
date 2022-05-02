using NutritionistPreview.Api.Core.Domain.Entities;
using NutritionistPreview.Api.Core.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionistPreview.Api.Test.Mocks
{
    public static class AppointmentTestSeed
    {
        public static Appointment GetAppointment()
        {
            return new Appointment()
            {
                ClientId = 10,
                Id = 5,
                BodyFatPercent = 12.5,
                DatePerformed = DateTime.Now.Date,
                PhysicalSensation = "Fat",
                FoodRestrictions = "potato and fried foods",
                Weight = 95,
            };
        }

        public static Appointment GetNewAppointment()
        {
            return new Appointment()
            {
                ClientId = 10,
                Id = 0,
                BodyFatPercent = 12.5,
                DatePerformed = DateTime.Now.Date,
                PhysicalSensation = "Fat",
                FoodRestrictions = "potato and fried foods",
                Weight = 95,
            };
        }

        public static List<Appointment> GetListAppointments()
        {
            return new List<Appointment>()
            {
                new Appointment()
                {
                    ClientId = 10,
                    Id = 0,
                    BodyFatPercent = 12.5,
                    DatePerformed = DateTime.Now.Date,
                    PhysicalSensation = "Fat",
                    FoodRestrictions = "potato and fried foods",
                    Weight = 95,
                }
            };
        }

        public static List<Appointment> GetListEmptyAppointments()
        {
            return new List<Appointment>();
        }

        public static PageConsultation<Appointment> GetSearchPaged(int page, int itemsByPage)
        {
            return new PageConsultation<Appointment>
            {
                NumberPage = page,
                SizePage = itemsByPage,
                TotalPages = page,
                TotalRecords = GetListAppointments().Count,
                List = GetListAppointments()
            };
        }
    }
}
