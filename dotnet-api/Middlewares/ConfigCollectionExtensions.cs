using AnomalyPredictor.Options;
using Microsoft.Extensions.Configuration;

namespace AnomalyPredictor.Middlewares
{

    public static class ConfigCollectionExtensions{

    public static IServiceCollection AddAppSettings(
             this IServiceCollection services, IConfiguration config)
        {
            services.Configure<ApiSettings>(
                config.GetSection(ApiSettings.Apis));
            return services;
        }
    }

}