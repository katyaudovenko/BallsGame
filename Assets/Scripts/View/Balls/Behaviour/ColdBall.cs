using View.Balls.Abstract;

namespace View.Balls.Behaviour
{
    public class ColdBall : Ball
    {
        private void OnMouseDown()
        {
            FreezeService.StartFreeze();
            DestroyBallByUser();
        }
        
        protected override void OnBallDestroy() => BallDestroyBehaviour.OnDestroyBall(this);
    }
}