using Model.Infos;
using Services;
using Services.ServiceLocator;
using UnityEngine;
using View.Balls.Abstract;

namespace View.Balls.Behaviour
{
    public class HeavyBall : Ball
    {
        private BallInfo _info;
        private bool _markToDestroy;
        private float _currentTime;
        private bool _isPressed;


        public override void OnInitialize()
        {
            base.OnInitialize();
            
            _info = ServiceLocator.Instance.GetService<ConfigService>().GetConfig<BallInfo>();
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
        
        protected override void OnBallDestroy()
        {
            BallDestroyBehaviour.OnDestroyBall(this);
            _markToDestroy = true;
        }
    }
}