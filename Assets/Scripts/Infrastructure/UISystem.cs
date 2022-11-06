using System;
using System.Collections.Generic;
using Test.Meta;
using Test.MVVM;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Test.Infrastructure
{
    public class ViewModelGenerationContext
    {
        public object[] viewModelArgs;
    }

    public class UISystem
    {
        private static readonly Dictionary<Type, string> _map = new()
        {
            { typeof(MarketViewBehaviour), "MarketWidgetFacade" },
            { typeof(ProductViewBehaviour), "ProductWidgetFacade" },
            { typeof(MainMenuViewBehaviour), "MainMenuWidgetFacade" },
            { typeof(PlayerSettingsViewModel), "PlayerSettingsFacade" }
        };

        private static UIRoot _root;

        public static (TViewBehaviour, TViewModel) CreateViewModel<TViewBehaviour, TViewModel>(
            ViewModelGenerationContext context, Transform root = null) where TViewModel : IViewModel
            where TViewBehaviour : ViewBehaviour
        {
            var widgetPath = _map[typeof(TViewBehaviour)];
            var widget = InstantiateWidget(widgetPath, root);
            var viewModel = (TViewModel)Activator.CreateInstance(typeof(TViewModel), context.viewModelArgs);
            var viewBehaviour = (TViewBehaviour)Activator.CreateInstance(typeof(TViewBehaviour), widget, viewModel);
            viewBehaviour.Initialize();
            return (viewBehaviour, viewModel);
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