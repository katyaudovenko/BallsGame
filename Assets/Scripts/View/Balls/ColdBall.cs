using Services;

namespace View.Balls
{
    public class ColdBall : Ball
    {
        private FreezeService _freeze;

        public override void OnInitialize()
        {
            base.OnInitialize();
            _freeze = ServiceLocator.Instance.GetService<FreezeService>();
        }

        private void OnMouseDown()
        {
            _freeze.StartFreeze();
            DestroyBallByUser();
        }

        protected override void OnBallDestroy()
        {
            Pool.ReturnElement(this);
        }
            
    }
}