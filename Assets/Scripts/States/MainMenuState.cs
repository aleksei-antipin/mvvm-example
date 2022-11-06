using Test.Infrastructure;

namespace Test.States
{
    public class MainMenuState : State
    {
        private MainMenuViewBehaviour _mainMenuViewBehaviour;

        private MainMenuViewModel _mainMenuViewModel;

        protected override void OnStateEnter()
        {
            var router = ServiceLocator.Instance.Resolve<Router>();
            var context = new ViewModelGenerationContext
            {
                viewModelArgs = new object[] { router }
            };

            (_mainMenuViewBehaviour, _mainMenuViewModel) =
                UISystem.CreateViewModel<MainMenuViewBehaviour, MainMenuViewModel>(context);
        }

        protected override void OnStateExit()
        {
            UISystem.Release(_mainMenuViewBehaviour);
            _mainMenuViewBehaviour = null;
            _mainMenuViewModel = null;
        }
    }
}