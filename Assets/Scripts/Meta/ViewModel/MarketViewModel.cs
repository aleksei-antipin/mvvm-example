using System.Collections.Generic;
using System.Linq;
using Test.Application;

namespace Test.Meta
{
    public class MarketViewModel : IMarketViewModel
    {
        private readonly Market _market;
        private readonly Router _router;
        private readonly PurchasingService _purchasingService;

        #region Ctor

        public MarketViewModel(Router router, Market market, PurchasingService purchasingService)
        {
            _router = router;
            _market = market;
            _purchasingService = purchasingService;
            
            //wtf
            Products = _market.Products
                .Select(p => new ProductViewModel(p, _purchasingService))
                .ToList();
        }

        #endregion

        public IReadOnlyCollection<ProductViewModel> Products { get; }

        public void Back()
        {
            _router.EnterState<MainMenuState>();
        }
    }
}