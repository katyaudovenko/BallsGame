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
        }

        private void RegisterServices()
        {
            
        }
        
    }
}