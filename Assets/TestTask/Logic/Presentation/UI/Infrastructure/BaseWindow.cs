using System;
using System.Collections;
using UnityEngine;

namespace TestTask.Presentation.UI.Infrastructure
{
    public class BaseWindow : MonoBehaviour
    {
        [SerializeField] private float _fadeDuration = 0.5f;
        [SerializeField] private CanvasGroup _canvasGroup;
    
        private bool _isAnimating;

        public virtual void Show(bool isAnimated)
        {
            if (isAnimated)
                ShowAnimated();
            else
                gameObject.SetActive(true);
        }
    
        public virtual void Hide(bool isAnimated)
        {
            if (isAnimated)
                HideAnimated();
            else
                gameObject.SetActive(false);
        }

        private void ShowAnimated()
        {
            gameObject.SetActive(true);
            StartCoroutine(FadeAnimated(true));
        }

        private void HideAnimated()
        {
            StartCoroutine(FadeAnimated(false, () => gameObject.SetActive(false)));
        }

        private IEnumerator FadeAnimated(bool isShow, Action onComplete = null)
        {
            if (_isAnimating)
                yield break;
        
            _isAnimating = true;
            var counter = 0f;
            var (start, end) = isShow ? (0f, 1f) : (1f, 0f);
        
            while (counter < _fadeDuration)
            {
                counter += Time.deltaTime;
                _canvasGroup.alpha = Mathf.Lerp(start, end, counter / _fadeDuration);
 
                yield return null;
            }

            _isAnimating = false;
            onComplete?.Invoke();
        }
    }
}