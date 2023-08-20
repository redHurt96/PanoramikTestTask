using TestTask.Presentation.UI.Infrastructure;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TestTask.Presentation.UI.MainWindow
{
    internal class MainWindow : BaseWindow
    {
        [SerializeField] private Button _openRankings;
        [SerializeField] private TMP_Text _playerPosition;

        public override void Show(bool isAnimated)
        {
            _playerPosition.enabled = false;
            base.Show(isAnimated);
        }

        public override void Hide(bool isAnimated)
        {
            _openRankings.onClick.RemoveAllListeners();
            base.Hide(isAnimated);
        }

        public void SetupModel(MainWindowModel model)
        {
            _playerPosition.enabled = true;
            _playerPosition.text = $"Your rank: {model.PlayerRank}";
            _openRankings.onClick.AddListener(model.ButtonPressed.Invoke);
        }
    }
}