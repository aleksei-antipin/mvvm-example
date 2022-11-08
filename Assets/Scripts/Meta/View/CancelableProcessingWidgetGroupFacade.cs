using System;
using Cysharp.Threading.Tasks;
using Test.MVVM;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Test.Meta
{
    public class CancelableProcessingWidgetGroupFacade : WidgetGroupFacade
    {
        [SerializeField] private TextMeshProUGUI _headerText;

        [SerializeField] private Image _image;

        [SerializeField] private Button _canceleButton;

        public TextMeshProUGUI HeaderText => _headerText;

        public Image LoaderImage => _image;

        public Button CancelButton => _canceleButton;
    }
}