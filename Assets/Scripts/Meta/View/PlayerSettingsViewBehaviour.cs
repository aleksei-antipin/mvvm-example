using System.Collections;
using System.Collections.Generic;
using Test.MVVM;
using UnityEngine;

namespace Test.Meta
{
    public class PlayerSettingsViewBehaviour : ViewBehaviour<PlayerSettingsWidgetFacade, IPlayerSettingsViewModel>
    {
        
        

        public PlayerSettingsViewBehaviour(PlayerSettingsWidgetFacade facade, IPlayerSettingsViewModel viewModel) : base(facade, viewModel)
        {
        }
        
        protected override void OnInitialized()
        {
            WidgetGroupFacade.BackButton.onClick.AddListener(OnBackButtonPressed);
        }

        private void OnBackButtonPressed()
        {
            ViewModel.Back();
        }
        
    }

}
