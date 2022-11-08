using System;
using System.Collections.Generic;

namespace Test.Meta
{
    public class Wallet
    {
        private readonly Money _money;

        public Wallet(Money money = null)
        {
            _money = money == null ? new Money() : money;
        }

        public IReadOnlyDictionary<Currency, double> Money => _money.Values;

        public event Action WalletStateChanged;

        public void Add(Money money)
        {
            _money.Add(money);
            WalletStateChanged?.Invoke();
        }

        public bool TrySpend(Money money)
        {
            var isSpent = _money.TrySpend(money);
            if (isSpent)
                WalletStateChanged?.Invoke();

            return isSpent;
        }
    }
}