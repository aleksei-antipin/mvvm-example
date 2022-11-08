using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test.Application
{
    [CreateAssetMenu (fileName = "Products Storage", order = 0, menuName = "Test/ Products Storage")]
    public class ProductsStorage : ScriptableObject
    {

        [Serializable]
        public class PurchaseInfo
        {
            public int duration;
        }

        [Serializable]
        public class PriceInfo
        {
            public int currencyId;
            public double amount;
        }
        
        [Serializable]
        public class ProductPrototype
        {
            public int id;
            public string name;
            public PriceInfo priceInfo;
            public PurchaseInfo purchaseInfo;
        }

        [SerializeField] private List<ProductPrototype> productPrototypes;

        public IReadOnlyCollection<ProductPrototype> ProductPrototypes => productPrototypes;
    }
}

