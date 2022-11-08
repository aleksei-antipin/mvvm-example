using System.Collections;
using System.Collections.Generic;
using Test.MVVM;
using TMPro;
using UnityEngine;

namespace Test.Meta
{  
    public class TextReportWidgetFacade : WidgetGroupFacade
    {

        [SerializeField] private TextMeshProUGUI _headerText;
        
        [SerializeField] private TextMeshProUGUI _reportText;

        public TextMeshProUGUI HeaderText => _headerText;
        public TextMeshProUGUI ReportText => _reportText;
    }
}

