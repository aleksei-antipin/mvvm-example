using System;
using System.Collections.Generic;
using UnityEngine;

namespace Test.Infrastructure
{
    [CreateAssetMenu(fileName = "Currencies Storage", order = 0, menuName = "Test/ Currencies Storage")]
    public class CurrenciesStorage : ScriptableObject
    {
        [SerializeField] private List<CurrencyPrototype> currencyPrototypes;

        public IReadOnlyCollection<CurrencyPrototype> CurrencyPrototypes => currencyPrototypes;

        [Serializable]
        public class CurrencyPrototype
        {
            public int id;
            public string name;
        }
    }
}