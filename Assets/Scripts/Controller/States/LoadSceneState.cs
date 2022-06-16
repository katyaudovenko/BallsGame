using UnityEngine.SceneManagement;

namespace Controller.States
{
    public class LoadSceneState : State
    {
        public LoadSceneState(StateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();
            SceneManager.LoadScene(1);
        }
    }
}