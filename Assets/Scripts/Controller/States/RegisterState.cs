using Controller.SpawnLogic;
using Model.Infos;
using Services;
using Services.ServiceLocator;
using UnityEngine;
using View.Balls;


namespace Controller.States
{
    public class RegisterState : State
    {
        private const string FreezeContainerPath = "Prefabs/FreezeService";

        public RegisterState(StateMachine stateMachine) : base(stateMachine)
        {
            RegisterServices();
        }

        public override void Enter()
        {
            base.Enter();
            _stateMachine.ChangeState<LoadDataState>();
        }
        
        private void RegisterServices()
        {
            var config = ServiceLocator.Instance.Register(new ConfigService());

            ServiceLocator.Instance.Register(new ProgressService());
            ServiceLocator.Instance.Register(new ScoreService());
            ServiceLocator.Instance.Register(new BallsManager());

            RegisterFreezeService();
            RegisterCoinsService();
            RegisterDetonateService();
            RegisterHealthService(config);
            
            ServiceLocator.Instance.Register(new GameFactory());
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
            service.Initialize(ballsManager, freezeInfo);
            ServiceLocator.Instance.Register(service);
        }

        private void RegisterDetonateService()
        {
            var ballsManager = ServiceLocator.Instance.GetService<BallsManager>();
            ServiceLocator.Instance.Register(new DetonateService(ballsManager));
        }

        private void RegisterHealthService(ConfigService config)
        {
            var healthInfo = config.GetConfig<HealthInfo>();
            ServiceLocator.Instance.Register(new HealthService(healthInfo));
        }
    }
}