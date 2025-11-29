using System.Text.RegularExpressions;
using PhoneRegistration.Application.Contracts.Infrastructure.Sms;
using PhoneRegistration.Application.Contracts.Persistence;
using PhoneRegistration.Common;

namespace PhoneRegistration.Application.Services.PhoneNumber;

public class RegisterPhoneNumberService : IRegisterPhoneNumberService
{
    private readonly IPhoneNumberRepository _repository;
    private readonly ISmsService _smsService;

    public RegisterPhoneNumberService(IPhoneNumberRepository repository, ISmsService smsService)
    {
        _repository = repository;
        _smsService = smsService;
    }

    public async Task<ResultDto> ExecuteAsync(RegisterPhoneNumberDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Mobile))
            return new ResultDto
            {
                IsSuccess = false,
                Message = "شماره موبایل خود را وارد نمایید"
            };

        var mobileRegex = @"^(?:0|98|\+98|\+980|0098|098|00980)?(9\d{9})$";
        var Checkout = Regex.Match(dto.Mobile, mobileRegex);
        if (!Checkout.Success)
            return new ResultDto
            {
                IsSuccess = false,
                Message = "شماره موبایل خود را به درستی وارد نمایید"
            };

        var formatedMobile = ConvertMobileToRawFormat(dto.Mobile);

        //avoid saving repeatedly mobile
        if (await _repository.ExistsByMobileAsync(formatedMobile))
            return new ResultDto
            {
                IsSuccess = false,
                Message = "این شماره تلفن قبلا ثبت شده، لطفا شماره تلفن دیگری وارد کنید."
            };

        var phoneNumber = new Domain.PhoneNumber
        {
            Mobile = formatedMobile
        };
        await _repository.AddAsync(phoneNumber);

        await _smsService.SendAsync(dto.Mobile);

        return new ResultDto
        {
            Message = "شماره موبایل با موفقیت اضافه شد.",
            IsSuccess = true
        };
    }

    /// <summary>
    ///     Convert Mobile to raw format to save in Database
    /// </summary>
    /// <param name="mobile"></param>
    /// <returns></returns>
    private string ConvertMobileToRawFormat(string mobile)
    {
        var correctMobileFrom = "";
        if (mobile.StartsWith("0")) correctMobileFrom = mobile.TrimStart().Substring(1);
        else if (mobile.StartsWith("+98")) correctMobileFrom = mobile.TrimStart().Substring(3);
        else if (mobile.StartsWith("98")) correctMobileFrom = mobile.TrimStart().Substring(2);
        else correctMobileFrom = mobile;
        return correctMobileFrom;
    }
}