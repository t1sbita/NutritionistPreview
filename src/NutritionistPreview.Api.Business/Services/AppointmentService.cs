using Microsoft.Extensions.Logging;
using NutritionistPreview.Api.Business.Services.Base;
using NutritionistPreview.Api.Business.Services.Interfaces;
using NutritionistPreview.Api.Core.Domain.Entities;
using NutritionistPreview.Api.Core.Exceptions;
using NutritionistPreview.Api.Core.Resources;
using NutritionistPreview.Api.Core.Util;
using NutritionistPreview.Api.Infrastructure.Interfaces;
using System.Linq.Expressions;

namespace NutritionistPreview.Api.Business.Services
{
    public class AppointmentService : BaseService<Appointment>, IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository, ILogger<Appointment> logger) : base(logger)
        {
            _appointmentRepository = appointmentRepository;
        }

        public Task<Appointment> SaveAppointment(Appointment appointment)
        {
            _logger.LogInformation("Method SaveAppointment AppointmentService");
            try
            {
                if (appointment == null || appointment?.ClientId == null)
                    throw new BusinessException(ResourceFactory.Create().GetMessage(Resource.FIELD_NOT_FOUND));


                if (appointment.Id > 0)
                    _appointmentRepository.Update(appointment);
                else
                    _appointmentRepository.Add(appointment);

                _appointmentRepository.Save();

                return Task.FromResult(appointment);
            }
            catch (BusinessException ex)
            {
                if (ex.Problem is null)
                {
                    _logger.LogError(message: ex.Message, string.Format("{0}.{1}", typeof(AppointmentService), nameof(SaveAppointment)));
                    throw new BusinessException(ex.Message);
                }
                else
                {
                    _logger.LogError(ex.Problem.Erros[0].FieldErros.First(), string.Format("{0}.{1}", typeof(AppointmentService), nameof(SaveAppointment)));
                    throw new BusinessException(ex.Problem.Erros[0].FieldErros.First());
                }
                throw;
            }
        }

        public Task<PageConsultation<Appointment>> GetAllPaged(int page, int itemsByPage, long id)
        {
            _logger.LogDebug($"GetAllPaged page: {page} itemsByPage: {itemsByPage}");

            var result = _appointmentRepository.GetAllPaged(page, itemsByPage, GetFilterById(id));

            return Task.FromResult(result);
        }

        private static ICollection<Expression<Func<Appointment, bool>>> GetFilterById(long id)
        {
            ICollection<Expression<Func<Appointment, bool>>> filters = new List<Expression<Func<Appointment, bool>>>
            {
                f => f.ClientId == id
            };

            return filters;
        }

        public Task<Appointment> GetById(long id)
        {
            _logger.LogInformation("Method GetById AppointmentService");
            var result = _appointmentRepository.GetById(id);

            if (result == null)
                throw new BusinessException(ResourceFactory.Create().GetMessage(Resource.FIELD_NOT_FOUND).Replace("{PropertyName}", "Appointment"));

            return Task.FromResult(result);
        }

        public Task<bool> Delete(long id)
        {
            _logger.LogInformation("Method Delete AppointmentService");
            var result = _appointmentRepository.Delete(id);

            _logger.LogInformation($"Success on delete entity: {result}");

            if (!result)
                throw new BusinessException(ResourceFactory.Create().GetMessage(Resource.FIELD_NOT_FOUND).Replace("{PropertyName}", "Appointment"));

            return Task.FromResult(result);
        }
    }
}
