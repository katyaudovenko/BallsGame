using Controller.SpawnLogic;

namespace View.Balls
{
    public class SimpleBall : Ball
    {
        private ProbabilityCoinSpawn _coinSpawn;
        public override void OnInitialize()
        {
            base.OnInitialize();
            _coinSpawn = GetComponent<ProbabilityCoinSpawn>();
            _coinSpawn.Initialize(BallType.SimpleBall);
        }

        public override void OnSetup()
        {
            base.OnSetup();
            OnDestroy += _coinSpawn.SpawnCoin;
        }

        private void OnMouseDown() => DestroyBallByUser();

        public override void OnReset()
        {
            base.OnReset();
            OnDestroy -= _coinSpawn.SpawnCoin;
        }

        protected override void OnBallDestroy() => Pool.ReturnElement(this);
    }
}