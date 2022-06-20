using System;
using Controller.States.Base;
using Controller.Windows;
using Services;
using Services.ServiceLocator;

namespace Controller.States
{
    public class EndGameState : State, IState
    {
        private const int MenuSceneIndex = 0;
        private readonly HealthService _healthService;
        private readonly WindowsManager _windowsManager;

        public EndGameState(StateMachine stateMachine) : base(stateMachine)
        {
            _healthService = ServiceLocator.Instance.GetService<HealthService>();
            _healthService.OnChanged += OnHealthChanged;

            _windowsManager = ServiceLocator.Instance.GetService<WindowsManager>();
        }

        private void OnHealthChanged()
        {
            if(_healthService.Health == 0) 
                StateMachine.ChangeState<EndGameState>();
        }

        public void Enter()
        {
            SaveData();

            GlobalEventManager.OnEndGame();
            var endGameWindow = _windowsManager.OpenWindow<EndGameWindow>();
            endGameWindow.Setup(RestartGame, ExitMenu);
        }

        private void ExitMenu()
        {
            StateMachine.ChangeState<LoadSceneState, int, Action>(MenuSceneIndex, () => StateMachine.ChangeState<MainMenuState>());
        }

        private void RestartGame() => 
            StateMachine.ChangeState<GameLoopState>();

        private void SaveData()
        {
            var progress = ServiceLocator.Instance.GetService<ProgressService>();
            progress.Save();
        }

        public void Exit() { }
    }
}