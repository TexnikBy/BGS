using System.Threading.Tasks;

namespace BGS.ApplicationCore.Interfaces;

public interface IGameDuplicationChecker
{
    Task<bool> Check(string gameName);
}