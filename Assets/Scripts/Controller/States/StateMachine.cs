using System;
using System.Collections.Generic;

namespace Controller.States
{
    public class StateMachine
    {
        private State _currentState;
        private readonly Dictionary<Type, State> _statesMap = new Dictionary<Type, State>();

        public StateMachine()
        {
            InitializeStateMap();
        }
        private void InitializeStateMap()
        {
            _statesMap.Add(typeof(RegisterState), new RegisterState(this));
            _statesMap.Add(typeof(LoadDataState), new LoadDataState(this));
            _statesMap.Add(typeof(GameLoopState), new GameLoopState(this));
        }

        public void ChangeState<T>() where T : State
        {
            if (_currentState is T) return;
            var type = typeof(T);
            _currentState?.Exit();
            _currentState = _statesMap[type];
            _currentState.Enter();
        }
        
    }
}