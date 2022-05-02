using NutritionistPreview.Api.Core.Domain.Entities;
using NutritionistPreview.Api.Core.Util;

namespace NutritionistPreview.Api.Business.Services.Interfaces
{
    public interface IAppointmentService
    {
        Task<PageConsultation<Appointment>> GetAllPaged(int page, int itemsByPage, long id);
        Task<Appointment> GetById(long id);
        Task<Appointment> SaveAppointment(Appointment appointment);
        Task<bool> Delete(long id);
    }
}
