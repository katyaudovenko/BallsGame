using View.Balls.Abstract;

namespace View.Balls.Behaviour
{
    public class ColdBall : Ball
    {
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