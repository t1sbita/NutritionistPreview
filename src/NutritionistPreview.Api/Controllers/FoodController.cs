using Microsoft.AspNetCore.Mvc;
using NutritionistPreview.Api.Business.Services.Interfaces;
using NutritionistPreview.Api.Core.Domain.Dto;

namespace NutritionistPreview.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FoodController : BaseController<Diet>
    {
        private readonly IFoodService _foodService;


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="foodService"></param>
        /// <param name="accessor"></param>
        /// <param name="logger"></param>
        public FoodController(IFoodService foodService,
                                        IHttpContextAccessor accessor,
                                        ILogger<Diet> logger) : base(accessor, logger)
        {
            _foodService = foodService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Diet>>> GetDiet(int caloricAmount, int page, int itemsByPage)
        {
            var result = await _foodService.GetOptions(caloricAmount, page, itemsByPage).ConfigureAwait(false);

            return Ok(result);
        }
    
    }
}
