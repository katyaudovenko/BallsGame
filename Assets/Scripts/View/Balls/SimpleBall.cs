using Controller.SpawnLogic;

namespace View.Balls
{
    public class SimpleBall : Ball
    {
        private ProbabilityCoinSpawn _coinSpawn;
        private DestroyBall _destroyAnimation;
        public override void OnInitialize()
        {
            base.OnInitialize();

            _destroyAnimation = GetComponent<DestroyBall>();
            _destroyAnimation.Initialize();
            
            _coinSpawn = GetComponent<ProbabilityCoinSpawn>();
            _coinSpawn.Initialize(BallType.SimpleBall);
        }
        
        private void OnMouseDown() => DestroyBallByUser();

        public override void OnReset()
        {
            base.OnReset();
            _destroyAnimation.ResetAnimation();
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