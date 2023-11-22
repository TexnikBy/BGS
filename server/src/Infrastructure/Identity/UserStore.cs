using System.Threading;
using System.Threading.Tasks;
using BGS.ApplicationCore.Entities;
using BGS.Infrastructure.Identity.Specificaitons;
using BGS.SharedKernel;
using Microsoft.AspNetCore.Identity;

namespace BGS.Infrastructure.Identity;

internal sealed class UserStore(IRepository<User> userRepository) : IUserPasswordStore<User>
{
    public Task<User> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken) =>
        userRepository.FirstOrDefaultAsync(new UserByNameSpecification(normalizedUserName), cancellationToken);

    public Task<string> GetPasswordHashAsync(User user, CancellationToken cancellationToken) =>
        Task.FromResult(user.PasswordHash);

    public Task<bool> HasPasswordAsync(User user, CancellationToken cancellationToken) =>
        Task.FromResult(!string.IsNullOrWhiteSpace(user.PasswordHash));

    public Task<string> GetUserIdAsync(User user, CancellationToken cancellationToken)
    {
        throw new System.NotImplementedException();
    }

    public Task<string> GetUserNameAsync(User user, CancellationToken cancellationToken)
    {
        throw new System.NotImplementedException();
    }

    public Task SetUserNameAsync(User user, string userName, CancellationToken cancellationToken)
    {
        throw new System.NotImplementedException();
    }

    public Task<string> GetNormalizedUserNameAsync(User user, CancellationToken cancellationToken)
    {
        throw new System.NotImplementedException();
    }

    public Task SetNormalizedUserNameAsync(User user, string normalizedName, CancellationToken cancellationToken)
    {
        throw new System.NotImplementedException();
    }

    public Task<IdentityResult> CreateAsync(User user, CancellationToken cancellationToken)
    {
        throw new System.NotImplementedException();
    }

    public Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken)
    {
        throw new System.NotImplementedException();
    }

    public Task<IdentityResult> DeleteAsync(User user, CancellationToken cancellationToken)
    {
        throw new System.NotImplementedException();
    }

    public Task<User> FindByIdAsync(string userId, CancellationToken cancellationToken)
    {
        throw new System.NotImplementedException();
    }

    public Task SetPasswordHashAsync(User user, string passwordHash, CancellationToken cancellationToken)
    {
        throw new System.NotImplementedException();
    }

    public void Dispose()
    {
        // nothing to dispose
    }
}