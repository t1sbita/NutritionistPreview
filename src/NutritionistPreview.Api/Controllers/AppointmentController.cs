using Microsoft.AspNetCore.Mvc;
using NutritionistPreview.Api.Business.Services.Interfaces;
using NutritionistPreview.Api.Core.Util;
using NutritionistPreview.Api.Extension;
using NutritionistPreview.Api.Models.ViewModels;

namespace NutritionistPreview.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppointmentController : BaseController<AppointmentViewModel>
    {
        private readonly IAppointmentService _appointmentService;


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="appointmentService"></param>
        /// <param name="accessor"></param>
        /// <param name="logger"></param>
        public AppointmentController(IAppointmentService appointmentService,
                                        IHttpContextAccessor accessor,
                                        ILogger<AppointmentViewModel> logger) : base(accessor, logger)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet("page={page}&itemsByPage={itemsByPage}")]
        public async Task<ActionResult<PageConsultation<AppointmentViewModel>>> GetAllPaged(int page, int itemsByPage, long id)
        {
            var pageConsultation = await _appointmentService.GetAllPaged(page, itemsByPage, id);
            PageConsultation<AppointmentViewModel> result = MountViewModels.MountPageConsultation(pageConsultation);
            return Ok(result);
        }

        [HttpGet("id")]
        public async Task<ActionResult<AppointmentViewModel>> GetById(long id)
        {
            var result = await _appointmentService.GetById(id).ConfigureAwait(false);
            return Ok(MountViewModels.MountAppointmentViewModel(result));
        }
        
        [HttpPost]
        public async Task<ActionResult<AppointmentViewModel>> SaveAppointment(AppointmentViewModel appointment)
        {
            var result = await _appointmentService.SaveAppointment(MountEntities.MountAppointment(appointment)).ConfigureAwait(false);

            return Ok(MountViewModels.MountAppointmentViewModel(result));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAppointment(long id)
        {
            await _appointmentService.Delete(id).ConfigureAwait(false);

            return Ok();
        }

    }
}
