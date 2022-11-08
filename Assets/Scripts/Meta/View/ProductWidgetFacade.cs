using Test.MVVM;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Test.Meta
{
    public class ProductWidgetFacade : WidgetGroupFacade
    {
        [SerializeField] private TextMeshProUGUI _nameText;

        [SerializeField] private TextMeshProUGUI _priceText;

        [SerializeField] private Button _button;

        public TextMeshProUGUI NameText => _nameText;
        public TextMeshProUGUI PriceText => _priceText;
        public Button Button => _button;
    }
}