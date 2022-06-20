using Controller.States.Base;
using Services;
using Services.ServiceLocator;

namespace Controller.States
{
    public class LoadDataState : State, IState
    {
        public LoadDataState(StateMachine stateMachine) : base(stateMachine)
        {

        }

        public void Enter()
        {
            LoadData();
        }

        private void LoadData()
        {
            var progress = ServiceLocator.Instance.GetService<ProgressService>();
            progress.Load();
        }

        public void Exit() { }
    }
}