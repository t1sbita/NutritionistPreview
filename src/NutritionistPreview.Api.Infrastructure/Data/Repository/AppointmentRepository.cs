using NutritionistPreview.Api.Core.Domain.Entities;
using NutritionistPreview.Api.Infrastructure.Data.Context;
using NutritionistPreview.Api.Infrastructure.Data.Repository.Base;
using NutritionistPreview.Api.Infrastructure.Interfaces;

namespace NutritionistPreview.Api.Infrastructure.Data.Repository
{
    public class AppointmentRepository : BaseRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(NutritionistContext contexto) : base(contexto)
        {
        }
    }
}
