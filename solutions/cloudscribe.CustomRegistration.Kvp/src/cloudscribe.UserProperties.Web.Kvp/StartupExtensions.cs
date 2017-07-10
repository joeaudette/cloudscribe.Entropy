using cloudscribe.UserProperties.Models;
using cloudscribe.UserProperties.Services;
using cloudscribe.UserProperties.Web.Kvp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class StartupExtensions
    {
        public static IServiceCollection AddCloudscribeKvpUserProperties(this IServiceCollection services, IConfigurationRoot configuration = null)
        {
            services.TryAddScoped<IUserPropertyService, UserPropertyService>();
            services.TryAddScoped<IUserPropertyValidator, UserPropertyValidator>();
            services.TryAddScoped<TenantProfileOptionsResolver>();


            return services;
        }
    }
}
