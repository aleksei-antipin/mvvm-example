using System.Collections;
using System.Collections.Generic;
using Test.MVVM;
using UnityEngine;

namespace Test.Meta
{
    public interface IMarketViewModel : IViewModel
    {
        IReadOnlyCollection<ProductViewModel> Products { get; }
        void Back();
    }
}
