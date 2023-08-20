using TestTask.Logic.Controllers.NetClientService;
using TestTask.Logic.Controllers.Queries;
using Zenject;

namespace TestTask.Logic.Controllers
{
    public static class DependencyInjection
    {
        public static DiContainer InstallControllers(this DiContainer diContainer)
        {
            diContainer.Bind<INetClient>().To<NetClient>().AsSingle();
            diContainer.Bind<IRankingsQuery>().To<RankingsQuery>().AsSingle();
            diContainer.Bind<ICharacterQuery>().To<CharacterQuery>().AsSingle();

            return diContainer;
        }
    }
}