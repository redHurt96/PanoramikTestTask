using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TestTask.Presentation.UI.RankingsWindow
{
    internal class TableItem : MonoBehaviour
    {
        [SerializeField] private Image _background;
        [SerializeField] private Image _image;
        [SerializeField] private TMP_Text _nickname;
        [SerializeField] private TMP_Text _rank;
        [SerializeField] private TMP_Text _position;

        public void Init(UserModel model)
        {
            gameObject.SetActive(true);

            _image.sprite = model.Icon;
            _nickname.text = model.NickName;
            _rank.text = model.Rank;
            _position.text = model.Position;
            _background.color = model.Background;
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}