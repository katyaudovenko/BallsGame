using System;
using Controller.Pool;
using Services;
using Services.ServiceLocator;
using UnityEngine;
using View.Balls.Components;
using View.Balls.Destroy;

namespace View.Balls.Abstract
{
    public abstract class Ball : MonoBehaviour, IPoolBehaviour
    {
        private IBallComponent[] _ballComponents;
        private PoolContainer _pool;
        private ScoreService _scoreService;

        protected FreezeService FreezeService;
        protected IBallDestroy BallDestroyBehaviour;

        public BallMove BallMove { get; private set; }

        public void SetupPool(PoolContainer pool)
        {
            _pool = pool;
            BallDestroyBehaviour.SetupPool(_pool);
        }

        public virtual void OnInitialize()
        {
            FreezeService = ServiceLocator.Instance.GetService<FreezeService>();
            _scoreService = ServiceLocator.Instance.GetService<ScoreService>();

            BallMove = GetComponent<BallMove>();
            BallDestroyBehaviour = GetComponent<IBallDestroy>();
            
            InvokeComponent<IBallComponent>(c=> c.OnInitialize());
        }

        public virtual void OnSetup()
        {
            InvokeComponent<IBallComponent>(c => c.OnSetup());
            BallDestroyBehaviour.OnDestroyByUser += AddScore;
        }

        public virtual void OnReset()
        {
            InvokeComponent<IBallComponent>(c => c.OnReset());
            BallDestroyBehaviour.OnDestroyByUser -= AddScore;
        }

        public void DestroyBallByZone() => 
            OnBallDestroy();
        
        public abstract void DestroyBallByUser();
        protected abstract void OnBallDestroy();

        private void InvokeComponent<T>(Action<T> action) where T : IBallComponent
        {
            _ballComponents ??= GetComponents<IBallComponent>();

            foreach (var ballComponent in _ballComponents)
            {
                var component = (T) ballComponent;
                action(component);
            }
        }

        private void AddScore() =>
            _scoreService.AddScore(1);
    }
}