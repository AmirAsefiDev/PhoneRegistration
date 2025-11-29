using Microsoft.Extensions.Logging;
using PhoneRegistration.Application.Contracts.Infrastructure.Sms;

namespace PhoneRegistration.Infrastructure.Sms;

public class SmsService : ISmsService
{
    private readonly ILogger<SmsService> _logger;

    public SmsService(ILogger<SmsService> logger)
    {
        _logger = logger;
    }

    public Task SendAsync(string mobile)
    {
        _logger.LogInformation("Send sms called for mobile {Mobile}", mobile);
        return Task.CompletedTask;
    }
}