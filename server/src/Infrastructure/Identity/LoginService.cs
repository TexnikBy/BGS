using System.Threading.Tasks;
using BGS.ApplicationCore.Entities;
using BGS.ApplicationCore.Identity.Interfaces;
using BGS.ApplicationCore.Identity.Models;
using BGS.Infrastructure.Identity.Interfaces;
using BGS.SharedKernel.Results;
using Microsoft.AspNetCore.Identity;

namespace BGS.Infrastructure.Identity;

internal class LoginService(
        IUserCredentialsValidator userCredentialsValidator,
        IAccessTokenGenerator accessTokenGenerator,
        UserManager<User> userManager)
    : ILoginService
{
    public async Task<Result<IdentityData>> Login(LoginData data)
    {
        var user = await userManager.FindByNameAsync(data.UserName);
        if (await userCredentialsValidator.Validate(user, data.Password))
        {
            var accessToken = await accessTokenGenerator.Generate(data.UserName);
            return Result<IdentityData>.Success(new IdentityData(accessToken));
        }

        return Result<IdentityData>.Error("Incorrect user name or password");
    }
}