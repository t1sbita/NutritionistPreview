using NutritionistPreview.Api.Business.Extension;
using NutritionistPreview.Api.Business.Services;
using NutritionistPreview.Api.Business.Services.Interfaces;

namespace NutritionistPreview.Api.Extension
{
    public static class CustomExtensionDI
    {
        /// <summary>
        /// CustomExtensionDI.AddSingleton
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddSingletons(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            return services;
        }

        /// <summary>
        /// CustomExtensionDI.AddScoped
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddScopeds(this IServiceCollection services)
        {
            CustomExtensionRepository.AddScoped(services);

            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<IFoodService, FoodService>();
            return services;
        }
    }
}
