using System.Threading.Tasks;
using BGS.ApplicationCore.Entities;
using BGS.Infrastructure.Identity.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace BGS.Infrastructure.Identity;

internal class UserCredentialsValidator(UserManager<User> userManager) : IUserCredentialsValidator
{
    public Task<bool> Validate(User user, string password)
    {
        return user == null
            ? Task.FromResult(false)
            : userManager.CheckPasswordAsync(user, password);
    }
}