using TestTask.Presentation.UI.Infrastructure;
using UnityEngine;
using Zenject;

namespace TestTask.Logic.Bootstrap
{
    public class Bootstrap : MonoBehaviour
    {
        private IWindowsManager _windowsManager;

        [Inject]
        private void Construct(IWindowsManager windowsManager) => 
            _windowsManager = windowsManager;

        private void Start() => 
            _windowsManager.ShowMain();
    }
}