using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Test.Meta
{
    public class Market
    {
        public List<Product> Products { get; }

        #region Ctor

        public Market(List<Product> products)
        {
            Products = products;
        }
        
        #endregion
        
    }
}

