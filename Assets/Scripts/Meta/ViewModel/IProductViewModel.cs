using System.Collections;
using System.Collections.Generic;
using Test.MVVM;
using UnityEngine;

namespace Test.Meta
{
    public interface IProductViewModel : IViewModel
    {
        string Name { get; }
        Money Price { get; }
    }
}
