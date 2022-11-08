using DM.NotifierTypes;
using Test.MVVM;

namespace Test.Meta
{
    public interface ITextReportViewModel : IViewModel
    {
        NotifierProperty<string> Report { get; }
    }
}