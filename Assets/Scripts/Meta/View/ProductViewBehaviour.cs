using System;
using Test.MVVM;
using Test.Meta;

namespace Test.Meta
{
    public class ProductViewBehaviour : ViewBehaviour<ProductWidgetFacade, IProductViewModel>
    {
        public ProductViewBehaviour(ProductWidgetFacade facade, IProductViewModel viewModel) : base(facade, viewModel)
        {
        }

        public event Action<IViewModel> OnProductClick;

        protected override void OnInitialized()
        {
            WidgetGroupFacade.NameText.text = ViewModel.Name;
            WidgetGroupFacade.PriceText.text = ViewModel.Price.ToString();
            WidgetGroupFacade.Button.onClick.AddListener(HandleProductClick);
        }

        private void HandleProductClick()
        {
            ViewModel.HandleProductClick();
            OnProductClick?.Invoke(ViewModel);
        }
    }
}