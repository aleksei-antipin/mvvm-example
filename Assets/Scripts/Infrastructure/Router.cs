using System;
using System.Collections.Generic;

namespace Test.Infrastructure
{
    public class Router
    {
        private readonly Dictionary<Type, State> _states = new();

        public State CurrentState { get; private set; }

        public event Action StateChanged;

        public bool TryAddState(State state)
        {
            return _states.TryAdd(state.GetType(), state);
        }

        public void EnterState<T>()
        {
            if (_states.TryGetValue(typeof(T), out var state)) EnterState(state);
        }

        private void EnterState(State state)
        {
            CurrentState?.Exit();
            CurrentState = state;
            CurrentState?.Enter();
            StateChanged?.Invoke();
        }
    }
}