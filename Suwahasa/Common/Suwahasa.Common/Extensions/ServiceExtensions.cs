using Microsoft.Extensions.DependencyInjection;

namespace Suwahasa.Common
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services, string policyName)
        {
            services.AddCors(
              options => options.AddPolicy(policyName,
                builderCors =>
                {
                    builderCors.WithOrigins("http://localhost:4200", "https://suwahasa.azurewebsites.net")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                })
            );
        }
    }
}