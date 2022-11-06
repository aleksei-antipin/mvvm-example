using System.Collections;
using System.Collections.Generic;
using Test.MVVM;
using UnityEngine;
using UnityEngine.UI;

namespace Test.Meta
{
    public class MarketWidgetFacade : WidgetGroupFacade
    {
        [SerializeField] private Button _backBatton;

        [SerializeField] private GameObject _contentHolder;

        public Button BackButton => _backBatton;

        public GameObject ContentHolder => _contentHolder;
    }

}
