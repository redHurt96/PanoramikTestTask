using System;
using System.Collections.Generic;
using System.Linq;
using TestTask.Logic.Controllers.NetClientService;
using TestTask.Logic.Controllers.Queries;
using TestTask.Logic.Presentation.AssetLoaderService;
using UnityEngine;

namespace TestTask.Presentation.UI.RankingsWindow
{
    public class RankingsWindowController
    {
        private const int USERS_PER_PAGE = 7;

        private List<RankingUserData> _users;
        private int _currentPage;

        private readonly IRankingsQuery _query;
        private readonly IAssetLoader _assetLoader;
        private readonly RankingsWindow _window;
        private readonly Action _showMainWindow;
        private readonly RankingWindowConfig _config;

        public RankingsWindowController(IRankingsQuery query,
            IAssetLoader assetLoader,
            RankingsWindow window,
            RankingWindowConfig rankingWindowConfig,
            Action showMainWindow)
        {
            _query = query;
            _assetLoader = assetLoader;
            _window = window;
            _config = rankingWindowConfig;
            _showMainWindow = showMainWindow;
        }

        internal void Show(bool animated)
        {
            _currentPage = 0;

            _window.Show(animated);
            _window.SetupCommon(new()
            {
                OnNextButtonClick = SelectNextUsers,
                OnPreviousButtonClick = SelectPreviousUsers,
                OnBackButtonClick = _showMainWindow.Invoke,
                Background = _assetLoader.LoadBackground(),
                ItemsPerPage = USERS_PER_PAGE,
            });
            SetupUsers();
        }

        public void Hide(bool animated) => 
            _window.Hide(animated);

        private void SelectNextUsers()
        {
            int nextPage = Mathf.Min(_currentPage + 1, _users.Count / USERS_PER_PAGE);

            if (_currentPage != nextPage)
            {
                _currentPage = nextPage;
                SetupUsers();
            }
        }

        private void SelectPreviousUsers()
        {
            int nextPage = Mathf.Max(_currentPage - 1, 0);
            
            if (_currentPage != nextPage)
            {
                _currentPage = nextPage;
                SetupUsers();
            }
        }

        private async void SetupUsers()
        {
            _users ??= await _query.Get();
            
            _window.Setup(new()
            {
                Users = SelectUsers(),
                ShowNextButton = HasNextUsers(),
                ShowPreviousButton = HasPreviousUsers(),
            });
        }

        private bool HasNextUsers() => 
            _users.Count > (_currentPage + 1) * USERS_PER_PAGE;

        private bool HasPreviousUsers() => 
            _currentPage > 0;

        private UserModel[] SelectUsers()
        {
            return _users
                .Skip(USERS_PER_PAGE * _currentPage)
                .Take(USERS_PER_PAGE)
                .Select(x => new UserModel()
                {
                    NickName = x.Nickname,
                    Position = x.Position.ToString(),
                    Icon = _assetLoader.LoadIconSprite(x.IconName),
                    Background = _config.GetBackground(x.IsLocal),
                    Rank = x.Rank.ToString(),
                })
                .ToArray();
        }
    }
}