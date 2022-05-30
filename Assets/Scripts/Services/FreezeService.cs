using System;
using Model;
using Model.Infos;
using Services.ServiceLocator;
using UnityEngine;
using View.Balls;

namespace Services
{
    public class FreezeService : MonoBehaviour, IService
    {
        public event Action OnFreeze;
        
        private FreezeInfo _freezeInfo;
        private BallsManager _ballsManager;

        private float _currentTime;
        public bool IsEffectActive { get; private set; }

        public void Initialize(BallsManager ballsManager, FreezeInfo freezeInfo)
        {
            _ballsManager = ballsManager;
            _freezeInfo = freezeInfo;
        }

        private void Update()
        {
            if (!IsEffectActive) 
                return;
            
            _currentTime -= Time.deltaTime;
            if (_currentTime <= 0)
            {
                EndFreeze();
            }
        }

        public void StartFreeze()
        {
            _currentTime = _freezeInfo.FreezeTime;
            IsEffectActive = true;
           _ballsManager.InvokeActionOnBall<Ball>(ball => ball.BallMove.StopMove());
           OnFreeze?.Invoke();
        }

        private void EndFreeze()
        {
            IsEffectActive = false;
            _ballsManager.InvokeActionOnBall<Ball>(ball => ball.BallMove.StartMove());
        }
       
    }
}