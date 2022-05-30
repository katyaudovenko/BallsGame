using Controller.SpawnLogic;
using Model;
using Services;

namespace View.Balls
{
    public class CompositeBall : Ball
    {
        private BallInfo _info;
        private int _livesCount;
        private ProbabilityCoinSpawn _coinSpawn;

        public override void OnInitialize()
        {
            base.OnInitialize();
            _coinSpawn = GetComponent<ProbabilityCoinSpawn>();
            _info = ServiceLocator.Instance.GetService<ConfigService>().GetConfig<BallInfo>();
            _coinSpawn.Initialize(BallType.CompositeBall);
        }

        public override void OnSetup()
        {
            base.OnSetup();
            _livesCount = _info.LivesCountCompositeBall;
            OnDestroy += _coinSpawn.SpawnCoin;
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

        public override void OnReset()
        {
            base.OnReset();
            OnDestroy -= _coinSpawn.SpawnCoin;
        }

        protected override void OnBallDestroy()
        {
            Pool.ReturnElement(this);
        }
        
    }
}