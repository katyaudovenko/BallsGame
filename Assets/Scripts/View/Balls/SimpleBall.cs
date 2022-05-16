namespace View.Balls
{
    public class SimpleBall : Ball
    {
        public override void OnInitialize()
        {
            base.OnInitialize();
            CostBall = 1;
        }

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