
namespace Test.Meta
{
    public class Wallet
    {
        private Money _money;

        public void Add(Money money)
        {
            _money.Add(money);
        }

        public bool TrySpend(Money money)
        {
            return _money.TrySpend(money);
        }
    }
}

