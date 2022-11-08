using System;
using System.Collections;
using System.Collections.Generic;
using Test.MVVM;
using UnityEngine;

namespace Test.Application
{
    public class StateMonitoringWidgetFacade : WidgetGroupFacade
    {
        public string Message { get; set; }

        private GUIStyle _style;
        private void Awake()
        {
            _style = new GUIStyle
            {
                fontSize = 30
            };
        }

        private void OnGUI()
        {
            GUI.Label(new Rect(10, 10, 150, 50), Message, _style);
        }
    }

}

