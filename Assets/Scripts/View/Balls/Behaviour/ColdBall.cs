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
        }
        
        public override void OnReset()
        {
            base.OnReset();
            _rotateAnimation.ResetAnimation();
        }
        
        private void OnMouseDown() => 
            DestroyBallByUser();

        protected override void OnBallDestroy() => 
            BallDestroyBehaviour.OnDestroyBall(this);

        public override void DestroyBallByUser()
        {
            FreezeService.StartFreeze();
            BallDestroyBehaviour.OnDestroyBallByUser(this);
        }
    }
}