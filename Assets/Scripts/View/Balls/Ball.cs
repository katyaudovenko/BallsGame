using Controller.Pool;
using Services;


namespace View.Balls
{
    public abstract class Ball : PoolObject, IPoolBehaviour
    {
        private const int BasicNumberScore = 1;
        
        private BallsManager _ballsManager;
        private ScoreService _scoreService;
        private CoinsService _coinsService;

        protected PoolContainer Pool;
        protected FreezeService FreezeService;
        
        protected int CostBall { get; set; }
        public BallMove BallMove { get; private set; }

        public void SetupPool(PoolContainer pool)
        {
            Pool = pool;
        }
        
        public virtual void OnInitialize()
        {
            BallMove = GetComponent<BallMove>();
            FreezeService = ServiceLocator.Instance.GetService<FreezeService>();
            _scoreService = ServiceLocator.Instance.GetService<ScoreService>();
            _ballsManager = ServiceLocator.Instance.GetService<BallsManager>();
            _coinsService = ServiceLocator.Instance.GetService<CoinsService>();
        }

        public void DestroyBallByUser()
        {
           _scoreService.AddScore(BasicNumberScore);
           _coinsService.AddCoin(CostBall);
           DestroyBall();
        }
        public void DestroyBall()
        {
            _ballsManager.RemoveBall(this);
            OnBallDestroy();
        }
        
        public virtual void OnSetup() { }

        public virtual void OnReset() { }
        
        protected abstract void OnBallDestroy();
    }
}