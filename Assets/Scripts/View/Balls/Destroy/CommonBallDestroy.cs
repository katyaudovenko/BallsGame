using System;
using Controller;
using Controller.Pool;
using DG.Tweening;
using Services.ServiceLocator;
using UnityEngine;
using View.Balls.Abstract;

namespace View.Balls.Destroy
{
    public class CommonBallDestroy : MonoBehaviour, IBallDestroy, IBallComponent
    {
        public event Action OnDestroyByUser;
        
        private SpriteRenderer _sprite;
        private PoolContainer _pool;
        private BallsManager _ballsManager;
        private float _duration;
        private bool _markToDestroy;

        public void SetupPool(PoolContainer pool) => _pool = pool;

        public void OnInitialize()
        {
            _duration = 0.2f;
            _sprite = GetComponentInChildren<SpriteRenderer>();

            _ballsManager = ServiceLocator.Instance.GetService<BallsManager>();
        }

        public void OnSetup() => 
            _markToDestroy = false;

        public void OnReset()
        {
            var spriteColor = _sprite.color;
            spriteColor.a = 1;
            _sprite.color = spriteColor;
        }

        public void OnDestroyBallByUser<T>(T ball) where T : Ball
        {
            if(_markToDestroy) return;
            
            OnDestroyByUser?.Invoke();
            OnDestroyBall(ball);
        }

        public void OnDestroyBall<T>(T ball) where T : Ball
        {
            if(_markToDestroy) return;
            
            _ballsManager.RemoveBall(ball);
            StartAnimation(() =>
            {
                _pool.ReturnElement(ball);
            });
        }

        private void StartAnimation(Action onComplete)
        {
            _markToDestroy = true;
            
            _sprite.DOFade(0f, _duration)
                .OnComplete(() => onComplete?.Invoke());
        }
    }
}