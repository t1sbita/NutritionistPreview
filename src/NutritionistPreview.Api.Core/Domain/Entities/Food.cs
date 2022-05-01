using NutritionistPreview.Api.Core.Domain.Entities.Base;

namespace NutritionistPreview.Api.Core.Domain.Entities
{
    public class Food : BaseEntity
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public double CaloricAmount { get; set; }
    }
}
