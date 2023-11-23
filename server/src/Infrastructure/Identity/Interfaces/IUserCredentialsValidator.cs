using System.Threading.Tasks;
using BGS.ApplicationCore.Entities;

namespace BGS.Infrastructure.Identity.Interfaces;

internal interface IUserCredentialsValidator
{
    Task<bool> Validate(User user, string password);
}