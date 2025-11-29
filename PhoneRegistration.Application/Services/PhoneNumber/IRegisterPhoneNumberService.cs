using PhoneRegistration.Common;

namespace PhoneRegistration.Application.Services.PhoneNumber;

public interface IRegisterPhoneNumberService
{
    Task<ResultDto> ExecuteAsync(RegisterPhoneNumberDto dto);
}