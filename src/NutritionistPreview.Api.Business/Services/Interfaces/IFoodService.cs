
using NutritionistPreview.Api.Core.Domain.Dto;

namespace NutritionistPreview.Api.Business.Services.Interfaces
{
    public interface IFoodService
    {
        Task<List<Diet>> GetOptions(double caloricAmount);
    }
}
