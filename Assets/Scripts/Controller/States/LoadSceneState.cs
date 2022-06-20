using System;
using Controller.States.Base;
using UnityEngine.SceneManagement;

namespace Controller.States
{
    public class LoadSceneState : State, IStateArguments<int, Action>
    {
        public LoadSceneState(StateMachine stateMachine) : base(stateMachine)
        {
        }
        
        public void Enter(int sceneIndexId, Action onComplete)
        {
            var loadSceneAsync = SceneManager.LoadSceneAsync(sceneIndexId);
            loadSceneAsync.completed += _ => onComplete?.Invoke();
        }

        public void Exit() { }
    }
}