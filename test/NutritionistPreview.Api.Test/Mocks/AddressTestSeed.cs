using NutritionistPreview.Api.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionistPreview.Api.Test.Mocks
{
    public static class AddressTestSeed
    {
        public static Address GetAddress()
        {
            return new Address()
            {
                Id = 11,
                DescriptionAddress = "Address Incomplete",
                Number = "12-A",
                ZipCode = 14323456,
                City = "City",
                State = "State"
            };
        }


    }
}
