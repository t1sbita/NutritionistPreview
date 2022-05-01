using NutritionistPreview.Api.Core.Domain.Entities.Base;

namespace NutritionistPreview.Api.Core.Domain.Entities
{
    public class Address : BaseEntity
    {
        public string Number { get; set; }
        public long ZipCode { get; set; }
        public string DescriptionAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
