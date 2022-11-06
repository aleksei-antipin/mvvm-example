using Test.Meta;
using Test.States;
using UnityEngine;

namespace Test.Infrastructure
{
    public class ApplicationEntry : MonoBehaviour
    {
        [SerializeField] private CurrenciesStorage _currenciesStorage;

        [SerializeField] private ProductsStorage _productsStorage;

        [SerializeField] private PlayerStorage _playerStorage;

        private readonly Router _router = new();

        private readonly StateMonitor _stateMonitor = new();

        #region Repositories

        private MarketRepository _marketRepository;

        #endregion

        private void Awake()
        {
            ResolveDependencies();
            InitializeRouter();
            InitializeServiceLocator();
            _router.EnterState<MainMenuState>();
            _stateMonitor.Initialize();
        }

        private void ResolveDependencies()
        {
            _marketRepository = new MarketRepository(_productsStorage, _currenciesStorage);
        }

        private void InitializeRouter()
        {
            _router.TryAddState(_marketState);
            _router.TryAddState(_playerAdjustingState);
            _router.TryAddState(_gameplayState);
            _router.TryAddState(_mainMenuState);
        }

        private void InitializeServiceLocator()
        {
            ServiceLocator.Instance.AddInstance(_router);
            ServiceLocator.Instance.AddInstance(_currenciesStorage);
            ServiceLocator.Instance.AddInstance(_productsStorage);
            ServiceLocator.Instance.AddInstance(_playerStorage);
            
            ServiceLocator.Instance.AddInstance(_marketRepository);
        }


        #region States

        private readonly State _marketState = new MarketState();

        private readonly State _playerAdjustingState = new PlayerSettingsState();

        private readonly State _gameplayState = new GameplayState();

        private readonly State _mainMenuState = new MainMenuState();

        #endregion
    }
}