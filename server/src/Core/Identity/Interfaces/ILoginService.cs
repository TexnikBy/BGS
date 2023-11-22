using System.Threading.Tasks;
using BGS.ApplicationCore.Identity.Models;
using BGS.SharedKernel.Results;

namespace BGS.ApplicationCore.Identity.Interfaces;

public interface ILoginService
{
    Task<Result<IdentityData>> Login(LoginData data);
}
    
    