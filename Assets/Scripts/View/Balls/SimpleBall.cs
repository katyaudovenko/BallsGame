using Controller;

namespace View.Balls
{
    public class SimpleBall : Ball
    {
        private void OnMouseDown()
        {
            DestroyBall();
        }
        public override void DestroyBall()
        {
            Pool.ReturnElement(this);
            GlobalEventManager.OnDestroyBall();
        }
    }
}