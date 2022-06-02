using System;
using Controller;
using Controller.Pool;
using Services;
using Services.ServiceLocator;
using View.Balls.Components;
using View.Balls.Destroy;

namespace View.Balls.Abstract
{
    public abstract class Ball : PoolObject, IPoolBehaviour
    {
        private const int BasicNumberScore = 1;
        
        private BallsManager _ballsManager;
        private ScoreService _scoreService;
        private IBallComponent[] _ballComponents;
        private PoolContainer _pool;

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
            _ballsManager = ServiceLocator.Instance.GetService<BallsManager>();
            
            BallMove = GetComponent<BallMove>();
            BallDestroyBehaviour = GetComponent<IBallDestroy>();
            
            InvokeComponent<IBallComponent>(c=> c.OnInitialize());
        }

        public void DestroyBallByUser()
        { 
            _scoreService.AddScore(BasicNumberScore);
            DestroyBall();
        }
        
        public void DestroyBall()
        {
            _ballsManager.RemoveBall(this);
            OnBallDestroy();
        }

        public virtual void OnSetup() => 
            InvokeComponent<IBallComponent>(c=> c.OnSetup());

        public virtual void OnReset() =>
            InvokeComponent<IBallComponent>(c => c.OnReset());
        
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
    }
}