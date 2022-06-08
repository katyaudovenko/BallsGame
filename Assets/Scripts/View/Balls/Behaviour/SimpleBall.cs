using View.Balls.Abstract;

namespace View.Balls.Behaviour
{
    public class SimpleBall : Ball
    {
        private void OnMouseDown() =>DestroyBallByUser();

        public override void DestroyBallByUser() => 
            BallDestroyBehaviour.OnDestroyBallByUser(this);

        protected override void OnBallDestroy() => 
            BallDestroyBehaviour.OnDestroyBall(this);
    }
}