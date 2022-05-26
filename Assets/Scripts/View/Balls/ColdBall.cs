using Services;

namespace View.Balls
{
    public class ColdBall : Ball
    {
        private RotateBall _rotateAnimation;
        public override void OnInitialize()
        {
            base.OnInitialize();
            _rotateAnimation = GetComponent<RotateBall>();
        }

        public override void OnSetup()
        {
            base.OnSetup();
            _rotateAnimation.StartAnimation();
            FreezeService.OnFreeze += _rotateAnimation.StopAnimation;
        }

        private void OnMouseDown()
        {
            FreezeService.StartFreeze();
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
            Pool.ReturnElement(this);
        }
            
    }
}