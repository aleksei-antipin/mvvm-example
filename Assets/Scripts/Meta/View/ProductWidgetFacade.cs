using Test.MVVM;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Test.View
{
    public class ProductWidgetFacade : WidgetGroupFacade
    {
        [SerializeField] private TextMeshProUGUI _nameText;

        [SerializeField] private TextMeshProUGUI _priceText;

        public TextMeshProUGUI NameText => _nameText;
        public TextMeshProUGUI PriceText => _priceText;
    }
}