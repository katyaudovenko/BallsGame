using Services;

namespace View.Balls
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
            Pool.ReturnElement(this);
        }
    }
}