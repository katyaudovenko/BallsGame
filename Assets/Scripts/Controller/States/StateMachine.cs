using System;
using System.Collections.Generic;
using Controller.States.Base;
using Services.ServiceLocator;
using UnityEngine;

namespace Controller.States
{
    public class StateMachine : IService
    {
        private IExitableState _currentState;
        private readonly Dictionary<Type, IExitableState> _statesMap = new Dictionary<Type, IExitableState>();

        public StateMachine()
        {
            InitializeStateMap();
        }
        private void InitializeStateMap()
        {
            _statesMap.Add(typeof(RegisterState), new RegisterState(this));
            _statesMap.Add(typeof(LoadDataState), new LoadDataState(this));
            _statesMap.Add(typeof(MainMenuState), new MainMenuState(this));
            _statesMap.Add(typeof(LoadSceneState), new LoadSceneState(this));
            _statesMap.Add(typeof(GameLoopState), new GameLoopState(this));
            _statesMap.Add(typeof(EndGameState), new EndGameState(this));
        }

        public void ChangeState<T>() where T : IExitableState
        {
            if (_currentState is T) return;
            var type = typeof(T);
            _currentState?.Exit();
            _currentState = _statesMap[type];
            if (_currentState is IState state)
                state.Enter();
            else
                Debug.LogError($"State {nameof(T)} isn't inherited from {nameof(IState)}");
        }
        
        public void ChangeState<T, U>(U argument) where T : IExitableState
        {
            if (_currentState is T) return;
            var type = typeof(T);
            _currentState?.Exit();
            _currentState = _statesMap[type];
            if (_currentState is IStateArguments<U> state)
                state.Enter(argument);
            else
                Debug.LogError($"State {nameof(T)} isn't inherited from {nameof(IStateArguments<U>)}");
        }
        
        public void ChangeState<T, U1, U2>(U1 argument1, U2 argument2) where T : IExitableState
        {
            if (_currentState is T) return;
            var type = typeof(T);
            _currentState?.Exit();
            _currentState = _statesMap[type];
            if (_currentState is IStateArguments<U1, U2> state)
                state.Enter(argument1, argument2);
            else
                Debug.LogError($"State {nameof(T)} isn't inherited from {nameof(IStateArguments<U1, U2>)}");
        }
    }
}