using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace cloudscribe.Kvp.Storage.EFCore.Common
{
    public static class StartupExtensions
    {
        public static IServiceCollection AddCloudscribeKvpEFCommon(
            this IServiceCollection services
            )
        {

            services.TryAddScoped<IKvpTableNames, KvpTableNames>();

            return services;
        }
    }
}
