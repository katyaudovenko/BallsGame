using System;
using Controller.States.Base;

namespace Controller.States
{
    public class MainMenuState : State, IState
    {
        private const int GameSceneIndex = 1;

        public MainMenuState(StateMachine stateMachine) : base(stateMachine) => 
            GlobalEventManager.MainMenuPlayClick += StartGameScene;

        private void StartGameScene() => 
            StateMachine.ChangeState<LoadSceneState, int, Action>(GameSceneIndex, 
                () => StateMachine.ChangeState<GameLoopState>());

        public void Enter() { }

        public void Exit() { }
    }
}