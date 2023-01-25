using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace SecuredApi.Controllers;

[ApiController]
[Authorize("CmScope")]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private static readonly string[] Customers =
    {
        "Mahdi", "Mitra"
    };

    private readonly ILogger<CustomerController> _logger;

    public CustomerController(ILogger<CustomerController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetCustomers")]
    public IEnumerable<string> Get()
    {
        var claim = User.Claims.FirstOrDefault();// x => x.Type == "sub").Value;

        return Customers;
    }
}