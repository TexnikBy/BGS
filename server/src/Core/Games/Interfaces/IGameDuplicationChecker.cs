using System.Threading.Tasks;

namespace BGS.ApplicationCore.Games.Interfaces;

public interface IGameDuplicationChecker
{
    Task<bool> Check(string gameName);
}