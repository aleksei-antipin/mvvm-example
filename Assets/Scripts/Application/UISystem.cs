using System;
using System.Collections.Generic;
using Test.Meta;
using Test.MVVM;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Test.Application
{
    public class ViewModelContext
    {
        public object[] viewModelCtorArgs;
    }

    public class UISystem
    {
        private static readonly Dictionary<Type, string> _map = new()
        {
            { typeof(MarketViewBehaviour), "MarketWidgetFacade" },
            { typeof(ProductViewBehaviour), "ProductWidgetFacade" },
            { typeof(MainMenuViewBehaviour), "MainMenuWidgetFacade" },
            { typeof(PlayerSettingsViewBehaviour), "PlayerSettingsWidgetFacade" },
            { typeof(TextReportViewBehaviour), "TextReportWidgetFacade" },
            { typeof(CancelableProcessingViewBehaviour), "CancelableProcessingWidgetFacade"}
        };

        private static UIRoot _root;

        public static (TViewBehaviour, TViewModel) CreateViewModel<TViewBehaviour, TViewModel>(
            ViewModelContext context, Transform root = null, Vector2? position = null) where TViewModel : IViewModel
            where TViewBehaviour : ViewBehaviour
        {
            var widgetPath = _map[typeof(TViewBehaviour)];
            var widget = InstantiateWidget(widgetPath, root);

            if (position.HasValue)
            {
                widget.GetComponent<RectTransform>().anchoredPosition = position.Value;
            }

            var viewModel = (TViewModel)Activator.CreateInstance(typeof(TViewModel), context.viewModelCtorArgs);
            var viewBehaviour = (TViewBehaviour)Activator.CreateInstance(typeof(TViewBehaviour), widget, viewModel);
            viewBehaviour.Initialize();
            return (viewBehaviour, viewModel);
        }

        public static TViewBehaviour CreateViewBehaviour<TViewBehaviour, TViewModel>(TViewModel viewModel, Transform root = null) where TViewModel : IViewModel where TViewBehaviour : ViewBehaviour
        {
            var path = _map[typeof(TViewBehaviour)];
            var widget = InstantiateWidget(path, root);
            var viewBehaviour = (TViewBehaviour)Activator.CreateInstance(typeof(TViewBehaviour), widget, viewModel);
            viewBehaviour.Initialize();
            return viewBehaviour;
        }

        public static void Release(ViewBehaviour viewBehaviour)
        {
            viewBehaviour.Deactivate();
            Object.Destroy(viewBehaviour.BaseFacade.gameObject);
        }

        private static WidgetGroupFacade InstantiateWidget(string path, Transform root = null)
        {
            if (!root)
            {
                if (!_root) _root = Object.FindObjectOfType<UIRoot>();

                root = _root.transform;
            }

            var view = Resources.Load<WidgetGroupFacade>(path);
            var instance = Object.Instantiate(view, root);
            return instance;
        }

        public static T InstantiateWidget<T>(Transform root = null) where T : WidgetGroupFacade
        {
            if (!root)
            {
                if (!_root) _root = Object.FindObjectOfType<UIRoot>();

                root = _root.transform;
            }

            var view = Resources.Load<T>(typeof(T).Name);
            var instance = Object.Instantiate(view, root);
            return instance;
        }
    }
}