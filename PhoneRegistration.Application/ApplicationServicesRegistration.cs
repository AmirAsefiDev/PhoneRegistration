using Microsoft.Extensions.DependencyInjection;
using PhoneRegistration.Application.Services.PhoneNumber;

namespace PhoneRegistration.Application;

public static class ApplicationServicesRegistration
{
    public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IRegisterPhoneNumberService, RegisterPhoneNumberService>();

        return services;
    }
}