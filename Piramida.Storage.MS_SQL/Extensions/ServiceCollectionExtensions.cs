using Microsoft.Extensions.DependencyInjection;
using Piramida.Storage.MS_SQL.InitDatabase;

namespace Piramida.Storage.MS_SQL.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddStorageServices(this IServiceCollection services)
        {
            services.AddSingleton<DatabaseInit>();
        }
    }
}
