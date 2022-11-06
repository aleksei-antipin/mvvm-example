using System.Collections;
using System.Collections.Generic;
using Test.MVVM;
using UnityEngine;

namespace Test.Meta
{
    public interface IMarketViewModel : IViewModel
    {
        IReadOnlyCollection<Product> Products { get; }
        void Back();
    }
}
