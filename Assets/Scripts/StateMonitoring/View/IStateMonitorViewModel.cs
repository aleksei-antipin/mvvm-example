using DM.NotifierTypes;
using Test.Application;
using Test.MVVM;

namespace Test.Application
{
    public interface IStateMonitorViewModel : IViewModel
    {
        INotifierPropertyReadonly<State> CurrentState { get; }
    }
}