using Test.Application;

namespace Test
{
    public class MainMenuViewModel : IMainMenuViewModel
    {
        private readonly Router _router;

        #region Ctor

        public MainMenuViewModel(Router router)
        {
            _router = router;
        }

        #endregion

        public void StartGame()
        {
            _router.EnterState<GameplayState>();
        }

        public void OpenMarket()
        {
            _router.EnterState<MarketState>();
        }

        public void OpenPlayerSettings()
        {
            _router.EnterState<PlayerSettingsState>();
        }
    }
}