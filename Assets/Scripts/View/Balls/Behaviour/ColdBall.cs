using View.Balls.Abstract;
using View.Balls.Components;

namespace View.Balls.Behaviour
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

        protected override void OnBallDestroy() => BallDestroyBehaviour.OnDestroyBall(this);
    }
}