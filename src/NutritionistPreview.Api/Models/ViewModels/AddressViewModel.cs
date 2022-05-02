using NutritionistPreview.Api.Core.Domain.Entities;

namespace NutritionistPreview.Api.Models.ViewModels
{
    public class AddressViewModel : BaseViewModel
    {
        public string Number { get; set; }
        public long? ZipCode { get; set; }
        public string DescriptionAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
