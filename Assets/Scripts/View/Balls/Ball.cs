using System;
using Controller.Pool;
using Services;
using Services.ServiceLocator;


namespace View.Balls
{
    public abstract class Ball : PoolObject, IPoolBehaviour
    {
        protected event Action OnDestroy;
        
        private const int BasicNumberScore = 1;
        
        private BallsManager _ballsManager;
        private ScoreService _scoreService;

        protected FreezeService FreezeService;
        protected PoolContainer Pool;
        public BallMove BallMove { get; private set; }

        public void SetupPool(PoolContainer pool) => Pool = pool;

        public virtual void OnInitialize()
        {
            BallMove = GetComponent<BallMove>();
            FreezeService = ServiceLocator.Instance.GetService<FreezeService>();
            _scoreService = ServiceLocator.Instance.GetService<ScoreService>();
            _ballsManager = ServiceLocator.Instance.GetService<BallsManager>();
        }

        public void DestroyBallByUser()
        {
           _scoreService.AddScore(BasicNumberScore);
           OnDestroy?.Invoke();
           DestroyBall();
        }
        
        public void DestroyBall()
        {
            _ballsManager.RemoveBall(this);
            OnBallDestroy();
        }
        
        public virtual void OnSetup() { }

        public virtual void OnReset() { }
        
        protected abstract void OnBallDestroy();
    }
}