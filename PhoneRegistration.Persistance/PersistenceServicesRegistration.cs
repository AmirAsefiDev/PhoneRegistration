using Microsoft.Extensions.DependencyInjection;
using PhoneRegistration.Application.Contracts.Persistence;
using PhoneRegistration.Persistence.Repositories;

namespace PhoneRegistration.Persistence;

public static class PersistenceServicesRegistration
{
    public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IPhoneNumberRepository, PhoneNumberRepository>();

        return services;
    }
}