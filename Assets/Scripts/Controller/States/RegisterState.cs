using Controller.SpawnLogic;
using Model;
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
            ServiceLocator.Instance.Register(new ProgressService());
            ServiceLocator.Instance.Register(new ScoreService());
            ServiceLocator.Instance.Register(new CoinsService());
            var config = ServiceLocator.Instance.Register(new ConfigService());
            var ballsManager = ServiceLocator.Instance.Register(new BallsManager());
            RegisterFreezeService();
            ServiceLocator.Instance.Register(new DetonateService(ballsManager));
            ServiceLocator.Instance.Register(new GameFactory());
            var healthInfo = config.GetConfig<HealthInfo>();
            ServiceLocator.Instance.Register(new HealthService(healthInfo.HealthCount));
        }

        private void RegisterFreezeService()
        {
            var prefab = Resources.Load<FreezeService>(FreezeContainerPath);
            var service = Object.Instantiate(prefab);
            ServiceLocator.Instance.Register(service);
        }
    }
}