using System;
using Controller.Pool;
using DG.Tweening;
using UnityEngine;
using View.Balls.Abstract;
using View.Balls.Components;

namespace View.Balls.Destroy
{
    public class CommonBallDestroy : MonoBehaviour, IBallDestroy, IBallComponent
    {
        //public event Action OnDestroy;

        private ProbabilityCoinSpawn _coinSpawn;
        private float _duration;
        private SpriteRenderer _sprite;

        private PoolContainer _pool;

        public void SetupPool(PoolContainer pool) => _pool = pool;

        public void OnInitialize()
        {
            _duration = 0.2f;
            _sprite = GetComponentInChildren<SpriteRenderer>();
            _coinSpawn = GetComponent<ProbabilityCoinSpawn>();
        }
        
        public void OnSetup() { }

        public void OnReset()
        {
            var spriteColor = _sprite.color;
            spriteColor.a = 1;
            _sprite.color = spriteColor;
        }

        public void OnDestroyBall<T>(T ball) where T : Ball
        {
            StartAnimation(() =>
            {
                _pool.ReturnElement(ball);
                _coinSpawn.SpawnCoin();
            });
        }

        private void StartAnimation(Action onComplete)
        {
            _sprite.DOFade(0f, _duration)
                .OnComplete(() => onComplete?.Invoke());
        }
    }
}