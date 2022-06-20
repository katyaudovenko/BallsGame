using Controller.States;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Controller
{
    public class Bootstraper : MonoBehaviour
    {
        private static Bootstraper _instance;
        
        private StateMachine _stateMachine;

        private void Awake()
        {
            if (_instance != null)
            {
                Destroy(this);
                return;
            }

            _instance = this;
            
            StartStateMachine();
            DontDestroyOnLoad(this);
        }

        private void Start() => 
            StartGame();

        private void StartStateMachine()
        {
            _stateMachine = new StateMachine();
            _stateMachine.ChangeState<RegisterState>();
        }

        private void StartGame()
        {
            var sceneIndex = SceneManager.GetActiveScene().buildIndex;
            switch (sceneIndex)
            {
                case 0:
                    _stateMachine.ChangeState<MainMenuState>();
                    break;
                case 1:
                    _stateMachine.ChangeState<GameLoopState>();
                    break;
            }
        }
    }
}