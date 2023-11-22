using System.Threading.Tasks;

namespace BGS.ApplicationCore.Identity.Interfaces;

public interface IAccessTokenGenerator
{
    Task<string> Generate(string userName);
}