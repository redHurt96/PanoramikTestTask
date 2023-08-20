using TestTask.Logic.Controllers;
using TestTask.Presentation;
using UnityEngine;
using Zenject;

namespace TestTask.Logic.Bootstrap
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private Transform _windowsParent;
        
        public override void InstallBindings() =>
            Container
                .InstallPresentation(_windowsParent)
                .InstallControllers();
    }
}