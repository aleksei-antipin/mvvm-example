using Test.Meta;
using UnityEngine;

namespace Test.Infrastructure
{
    public class PlayerSettingsState : State
    {
        private PlayerSettingsViewBehaviour _playerSettingsViewBehaviour;
        private PlayerSettingsViewModel _playerSettingsViewModel;
        private PlayerSettingsWidgetFacade _playerSettingsWidgetFacade;

        protected override void OnStateEnter()
        {
            var router = ServiceLocator.Instance.Resolve<Router>();

            _playerSettingsWidgetFacade = UISystem.InstantiateWidget<PlayerSettingsWidgetFacade>();
            _playerSettingsViewModel = new PlayerSettingsViewModel(router);
            _playerSettingsViewBehaviour = new PlayerSettingsViewBehaviour(_playerSettingsWidgetFacade, _playerSettingsViewModel);
            _playerSettingsViewBehaviour.Initialize();
        }

        protected override void OnStateExit()
        {
            _playerSettingsViewBehaviour = null;
            _playerSettingsViewModel = null;
            Object.Destroy(_playerSettingsWidgetFacade.gameObject);
        }
    }
}