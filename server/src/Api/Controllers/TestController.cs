using Api.Controllers.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiRoute]
[ApiController]
public class TestController : ControllerBase
{
    [HttpGet]
    public Task<string> GetHelloWorld() => Task.FromResult("Hello World");
}