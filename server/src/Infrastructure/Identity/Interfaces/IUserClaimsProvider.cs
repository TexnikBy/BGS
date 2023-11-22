using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BGS.Infrastructure.Identity.Interfaces;

internal interface IUserClaimsProvider
{
    Task<List<Claim>> Get(string userName);
}