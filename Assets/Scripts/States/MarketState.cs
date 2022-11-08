using Test.Meta;
using UnityEngine;

namespace Test.Application
{
    public class MarketState : State
    {
        private MarketViewBehaviour _marketViewBehaviour;
        private IMarketViewModel _marketViewModel;

        private TextReportViewBehaviour _playerInventoryViewBehaviour;
        private ITextReportViewModel _playerInventoryViewModel;

        private TextReportViewBehaviour _playerWalletViewBehaviour;
        private ITextReportViewModel _playerWalletViewModel;

        protected override void OnStateEnter()
        {
            var router = ServiceLocator.Instance.Resolve<Router>();
            var marketRepository = ServiceLocator.Instance.Resolve<IMarketRepository>();
            var playerRepository = ServiceLocator.Instance.Resolve<IPlayerRepository>();
            var market = marketRepository.Market;
            var player = playerRepository.Player;

            var purchasingService = new PurchasingService(player, market);
            var marketViewModelContext = new ViewModelContext
            {
                viewModelCtorArgs = new object[] { router, market, purchasingService }
            };


            (_marketViewBehaviour, _marketViewModel) =
                UISystem.CreateViewModel<MarketViewBehaviour, MarketViewModel>(marketViewModelContext);


            var playerWalletViewModelContext = new ViewModelContext
            {
                viewModelCtorArgs = new object[] { playerRepository.Player.Wallet }
            };

            (_playerWalletViewBehaviour, _playerWalletViewModel) =
                UISystem.CreateViewModel<TextReportViewBehaviour, PlayerWalletViewModel>(
                    playerWalletViewModelContext, _marketViewBehaviour.WidgetGroupFacade.transform,
                    new Vector2(-220, 90));

            //wtf
            _playerWalletViewBehaviour.HeaderText = "Player Wallet";

            var playerInventoryViewModelContext = new ViewModelContext
            {
                viewModelCtorArgs = new object[] { playerRepository.Player.Inventory }
            };

            (_playerInventoryViewBehaviour, _playerInventoryViewModel) =
                UISystem.CreateViewModel<TextReportViewBehaviour, PlayerInventoryViewModel>(
                    playerInventoryViewModelContext, _marketViewBehaviour.WidgetGroupFacade.transform,
                    new Vector2(-220, -160));

            //wtf
            _playerInventoryViewBehaviour.HeaderText = "Player Inventory";
        }

        protected override void OnStateExit()
        {
            UISystem.Release(_marketViewBehaviour);

            UISystem.Release(_playerWalletViewBehaviour);

            _playerWalletViewBehaviour = null;
            _playerWalletViewModel = null;

            _marketViewBehaviour = null;
            _marketViewModel = null;
        }
    }
}