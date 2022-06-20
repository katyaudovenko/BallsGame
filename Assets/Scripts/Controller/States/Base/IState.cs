namespace Controller.States.Base
{
    public interface IState : IExitableState
    {
        void Enter();
    }
}