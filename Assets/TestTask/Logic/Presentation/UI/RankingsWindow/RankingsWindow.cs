using System.Collections.Generic;
using TestTask.Presentation.UI.Infrastructure;
using UnityEngine;
using UnityEngine.UI;

namespace TestTask.Presentation.UI.RankingsWindow
{
    public class RankingsWindow : BaseWindow
    {
        [SerializeField] private Button _backButton;
        [SerializeField] private Button _nextButton;
        [SerializeField] private Button _prevButton;
        [SerializeField] private Transform _itemsParent;
        [SerializeField] private Image _background;

        [Header("Settings")] 
        [SerializeField] private TableItem _tableItemPrefab;

        private readonly List<TableItem> _tableItems = new();

        public override void Hide(bool isAnimated)
        {
            _nextButton.onClick.RemoveAllListeners();
            _prevButton.onClick.RemoveAllListeners();
            _backButton.onClick.RemoveAllListeners();
            
            base.Hide(isAnimated);
        }

        internal void SetupCommon(RankingsWindowCommonModel commonModel)
        {
            _nextButton.onClick.AddListener(commonModel.OnNextButtonClick.Invoke);
            _prevButton.onClick.AddListener(commonModel.OnPreviousButtonClick.Invoke);
            _backButton.onClick.AddListener(commonModel.OnBackButtonClick.Invoke);
            _background.sprite = commonModel.Background;

            PreloadTable(commonModel.ItemsPerPage);
        }

        internal void Setup(RankingsWindowModel model)
        {
            _nextButton.gameObject.SetActive(model.ShowNextButton);
            _prevButton.gameObject.SetActive(model.ShowPreviousButton);
        
            for (int i = 0; i < _tableItems.Count; i++)
            {
                if (i < model.Users.Length)
                    _tableItems[i].Init(model.Users[i]);
                else
                    _tableItems[i].Hide();
            }
        }

        private void PreloadTable(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                TableItem tableItem = Instantiate(_tableItemPrefab, _itemsParent);
                tableItem.Hide();
                _tableItems.Add(tableItem);
            }
        }
    }
}