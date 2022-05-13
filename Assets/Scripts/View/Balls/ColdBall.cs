using Services;

namespace View.Balls
{
    public class ColdBall : Ball
    {
        private void OnMouseDown()
        {
            FreezeService.StartFreeze();
            DestroyBallByUser();
        }

        protected override void OnBallDestroy()
        {
            Pool.ReturnElement(this);
        }
            
    }
}