using DM.NotifierTypes;
using Test.Infrastructure;
using Test.MVVM;

namespace Test.States
{
    public interface IStateMonitorViewModel : IViewModel
    {
        INotifierPropertyReadonly<State> CurrentState { get; }
    }
}