using System;
using Controller;
using Controller.SpawnLogic;
using Model.Infos;
using Services.ServiceLocator;
using UnityEngine;
using View.Balls.Abstract;
using View.Balls.Effects;

namespace Services
{
    public class FreezeService : MonoBehaviour, IService
    {
        public event Action OnFreeze;

        private FreezeInfo _freezeInfo;
        private BallsManager _ballsManager;
        private GameFactory _gameFactory;
        private FrostEffect _frostEffect;

        private float _currentTime;

        public bool IsEffectActive { get; private set; }
        
        public void Construct(BallsManager ballsManager, FreezeInfo freezeInfo, GameFactory gameFactory)
        {
            _ballsManager = ballsManager;
            _freezeInfo = freezeInfo;
            _gameFactory = gameFactory;
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
            
            if(_frostEffect == null)
                _frostEffect = _gameFactory.CreateFrostEffect();

            OnFreeze?.Invoke();
            _ballsManager.InvokeActionOnBall<Ball>(ball => ball.BallMove.FreezeMove());
        }

        private void EndFreeze()
        {
            IsEffectActive = false;

            if (_frostEffect != null)
            {
                _frostEffect.DestroyEffect();
                _frostEffect = null;
            }

            _ballsManager.InvokeActionOnBall<Ball>(ball => ball.BallMove.StartMove());
        }
       
    }
}