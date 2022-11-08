using System.Linq;
using Test.Application;

namespace Test.Meta
{
    public class MarketRepository : IMarketRepository
    {
        private readonly CurrenciesStorage _currenciesStorage;

        private readonly ProductsStorage _productsStorage;
        private Market _market;

        #region Ctor

        public MarketRepository(ProductsStorage productsStorage, CurrenciesStorage currenciesStorage)
        {
            _productsStorage = productsStorage;
            _currenciesStorage = currenciesStorage;
        }

        #endregion

        public Market Market => _market ??= CreateMarket();

        private Market CreateMarket()
        {
            var currencies = _currenciesStorage.CurrencyPrototypes
                .Select(c => new Currency(c.id, c.name))
                .ToDictionary(x => x.Id, x => x);

            var products = _productsStorage.ProductPrototypes
                .Select(p =>
                    new Product(p.id, p.name, new Money(p.priceInfo.amount, currencies[p.priceInfo.currencyId])))
                .ToList();

            var market = new Market(products);
            return market;
        }
    }
}