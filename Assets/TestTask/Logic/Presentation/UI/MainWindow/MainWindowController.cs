using System;
using TestTask.Logic.Controllers.Queries;

namespace TestTask.Presentation.UI.MainWindow
{
    internal class MainWindowController
    {
        private UserData _user;
        
        private readonly ICharacterQuery _characterQuery;
        private readonly MainWindow _window;
        private readonly Action _backButtonPressed;

        public MainWindowController(ICharacterQuery characterQuery, MainWindow window, Action backButtonPressed)
        {
            _characterQuery = characterQuery;
            _window = window;
            _backButtonPressed = backButtonPressed;
        }

        internal async void Show(bool animated)
        {
            _window.Show(animated);

            if (!_user.IsEmpty)
                _user = await _characterQuery.Get();
            
            _window.SetupModel(new()
            {
                PlayerRank = _user.Rank,
                ButtonPressed = _backButtonPressed.Invoke,
            });
        }

        internal void Hide(bool animated)
        {
            _window.Hide(animated);
        }
    }
}