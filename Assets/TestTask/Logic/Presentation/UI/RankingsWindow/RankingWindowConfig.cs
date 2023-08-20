using UnityEngine;

namespace TestTask.Presentation.UI.RankingsWindow
{
    [CreateAssetMenu(menuName = "Create MainWindowConfig", fileName = "MainWindowConfig", order = 0)]
    public class RankingWindowConfig : ScriptableObject
    {
        [SerializeField] private Color _common;
        [SerializeField] private Color _player;

        public Color GetBackground(bool isPlayerLocal) =>
            isPlayerLocal
                ? _player
                : _common;
    }
}