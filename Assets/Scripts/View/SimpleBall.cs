namespace View
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
        }
    }
}