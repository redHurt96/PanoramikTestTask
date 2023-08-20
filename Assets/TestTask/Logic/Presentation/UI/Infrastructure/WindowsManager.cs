using TestTask.Logic.Controllers.Queries;
using TestTask.Logic.Presentation.AssetLoaderService;
using TestTask.Presentation.UI.MainWindow;
using TestTask.Presentation.UI.RankingsWindow;

namespace TestTask.Presentation.UI.Infrastructure
{
    internal class WindowsManager : IWindowsManager
    {
        private readonly RankingsWindowController _rankingsWindowController;
        private readonly MainWindowController _mainWindowController;

        public WindowsManager(IAssetLoader assetLoader, IRankingsQuery rankingsQuery, ICharacterQuery characterQuery)
        {
            _mainWindowController = new(
                characterQuery,
                assetLoader.CreateWindow<TestTask.Presentation.UI.MainWindow.MainWindow>(),
                ShowRankings);
            
            _rankingsWindowController = new(
                rankingsQuery, 
                assetLoader, 
                assetLoader.CreateWindow<TestTask.Presentation.UI.RankingsWindow.RankingsWindow>(),
                assetLoader.LoadConfig<RankingWindowConfig>(),
                ShowMain);
        }

        public void ShowMain()
        {
            _rankingsWindowController.Hide(false);
            _mainWindowController.Show(false);
        }

        public void ShowRankings()
        {
            _rankingsWindowController.Show(false);
            _mainWindowController.Hide(false);
        }
    }
}