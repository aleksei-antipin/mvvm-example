using Test.Infrastructure;
using Test.States;

namespace Test.Meta
{
    public class PlayerSettingsViewModel : IPlayerSettingsViewModel
    {
        private readonly Router _router;

        #region Ctor

        public PlayerSettingsViewModel(Router router)
        {
            _router = router;
        }

        #endregion

        public void Back()
        {
            _router.EnterState<MainMenuState>();
        }
    }
}