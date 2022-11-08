using Test.Application;

namespace Test.Meta
{
    public class ProductViewModel : IProductViewModel
    {
        private readonly Product _product;

        private readonly PurchasingService _purchasingService;

        #region Ctor

        public ProductViewModel(Product product, PurchasingService purchasingService)
        {
            _product = product;
            _purchasingService = purchasingService;
        }

        #endregion

        public string Name => _product.Name;
        public Money Price => _product.Price;

        public async void HandleProductClick()
        {
            var transaction = _purchasingService.CreatePurchaseTransaction(_product);

            var processingContext = new ViewModelContext
            {
                viewModelCtorArgs = new[] { transaction }
            };
            var processing =
                UISystem.CreateViewModel<CancelableProcessingViewBehaviour, PurchaseProcessingViewModel>(
                    processingContext);
            
            await transaction.RunTransaction();
    
            UISystem.Release(processing.Item1);
        }
    }
}