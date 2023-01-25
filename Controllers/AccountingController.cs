using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SecuredApi.Controllers;

[ApiController]
[Authorize("AccScope")]
[Route("[controller]")]
public class AccountingController : ControllerBase
{
    private static readonly string[] Generals =
    {
        "Bank", "Test"
    };

    private readonly ILogger<AccountingController> _logger;

    public AccountingController(ILogger<AccountingController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetGenerals")]
    public IEnumerable<string> Get()
    {
        var claim = User.Claims.FirstOrDefault();// x => x.Type == "sub").Value;

        return Generals;
    }
}
