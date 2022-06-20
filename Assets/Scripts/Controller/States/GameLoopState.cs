using Controller.States.Base;

namespace Controller.States
{
    public class GameLoopState : State, IState
    {
        public GameLoopState(StateMachine stateMachine) : base(stateMachine)
        {
        }

        public void Enter() => 
            GlobalEventManager.OnStartGame();

        public void Exit() { }
    }
}