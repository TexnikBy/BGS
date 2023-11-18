using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using BGS.Infrastructure.Identity.Interfaces;

namespace BGS.Infrastructure.Identity;

internal class UserClaimsProvider : IUserClaimsProvider
{
    public Task<List<Claim>> Get(string userName)
    {
        return Task.FromResult(new List<Claim>
        {
            new (ClaimTypes.NameIdentifier, userName),
        });
    }
}