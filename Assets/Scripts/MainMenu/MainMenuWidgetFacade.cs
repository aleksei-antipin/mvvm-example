using System.Collections;
using System.Collections.Generic;
using Test.Application;
using UnityEngine;
using UnityEngine.UI;

namespace Test
{
    public class MainMenuWidgetFacade : MVVM.WidgetGroupFacade
    {
        [SerializeField] private Button _marketButton;

        [SerializeField] private Button _gameButton;

        [SerializeField] private Button _playerButton;

        public Button MarketButton => _marketButton;

        public Button GameButton => _gameButton;

        public Button PlayerButton => _playerButton;

    }
}
