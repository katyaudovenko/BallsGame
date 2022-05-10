using Controller.SpawnLogic;
using Services;
using UnityEngine;


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
            RegisterFreezeService();
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