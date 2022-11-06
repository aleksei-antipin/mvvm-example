using Test.Infrastructure;
using Test.Meta;
using UnityEngine;

namespace Test.States
{
    public class MarketState : State
    {
        private MarketViewBehaviour _marketViewBehaviour;
        private MarketViewModel _marketViewModel;
        protected override void OnStateEnter()
        {
            var router = ServiceLocator.Instance.Resolve<Router>();
            var marketRepository = ServiceLocator.Instance.Resolve<MarketRepository>();
            var market = marketRepository.Market;

            var context = new ViewModelGenerationContext
            {
                viewModelArgs = new object[] {router, market}
            };

            (_marketViewBehaviour, _marketViewModel) =
                UISystem.CreateViewModel<MarketViewBehaviour, MarketViewModel>(context);

        }

        protected override void OnStateExit()
        {
            UISystem.Release(_marketViewBehaviour);
            _marketViewBehaviour = null;
            _marketViewModel = null;
        }
    }
}