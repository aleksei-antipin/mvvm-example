using System.Collections.Generic;
using Test.Infrastructure;
using Test.States;

namespace Test.Meta
{
    public class MarketViewModel : IMarketViewModel
    {
        private readonly Router _router;

        private readonly Market _market;

        #region Ctor

        public MarketViewModel(Router router, Market market)
        {
            _router = router;
            _market = market;
        }

        #endregion

        public IReadOnlyCollection<Product> Products => _market.Products;

        public void Back()
        {
            _router.EnterState<MainMenuState>();
        }
    }
}