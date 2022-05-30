using Controller.SpawnLogic;
using Model;
using Services;
using UnityEngine;

namespace View.Balls
{
    public class HeavyBall : Ball
    {
        private BallInfo _info;
        private float _currentTime;
        private bool _isPressed;
        private ProbabilityCoinSpawn _coinSpawn;
        

        public override void OnInitialize()
        {
            base.OnInitialize();
            _coinSpawn = GetComponent<ProbabilityCoinSpawn>();
            _info = _info = ServiceLocator.Instance.GetService<ConfigService>().GetConfig<BallInfo>();
            _coinSpawn.Initialize(BallType.HeavyBall);
        }

        public override void OnSetup()
        {
            base.OnSetup();
            OnDestroy += _coinSpawn.SpawnCoin;
            _currentTime = _info.TimeLifeHeavyBall;
            _isPressed = false;
        }

        private void Update()
        {
            if (_isPressed)
            {
                _currentTime -= Time.deltaTime;
                if (_currentTime <= 0) 
                    DestroyBallByUser();
            }
        }

        private void OnMouseDown()
        {
            _isPressed = true;
            BallMove.StopMove();
        }

        private void OnMouseUp()
        {
            _isPressed = false;
            BallMove.StartMove();
        }

        public override void OnReset()
        {
            base.OnReset();
            OnDestroy -= _coinSpawn.SpawnCoin;
        }

        protected override void OnBallDestroy()
        {
            Pool.ReturnElement(this);
        }
    }
}