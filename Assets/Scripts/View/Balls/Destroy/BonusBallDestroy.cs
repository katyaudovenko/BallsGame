using System;
using Controller;
using Controller.Pool;
using Services.ServiceLocator;
using UnityEngine;
using View.Balls.Abstract;

namespace View.Balls.Destroy
{
    public class BonusBallDestroy : MonoBehaviour, IBallDestroy, IBallComponent
    {
        public event Action OnDestroyByUser;
        
        private PoolContainer _pool;
        private BallsManager _ballsManager;


        public void SetupPool(PoolContainer pool) => _pool = pool;

        public void OnInitialize() => 
            _ballsManager = ServiceLocator.Instance.GetService<BallsManager>();

        public void OnDestroyBallByUser<T>(T ball) where T : Ball
        {
            OnDestroyBall(ball);
        }

        public void OnDestroyBall<T>(T ball) where T : Ball
        {
            _ballsManager.RemoveBall(ball);
            _pool.ReturnElement(ball);
        }

        public void OnSetup() { }
        
        public void OnReset() { }
    }
}