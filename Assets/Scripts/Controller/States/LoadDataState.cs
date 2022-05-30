using Services;
using Services.ServiceLocator;

namespace Controller.States
{
    public class LoadDataState : State
    {
        public LoadDataState(StateMachine stateMachine) : base(stateMachine)
        {

        }

        public override void Enter()
        {
            base.Enter();
            LoadData();
            _stateMachine.ChangeState<GameLoopState>();
        }

        private void LoadData()
        {
            var progress = ServiceLocator.Instance.GetService<ProgressService>();
            progress.Load();
        }
    }
}