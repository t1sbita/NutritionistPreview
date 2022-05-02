using NutritionistPreview.Api.Core.Domain.Dto;
using NutritionistPreview.Api.Core.Util;

namespace NutritionistPreview.Api.Business.Services.Interfaces
{
    public interface IFoodService
    {
        Task<PageConsultation<Diet>> GetOptions(int caloricAmount, int page, int itemsByPage);
    }
}
