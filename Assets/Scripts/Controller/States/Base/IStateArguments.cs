namespace Controller.States.Base
{
    public interface IStateArguments<in TArgument> : IExitableState
    {
        void Enter(TArgument argument);
    }
    
    public interface IStateArguments<in TArgument1, in TArgument2> : IExitableState
    {
        void Enter(TArgument1 argument1, TArgument2 argument2);
    }
}