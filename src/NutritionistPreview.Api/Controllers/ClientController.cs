using Microsoft.AspNetCore.Mvc;
using NutritionistPreview.Api.Business.Services.Interfaces;
using NutritionistPreview.Api.Extension;
using NutritionistPreview.Api.Models.ViewModels;

namespace NutritionistPreview.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : BaseController<ClientViewModel>
    {
        private readonly IClientService _clientService;


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="clientService"></param>
        /// <param name="accessor"></param>
        /// <param name="logger"></param>
        public ClientController(IClientService clientService,
                                        IHttpContextAccessor accessor,
                                        ILogger<ClientViewModel> logger) : base(accessor, logger)
        {
            _clientService = clientService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClientViewModel>> GetById(long id)
        {
            var result = await _clientService.GetById(id).ConfigureAwait(false);
            return Ok(MountViewModels.MountClientViewModel(result));
        }
        
        [HttpGet("SearchByDocument/{documentNumber}")]
        public async Task<ActionResult<ClientViewModel>> GetByDocumentNumber(long id)
        {
            var result = await _clientService.GetByDocumentNumber(id).ConfigureAwait(false);
            return Ok(MountViewModels.MountClientViewModel(result));
        }

        [HttpPost]
        public async Task<ActionResult<ClientViewModel>> SaveClient([FromBody] ClientViewModel client)
        {
            var result = await _clientService.SaveClient(MountEntities.MountClient(client)).ConfigureAwait(false);

            return Ok(MountViewModels.MountClientViewModel(result));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteClient(long id)
        {
            await _clientService.Delete(id).ConfigureAwait(false);

            return Ok();
        }

    }
    
}
