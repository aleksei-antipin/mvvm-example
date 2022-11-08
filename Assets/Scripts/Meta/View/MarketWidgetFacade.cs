using Test.MVVM;
using UnityEngine;
using UnityEngine.UI;

namespace Test.Meta
{
    public class MarketWidgetFacade : WidgetGroupFacade
    {
        [SerializeField] private Button _backBatton;

        public Button BackButton => _backBatton;
    }
}