using Microsoft.AspNetCore.Mvc;
using PhoneRegistration.Application.Services.PhoneNumber;
using PhoneRegistration.Common;

namespace PhoneRegistration.API.Controllers;

public class PhoneNumbersMvcController : Controller
{
    private readonly IRegisterPhoneNumberService _registerService;

    public PhoneNumbersMvcController(IRegisterPhoneNumberService registerService)
    {
        _registerService = registerService;
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] RegisterPhoneNumberDto dto)
    {
        var result = await _registerService.ExecuteAsync(dto);

        return Json(new ResultDto
        {
            Message = result.Message,
            IsSuccess = result.IsSuccess
        });
    }
}