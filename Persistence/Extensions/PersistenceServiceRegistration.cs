using Microsoft.Extensions.DependencyInjection;

namespace Persistence.Extensions
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
