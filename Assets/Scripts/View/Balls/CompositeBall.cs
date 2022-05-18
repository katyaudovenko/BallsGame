using Model;
using Services;

namespace View.Balls
{
    public class CompositeBall : Ball
    {
        private BallInfo _info;
        private int _livesCount;

        public override void OnInitialize()
        {
            base.OnInitialize();
            _info = ConfigService.Instance.GetConfig<BallInfo>();
            CostBall = 2;
        }

        public override void OnSetup()
        {
            base.OnSetup();
            _livesCount = _info.LivesCountCompositeBall;
        }
        
        private void OnMouseDown()
        {
            Damage();
        }
        
        private void Damage()
        {
            _livesCount--;
            if (_livesCount <= 0) 
                DestroyBallByUser();
        }
        protected override void OnBallDestroy()
        {
            Pool.ReturnElement(this);
        }
        
    }
}