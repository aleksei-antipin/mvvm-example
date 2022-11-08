using System.Linq;
using Test.Application;

namespace Test.Meta
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly CurrenciesStorage _currenciesStorage;
        private readonly PlayerStorage _playerStorage;

        private Player _player;

        #region

        public PlayerRepository(PlayerStorage playerStorage, CurrenciesStorage currenciesStorage)
        {
            _playerStorage = playerStorage;
            _currenciesStorage = currenciesStorage;
        }

        #endregion

        public Player Player => _player ??= CreatePlayer();

        private Player CreatePlayer()
        {
            var currencies = _currenciesStorage.CurrencyPrototypes
                .Select(c => new Currency(c.id, c.name))
                .ToDictionary(x => x.Id, x => x);

            var money = new Money(
                _playerStorage.PlayerPrototype.wallet.ToDictionary(x => currencies[x.id], y => (double)y.value));
            var wallet = new Wallet(money);
            var inventory = new Inventory();
            var player = new Player(0, inventory, wallet);

            return player;
        }
    }
}