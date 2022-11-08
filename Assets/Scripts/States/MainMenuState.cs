using System;
using Test.Application;
using Test.Meta;

namespace Test.Application
{
    public class MainMenuState : State
    {
        private MainMenuViewBehaviour _mainMenuViewBehaviour;

        private MainMenuViewModel _mainMenuViewModel;

        protected override void OnStateEnter()
        {
            var router = ServiceLocator.Instance.Resolve<Router>();
            var context = new ViewModelContext
            {
                viewModelCtorArgs = new object[] { router }
            };

            (_mainMenuViewBehaviour, _mainMenuViewModel) =
                UISystem.CreateViewModel<MainMenuViewBehaviour, MainMenuViewModel>(context);
        }

        protected override void OnStateExit()
        {
            UISystem.Release(_mainMenuViewBehaviour);
        }
    }
}