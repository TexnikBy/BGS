using BGS.ApplicationCore.Identity.Models;
using BGS.SharedKernel.Results;
using MediatR;

namespace BGS.UseCases.Identity.Login;

public record LoginCommand(LoginData Data) : IRequest<Result<IdentityData>>;