using Services;
using Services.ServiceLocator;
using View.Balls.Abstract;
using View.Balls.Components;

namespace View.Balls.Behaviour
{
    public class BombBall : Ball
    {
        private DetonateService _detonateService;
        private RotateBall _rotateAnimation;
        public override void OnInitialize()
        {
            base.OnInitialize();
            _detonateService = ServiceLocator.Instance.GetService<DetonateService>();
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
            _detonateService.PlanDetonate(transform.position);
            BallDestroyBehaviour.OnDestroyBall(this);
        }

        public override void DestroyBallByUser() => 
            OnBallDestroy();
    }
}