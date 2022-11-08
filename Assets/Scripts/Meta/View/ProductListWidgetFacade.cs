using UnityEngine;

namespace Test.Meta
{
    public class ProductListWidgetFacade : MVVM.WidgetGroupFacade
    {
        [SerializeField] private Transform _contentHolder;

        public Transform ContentHolder => _contentHolder;
    }
}