using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace NutritionistPreview.Api.Controllers
{
    /// <summary>
    /// BaseController
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [ApiController]
    [ExcludeFromCodeCoverage]
    public class BaseController<T> : ControllerBase
    {
        /// <summary>
        /// BaseController.accessor
        /// </summary>
        protected IHttpContextAccessor accessor { get; private set; }

        /// <summary>
        /// BaseController.logger
        /// </summary>
        protected ILogger<T> logger { get; private set; }

        /// <summary>
        /// BaseController (Constructor)
        /// </summary>
        /// <param name="accessor"></param>
        /// <param name="logger"></param>
        public BaseController(IHttpContextAccessor accessor, ILogger<T> logger)
        {
            this.accessor = accessor;
            this.logger = logger;
        }

    }

}
