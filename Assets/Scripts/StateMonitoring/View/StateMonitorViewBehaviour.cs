using Test.Infrastructure;
using Test.MVVM;

namespace Test.States
{
    public class StateMonitorViewBehaviour : ViewBehaviour<StateMonitoringWidgetFacade, IStateMonitorViewModel>
    {
        public StateMonitorViewBehaviour(StateMonitoringWidgetFacade facade, IStateMonitorViewModel viewModel) : base(
            facade, viewModel)
        {
        }

        protected override void OnInitialized()
        {
            WidgetGroupFacade.Message = ViewModel.CurrentState.Value.GetType().Name;
            ViewModel.CurrentState.OnValueChanged += (sender, arg) =>
            {
                WidgetGroupFacade.Message = arg.Value.GetType().Name;
            };
        }
    }
}