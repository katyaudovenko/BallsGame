using Controller.SpawnLogic;
using Model;
using Services;
using UnityEngine;
using View.Balls;


namespace Controller.States
{
    public class RegisterState : State
    {
        private const string FreezeContainerPath = "Prefabs/FreezeService";
        private const string HealthInfoPath = "Config/HealthInfo";
        
        private HealthInfo _healthInfo;
        
        public RegisterState(StateMachine stateMachine) : base(stateMachine) { }

        public override void Enter()
        {
            base.Enter();
            _healthInfo = Resources.Load<HealthInfo>(HealthInfoPath);
            RegisterServices();
            _stateMachine.ChangeState<LoadDataState>();
        }
        
        private void RegisterServices()
        {
            ServiceLocator.Instance.Register(new ScoreService());
            ServiceLocator.Instance.Register(new CoinsService());
            var ballsManager = ServiceLocator.Instance.Register(new BallsManager());
            RegisterFreezeService();
            ServiceLocator.Instance.Register(new DetonateService(ballsManager));
            ServiceLocator.Instance.Register(new GameFactory());
            ServiceLocator.Instance.Register(new HealthService(_healthInfo.HealthCount));
        }

        private void RegisterFreezeService()
        {
            var prefab = Resources.Load<FreezeService>(FreezeContainerPath);
            var service = Object.Instantiate(prefab);
            ServiceLocator.Instance.Register(service);
        }
    }
}