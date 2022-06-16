using Controller.Windows;
using Services;
using Services.ServiceLocator;

namespace Controller.States
{
    public class EndGameState : State
    {
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
                _stateMachine.ChangeState<EndGameState>();
        }

        public override void Enter()
        {
            base.Enter();
            SaveData();

            GlobalEventManager.OnEndGame();
            var endGameWindow = _windowsManager.OpenWindow<EndGameWindow>();
            endGameWindow.Setup(RestartGame);
        }

        private void RestartGame() => 
            _stateMachine.ChangeState<GameLoopState>();

        private void SaveData()
        {
            var progress = ServiceLocator.Instance.GetService<ProgressService>();
            progress.Save();
        }
    }
}