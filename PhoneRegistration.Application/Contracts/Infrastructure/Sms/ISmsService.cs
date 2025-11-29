namespace PhoneRegistration.Application.Contracts.Infrastructure.Sms;

public interface ISmsService
{
    Task SendAsync(string mobile);
}