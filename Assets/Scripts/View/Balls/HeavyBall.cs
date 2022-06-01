using Controller.SpawnLogic;
using Model.Infos;
using Services;
using Services.ServiceLocator;
using UnityEngine;

namespace View.Balls
{
    public class HeavyBall : Ball
    {
        private bool _markToDestroy;
        
        private BallInfo _info;
        private ProbabilityCoinSpawn _coinSpawn;
        private DestroyBall _destroyAnimation;
        
        private float _currentTime;
        private bool _isPressed;


        public override void OnInitialize()
        {
            base.OnInitialize();
            _info = ServiceLocator.Instance.GetService<ConfigService>().GetConfig<BallInfo>();
            
            _coinSpawn = GetComponent<ProbabilityCoinSpawn>();
            _coinSpawn.Initialize(BallType.HeavyBall);

            _destroyAnimation = GetComponent<DestroyBall>();
            _destroyAnimation.Initialize();
        }

        public override void OnSetup()
        {
            base.OnSetup();
            
            _currentTime = _info.TimeLifeHeavyBall;
            _isPressed = false;
            _markToDestroy = false;
        }

        private void Update()
        {
            if(_markToDestroy) return;
            
            if (_isPressed)
            {
                _currentTime -= Time.deltaTime;
                if (_currentTime <= 0) 
                    DestroyBallByUser();
            }
        }

        private void OnMouseDown()
        {
            if (_markToDestroy) return;
            
            _isPressed = true;
            BallMove.StopMove();
        }

        private void OnMouseUp()
        {
            if(_markToDestroy) return;
            
            _isPressed = false;
            BallMove.StartMove();
        }

        public override void OnReset()
        {
            base.OnReset();
            _destroyAnimation.ResetAnimation();
        }

        protected override void OnBallDestroy()
        {
            _destroyAnimation.StartAnimation(() =>
            {
                Pool.ReturnElement(this);
                _coinSpawn.SpawnCoin();
            });
            _markToDestroy = true;
        }
    }
}