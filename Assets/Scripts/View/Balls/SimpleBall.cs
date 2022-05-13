namespace View.Balls
{
    public class SimpleBall : Ball
    {
        private void OnMouseDown()
        {
            DestroyBallByUser();
        }
        protected override void OnBallDestroy()
        {
            Pool.ReturnElement(this);
        }
    }
}