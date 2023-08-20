using TestTask.Logic.Presentation.AssetLoaderService;
using TestTask.Presentation.UI.Infrastructure;
using UnityEngine;
using Zenject;

namespace TestTask.Presentation
{
    public static class DependencyInjection
    {
        public static DiContainer InstallPresentation(this DiContainer diContainer, Transform windowsParent)
        {
            diContainer.Bind<Transform>().FromInstance(windowsParent).AsSingle();
            diContainer.Bind<IAssetLoader>().To<AssetLoader>().AsSingle();
            diContainer.Bind<IWindowsManager>().To<WindowsManager>().AsSingle().NonLazy();

            return diContainer;
        }
    }
}