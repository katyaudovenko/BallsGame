using Controller.SpawnLogic;
using Model.Infos;
using Services;
using Services.ServiceLocator;

namespace View.Balls
{
    public class CompositeBall : Ball
    {
        private BallInfo _info;
        private ProbabilityCoinSpawn _coinSpawn;
        private DestroyBall _destroyAnimation;
        private int _livesCount;

        public override void OnInitialize()
        {
            base.OnInitialize();
            
            _info = ServiceLocator.Instance.GetService<ConfigService>().GetConfig<BallInfo>();

            _coinSpawn = GetComponent<ProbabilityCoinSpawn>();
            _coinSpawn.Initialize(BallType.CompositeBall);
            
            _destroyAnimation = GetComponent<DestroyBall>();
            _destroyAnimation.Initialize();
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
            _destroyAnimation.StartAnimation(() =>
            {
                Pool.ReturnElement(this);
                _coinSpawn.SpawnCoin();
            });
        }
    }
}