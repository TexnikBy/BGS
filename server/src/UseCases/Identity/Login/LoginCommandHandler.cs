using System.Threading;
using System.Threading.Tasks;
using BGS.ApplicationCore.Identity.Interfaces;
using BGS.ApplicationCore.Identity.Models;
using BGS.SharedKernel.Results;
using MediatR;

namespace BGS.UseCases.Identity.Login;

internal class LoginCommandHandler(ILoginService loginService) : IRequestHandler<LoginCommand, Result<IdentityData>>
{
    public Task<Result<IdentityData>> Handle(LoginCommand command, CancellationToken cancellationToken)
    {
        return loginService.Login(command.Data);
    }
}