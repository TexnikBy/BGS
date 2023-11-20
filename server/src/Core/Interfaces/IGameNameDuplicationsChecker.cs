using System.Threading;
using System.Threading.Tasks;

namespace BGS.ApplicationCore.Interfaces;

public interface IGameNameDuplicationsChecker
{
    Task<bool> Check(string gameName, CancellationToken cancellationToken);
}