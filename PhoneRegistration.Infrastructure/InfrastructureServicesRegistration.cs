using Microsoft.Extensions.DependencyInjection;
using PhoneRegistration.Application.Contracts.Infrastructure.Sms;
using PhoneRegistration.Infrastructure.Sms;

namespace PhoneRegistration.Infrastructure;

public static class InfrastructureServicesRegistration
{
    public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<ISmsService, SmsService>();

        return services;
    }
}