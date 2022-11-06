using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test.Infrastructure
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
}

