namespace Controller.States.Base
{
    public abstract class State
    {
        protected readonly StateMachine StateMachine;

        protected State(StateMachine stateMachine)
        {
            StateMachine = stateMachine;
        }
    }
}