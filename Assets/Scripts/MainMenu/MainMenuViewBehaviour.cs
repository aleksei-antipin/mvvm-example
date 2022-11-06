using Test.MVVM;
using Test.View;
using UnityEngine;

namespace Test
{
    public class MainMenuViewBehaviour : ViewBehaviour<MainMenuWidgetFacade, IMainMenuViewModel>
    {
        public MainMenuViewBehaviour(MainMenuWidgetFacade facade, IMainMenuViewModel viewModel) : base(facade,
            viewModel)
        {
        }

        protected override void OnInitialized()
        {
            WidgetGroupFacade.GameButton.onClick.AddListener(OnGameButtonPressed);
            WidgetGroupFacade.PlayerButton.onClick.AddListener(OnPlayerSettingsButtonPressed);
            WidgetGroupFacade.MarketButton.onClick.AddListener(OnMarketButtonPressed);
        }

        protected override void OnDeactivate()
        {
        
        }

        private void OnGameButtonPressed()
        {
            ViewModel.StartGame();
        }

        private void OnPlayerSettingsButtonPressed()
        {
            ViewModel.OpenPlayerSettings();
        }

        private void OnMarketButtonPressed()
        {
            ViewModel.OpenMarket();
        }
    }
}