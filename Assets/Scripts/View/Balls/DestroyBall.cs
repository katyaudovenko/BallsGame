using System;
using DG.Tweening;
using UnityEngine;

namespace View.Balls
{
    public class DestroyBall : MonoBehaviour
    {
        public float Duration { get; private set; }
        
        private SpriteRenderer _sprite;

        public void Initialize()
        {
            Duration = 0.2f;
            _sprite = GetComponentInChildren<SpriteRenderer>();
        }

        public void StartAnimation(Action onComplete)
        {
            _sprite.DOFade(0f, Duration)
                .OnComplete(() => onComplete?.Invoke());
        }

        public void ResetAnimation()
        {
            var spriteColor = _sprite.color;
            spriteColor.a = 1;
            _sprite.color = spriteColor;
        }
    }
}