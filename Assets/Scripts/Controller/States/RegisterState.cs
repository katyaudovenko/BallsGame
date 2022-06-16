using Controller.SpawnLogic;
using Model.Infos;
using Services;
using Services.ServiceLocator;
using UnityEngine;


namespace Controller.States
{
    public class RegisterState : State
    {
        private const string FreezeContainerPath = "Prefabs/FreezeService";
        private const string WindowsCanvasPath = "Prefabs/WindowCanvas";

        public RegisterState(StateMachine stateMachine) : base(stateMachine)
        {
            RegisterServices();
        }

        public override void Enter()
        {
            base.Enter();
            InitializeServices();
            _stateMachine.ChangeState<LoadDataState>();
        }

        private void InitializeServices()
        {
            ServiceLocator.Instance.GetService<GameFactory>().Initialize();
            ServiceLocator.Instance.GetService<WindowsManager>().Initialize();
        }

        private void RegisterServices()
        {
            var config = ServiceLocator.Instance.Register(new ConfigService());

            ServiceLocator.Instance.Register(new ProgressService());
            ServiceLocator.Instance.Register(new BallsManager());
            ServiceLocator.Instance.Register(new GameFactory());
            
            RegisterScoreService();
            RegisterWindowsManager();
            RegisterCoinsService();
            RegisterDetonateService();
            RegisterHealthService(config);
            RegisterFreezeService();
        }

        private void RegisterScoreService()
        {
            var progress = ServiceLocator.Instance.GetService<ProgressService>();
            ServiceLocator.Instance.Register(new ScoreService(progress));
        }

        private void RegisterWindowsManager()
        {
            var windowsCanvasPrefab = Resources.Load<GameObject>(WindowsCanvasPath);
            var windowsCanvas = Object.Instantiate(windowsCanvasPrefab);
            var windowsManager = windowsCanvas.GetComponentInChildren<WindowsManager>();
            ServiceLocator.Instance.Register(windowsManager);
        }
        
        private void RegisterCoinsService()
        {
            var progressService = ServiceLocator.Instance.GetService<ProgressService>();
            ServiceLocator.Instance.Register(new CoinsService(progressService));
        }

        private void RegisterFreezeService()
        {
            var prefab = Resources.Load<FreezeService>(FreezeContainerPath);
            var service = Object.Instantiate(prefab);
            var freezeInfo = ServiceLocator.Instance.GetService<ConfigService>().GetConfig<FreezeInfo>();
            var ballsManager = ServiceLocator.Instance.GetService<BallsManager>();
            var gameFactory = ServiceLocator.Instance.GetService<GameFactory>();
            service.Construct(ballsManager, freezeInfo, gameFactory);
            ServiceLocator.Instance.Register(service);
        }

        private void RegisterDetonateService()
        {
            var ballsManager = ServiceLocator.Instance.GetService<BallsManager>();
            var info = ServiceLocator.Instance.GetService<ConfigService>().GetConfig<DetonateInfo>();
            ServiceLocator.Instance.Register(new DetonateService(ballsManager, info));
        }

        private void RegisterHealthService(ConfigService config)
        {
            var healthInfo = config.GetConfig<HealthInfo>();
            ServiceLocator.Instance.Register(new HealthService(healthInfo));
        }
    }
}