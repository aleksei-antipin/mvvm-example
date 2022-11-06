using System.Collections;
using System.Collections.Generic;
using Test.MVVM;
using UnityEngine;
using UnityEngine.UI;

namespace Test.Meta
{
    public class PlayerSettingsWidgetFacade : WidgetGroupFacade
    {
        [SerializeField] private Button _backBatton;

        public Button BackButton => _backBatton;
    }
}
