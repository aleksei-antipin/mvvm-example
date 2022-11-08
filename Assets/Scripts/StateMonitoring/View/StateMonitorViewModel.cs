using DM.NotifierTypes;
using Test.Application;

namespace Test.Application
{
    public class StateMonitorViewModel : IStateMonitorViewModel
    {
        private readonly NotifierProperty<State> _currentState = new();
        private readonly Router _router;

        #region Ctor

        public StateMonitorViewModel(Router router)
        {
            _router = router;
            _currentState.Value = _router.CurrentState;
            _router.StateChanged += () => _currentState.Value = _router.CurrentState;
        }

        #endregion

        public INotifierPropertyReadonly<State> CurrentState => _currentState;
    }
}