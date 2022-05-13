﻿using Controller.Pool;
using Services;


namespace View.Balls
{
    public abstract class Ball : PoolObject, IPoolBehaviour
    {
        private BallsManager _ballsManager;
        private ScoreService _scoreService;

        protected PoolContainer Pool;
        protected FreezeService FreezeService;
        public BallMove BallMove { get; private set; }
        
        public void SetupPool(PoolContainer pool)
        {
            Pool = pool;
        }
        
        public virtual void OnInitialize()
        {
            BallMove = GetComponent<BallMove>();
            FreezeService = ServiceLocator.Instance.GetService<FreezeService>();
            _scoreService = ServiceLocator.Instance.GetService<ScoreService>();
            _ballsManager = ServiceLocator.Instance.GetService<BallsManager>();
        }

        public void DestroyBallByUser()
        {
            _scoreService.AddScore(1);
            _ballsManager.RemoveBall(this);
            OnBallDestroy();
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