using Test.MVVM;

namespace Test.Meta
{
    public interface IProductViewModel : IViewModel
    {
        string Name { get; }
        Money Price { get; }

        void HandleProductClick();
    }
}