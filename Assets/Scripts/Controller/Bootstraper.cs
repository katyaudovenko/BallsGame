using System;
using Controller.States;
using UnityEngine;

namespace Controller
{
    public class Bootstraper : MonoBehaviour
    {
        private StateMachine _stateMachine;

        private void Awake()
        {
            _stateMachine = new StateMachine();
            _stateMachine.ChangeState<BootstrapState>();
        }
    }
}