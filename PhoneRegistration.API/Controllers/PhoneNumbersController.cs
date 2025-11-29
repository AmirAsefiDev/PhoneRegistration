using Microsoft.AspNetCore.Mvc;
using PhoneRegistration.Application.Services.PhoneNumber;
using PhoneRegistration.Common;

namespace PhoneRegistration.API.Controllers;

[Route("api/phone-numbers")]
[ApiController]
public class PhoneNumbersController : ControllerBase
{
    private readonly IRegisterPhoneNumberService _registerService;

    public PhoneNumbersController(IRegisterPhoneNumberService registerService)
    {
        _registerService = registerService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResultDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResultDto), StatusCodes.Status409Conflict)]
    [ProducesResponseType(typeof(ResultDto), StatusCodes.Status200OK)]
    public async Task<ActionResult> Post(RegisterPhoneNumberDto phoneNumberDto)
    {
        var result = await _registerService.ExecuteAsync(phoneNumberDto);

        if (!result.IsSuccess && result.Message.Contains("قبلا ثبت"))
            return Conflict(new ResultDto
            {
                IsSuccess = result.IsSuccess,
                Message = result.Message
            });
        if (!result.IsSuccess)
            return BadRequest(new ResultDto
            {
                IsSuccess = result.IsSuccess,
                Message = result.Message
            });

        return Ok(new ResultDto
        {
            Message = result.Message,
            IsSuccess = result.IsSuccess
        });
    }
}