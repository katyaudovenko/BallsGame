using View.Balls.Abstract;

namespace View.Balls.Behaviour
{
    public class ColdBall : Ball
    {
        private void OnMouseDown()
        {
            FreezeService.StartFreeze();
            OnBallDestroy();
        }
        
        protected override void OnBallDestroy() => 
            BallDestroyBehaviour.OnDestroyBall(this);

        public override void DestroyBallByUser() => 
            BallDestroyBehaviour.OnDestroyBallByUser(this);
    }
}