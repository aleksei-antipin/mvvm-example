using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test.Meta
{
    public class Product
    {
        public Money Price { get; }
        public int ID { get; }
        public string Name { get; }

        #region Ctor

        public Product(int id, string name, Money price)
        {
            ID = id;
            Name = name;
            Price = price;
        }

        #endregion
        
    }
}
