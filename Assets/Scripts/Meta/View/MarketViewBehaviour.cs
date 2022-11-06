using System.Collections;
using System.Collections.Generic;
using Test.Infrastructure;
using Test.MVVM;
using Test.View;
using UnityEngine;

namespace Test.Meta
{
    public class MarketViewBehaviour : ViewBehaviour<MarketWidgetFacade, IMarketViewModel>
    {
        private ProductListWidgetFacade _productListWidgetFacade;
        
        public MarketViewBehaviour(MarketWidgetFacade facade, IMarketViewModel viewModel) : base(facade, viewModel)
        {
        }

        protected override void OnInitialized()
        {
            WidgetGroupFacade.BackButton.onClick.AddListener(OnBackButtonPressed);
            _productListWidgetFacade = UISystem.InstantiateWidget<ProductListWidgetFacade>(WidgetGroupFacade.transform);
            
            PopulateProducts();
        }

        private void OnBackButtonPressed()
        {
            ViewModel.Back();
        }

        private void PopulateProducts()
        {

            foreach (var product in ViewModel.Products)    
            {
                var root = _productListWidgetFacade.ContentHolder.transform;
                var productWidgetFacade = UISystem.InstantiateWidget<ProductWidgetFacade>(root);
                var productViewModel = new ProductViewModel(product);
                var productViewBehaviour = new ProductViewBehaviour(productWidgetFacade, productViewModel);
                productViewBehaviour.Initialize();
            }
        }
    }
}
