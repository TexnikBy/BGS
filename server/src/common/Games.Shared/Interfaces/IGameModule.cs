using Autofac;

namespace BGS.Games.Shared.Interfaces;

public interface IGameModule
{
    void AddBoardGame(ContainerBuilder builder);
}