using Controller.States;
using UnityEngine;

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

        private void StartStateMachine()
        {
            _stateMachine = new StateMachine();
            _stateMachine.ChangeState<RegisterState>();
        }
    }
}