using View.Balls.Abstract;

namespace View.Balls.Behaviour
{
    public class SimpleBall : Ball
    {
        private void OnMouseDown() => DestroyBallByUser();

        protected override void OnBallDestroy()
        {
            BallDestroyBehaviour.OnDestroyBall(this);
        }
    }
}