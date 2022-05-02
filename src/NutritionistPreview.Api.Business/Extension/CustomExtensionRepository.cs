using Microsoft.Extensions.DependencyInjection;
using NutritionistPreview.Api.Infrastructure.Data.Repository;
using NutritionistPreview.Api.Infrastructure.Data.Repository.Base;
using NutritionistPreview.Api.Infrastructure.Interfaces;
using NutritionistPreview.Api.Infrastructure.Interfaces.Base;

namespace NutritionistPreview.Api.Business.Extension
{
    public static class CustomExtensionRepository
    {
        public static IServiceCollection AddScoped(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();

            return services;
        }
    }
}
