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
        }

        private void Update()
        {
            if (!_isPressed) return;
            _currentTime -= Time.deltaTime;
            if (_currentTime <= 0) 
                DestroyBallByUser();
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

        public override void DestroyBallByUser() => 
            BallDestroyBehaviour.OnDestroyBallByUser(this);

        protected override void OnBallDestroy() => 
            BallDestroyBehaviour.OnDestroyBall(this);
    }
}