using Controller.SpawnLogic;
using Services;
using Services.ServiceLocator;
using View.Balls.Abstract;
using View.Balls.Components;

namespace View.Balls.Behaviour
{
    public class BombBall : Ball
    {
        private GameFactory _gameFactory;
        private DetonateService _detonateService;
        private RotateBall _rotateAnimation;
        public override void OnInitialize()
        {
            base.OnInitialize();
            _detonateService = ServiceLocator.Instance.GetService<DetonateService>();
            _gameFactory = ServiceLocator.Instance.GetService<GameFactory>();
            _rotateAnimation = GetComponent<RotateBall>();
        }

        public override void OnSetup()
        {
            base.OnSetup();
            FreezeService.OnFreeze += _rotateAnimation.StopAnimation;
            _rotateAnimation.StartAnimation();
        }

        private void OnMouseDown()
        {
            DestroyBallByUser();
        }

        public override void OnReset()
        {
            base.OnReset();
            FreezeService.OnFreeze -= _rotateAnimation.StopAnimation;
            _rotateAnimation.ResetAnimation();
        }

        protected override void OnBallDestroy()
        {
            var position = transform.position;
            _detonateService.PlanDetonate(position);
            _gameFactory.CreateExplosionEffect(position);
            BallDestroyBehaviour.OnDestroyBall(this);
        }

        public override void DestroyBallByUser() => 
            OnBallDestroy();
    }
}