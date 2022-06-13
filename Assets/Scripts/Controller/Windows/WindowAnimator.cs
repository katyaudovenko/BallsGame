using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Controller.Windows
{
    public class WindowAnimator : MonoBehaviour
    {
        [Header("Animation Components")]
        [SerializeField] private Image backgroundImage;
        [SerializeField] private CanvasGroup contentCanvasGroup;
        [SerializeField] private RectTransform contentRectTransform;

        [Header("Settings")]
        [SerializeField] private float openDuration;
        [SerializeField] private float closeDuration;
        [SerializeField] private float showContentAlpha;
        
        public Tween AppearAnimation()
        {
            var sequence = DOTween.Sequence();
            sequence.Join(backgroundImage.DOFade(showContentAlpha, openDuration));
            sequence.Join(contentCanvasGroup.DOFade(1f, openDuration));
            sequence.Join(contentRectTransform.DOScale(1f, openDuration));
            return sequence;
        }

        public Tween HideAnimation(Action onComplete)
        {
            var sequence = DOTween.Sequence();
            sequence.Join(backgroundImage.DOFade(0f, closeDuration));
            sequence.Join(contentCanvasGroup.DOFade(0f, closeDuration));
            sequence.Join(contentRectTransform.DOScale(0f, closeDuration));
            sequence.OnComplete(() => onComplete?.Invoke());
            return sequence;
        }
    }
}