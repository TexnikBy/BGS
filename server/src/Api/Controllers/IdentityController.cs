using BGS.Api.Controllers.Attributes;
using BGS.Api.Controllers.Constants;
using BGS.ApplicationCore.Identity.Models;
using BGS.SharedKernel.Results;
using BGS.UseCases.Identity.Login;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BGS.Api.Controllers;

[Authorize]
[ApiRoute]
[ApiController]
public class IdentityController(IMediator mediator) : ControllerBase
{
    [AllowAnonymous]
    [HttpPost(Routes.Identity.Login)]
    public Task<Result<IdentityData>> Login(LoginCommand command)
    {
        return mediator.Send(command);
    }
}