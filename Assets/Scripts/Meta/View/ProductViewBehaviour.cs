using System.Collections;
using System.Collections.Generic;
using Test.MVVM;
using Test.View;
using UnityEngine;

namespace Test.Meta
{
    public class ProductViewBehaviour : ViewBehaviour<ProductWidgetFacade, IProductViewModel>
    {
        public ProductViewBehaviour(ProductWidgetFacade facade, IProductViewModel viewModel) : base(facade, viewModel)
        {
        }

        protected override void OnInitialized()
        {
            // WidgetGroupFacade.N

        }
    }
}
