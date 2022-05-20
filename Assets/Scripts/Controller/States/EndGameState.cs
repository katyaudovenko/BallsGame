using Services;
using UnityEngine;

namespace Controller.States
{
    public class EndGameState : State
    {
        private readonly HealthService _healthService;

        public EndGameState(StateMachine stateMachine) : base(stateMachine)
        {
            _healthService = ServiceLocator.Instance.GetService<HealthService>();
            _healthService.OnChanged += OnHealthChanged;
        }

        private void OnHealthChanged()
        {
            if(_healthService.Health == 0)
            {
                Debug.Log("Health end");
                _stateMachine.ChangeState<EndGameState>();
            }
        }

        public override void Enter()
        {
            base.Enter();
            SaveData();
        }

        private void SaveData()
        {
            var progress = ServiceLocator.Instance.GetService<ProgressService>();
            progress.Save();
        }
    }
}