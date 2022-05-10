using Controller.SpawnLogic;
using Services;
using View;

namespace Controller.States
{
    public class BootstrapState : State
    {
        public BootstrapState(StateMachine stateMachine) : base(stateMachine)
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
            ServiceLocator.Instance.Register(new GameFactory());
            ServiceLocator.Instance.Register(new HealthService());
        }
        
    }
}