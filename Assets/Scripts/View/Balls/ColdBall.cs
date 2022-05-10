namespace View.Balls
{
    public class ColdBall : Ball
    {
        private void OnMouseDown()
        {
            FreezeService.StartFreeze();
            DestroyBall();
        }
        
        public override void DestroyBall()
        {
            Pool.ReturnElement(this);
        }
    }
}