
using NutritionistPreview.Api.Core.Domain.Entities;

namespace NutritionistPreview.Api.Core.Domain.Dto
{
    public class Diet
    {
        public Diet()
        {
            Foods = new List<Food>();
        }

        public int TotalCaloricAmount { get; set; }
        public List<Food> Foods { get; set; }
    }
}
