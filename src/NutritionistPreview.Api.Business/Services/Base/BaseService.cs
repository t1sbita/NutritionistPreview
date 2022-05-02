using Microsoft.Extensions.Logging;

namespace NutritionistPreview.Api.Business.Services.Base
{
    public class BaseService<T> where T : new()
    {
        protected readonly ILogger<T> _logger;
        public BaseService(ILogger<T> logger)
        {
            _logger = logger;
        }
    }
}
