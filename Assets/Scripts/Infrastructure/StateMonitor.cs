using Test.Infrastructure;

namespace Test.States
{
    public class StateMonitor
    {
        private Router _router;
        private StateMonitoringWidgetFacade _stateMonitoringWidgetFacade;

        private StateMonitorViewBehaviour _stateMonitorViewBehaviour;
        private IStateMonitorViewModel _stateMonitorViewModel;

        public void Initialize()
        {
            _router = ServiceLocator.Instance.Resolve<Router>();
            _stateMonitoringWidgetFacade = UISystem.InstantiateWidget<StateMonitoringWidgetFacade>();
            _stateMonitorViewModel = new StateMonitorViewModel(_router);
            _stateMonitorViewBehaviour =
                new StateMonitorViewBehaviour(_stateMonitoringWidgetFacade, _stateMonitorViewModel);
            _stateMonitorViewBehaviour.Initialize();
        }
    }
}