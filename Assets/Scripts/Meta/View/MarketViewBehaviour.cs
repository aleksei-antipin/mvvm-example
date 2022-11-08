using System.Collections.Generic;
using System.Linq;
using Test.Application;
using Test.MVVM;
using Test.Meta;

namespace Test.Meta
{
    public class MarketViewBehaviour : ViewBehaviour<MarketWidgetFacade, IMarketViewModel>
    {
        private ProductListWidgetFacade _productListWidgetFacade;

        private List<ProductViewBehaviour> _products;

        public MarketViewBehaviour(MarketWidgetFacade facade, IMarketViewModel viewModel) : base(facade, viewModel)
        {
            
        }

        protected override void OnInitialized()
        {
            WidgetGroupFacade.BackButton.onClick.AddListener(OnBackButtonPressed);
            _productListWidgetFacade = UISystem.InstantiateWidget<ProductListWidgetFacade>(WidgetGroupFacade.transform);
            
            //wtf
            PopulateProducts();
        }

        private void PopulateProducts()
        {
            _products = ViewModel.Products
                .Select(p =>
                    UISystem.CreateViewBehaviour<ProductViewBehaviour, IProductViewModel>(p,
                        _productListWidgetFacade.ContentHolder.transform))
                .ToList();
        }
        
        private void OnBackButtonPressed()
        {
            ViewModel.Back();
        }
    }
}