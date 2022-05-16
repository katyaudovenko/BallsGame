using Controller.SpawnLogic;
using Services;
using UnityEngine;
using View.Balls;


namespace Controller.States
{
    public class RegisterState : State
    {
        private const string FreezeContainerPath = "Prefabs/FreezeService";
        private const int HealthCount = 3;
        public RegisterState(StateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();
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
            ServiceLocator.Instance.Register(new HealthService(HealthCount));
        }

        private void RegisterFreezeService()
        {
            var prefab = Resources.Load<FreezeService>(FreezeContainerPath);
            var service = Object.Instantiate(prefab);
            ServiceLocator.Instance.Register(service);
        }
    }
}