using Model.Infos;
using Services;
using Services.ServiceLocator;
using View.Balls.Abstract;

namespace View.Balls.Behaviour
{
    public class CompositeBall : Ball
    {
        private BallInfo _info;
        private int _livesCount;

        public override void OnInitialize()
        {
            base.OnInitialize();
            
            _info = ServiceLocator.Instance.GetService<ConfigService>().GetConfig<BallInfo>();
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
           BallDestroyBehaviour.OnDestroyBall(this);
        }
    }
}