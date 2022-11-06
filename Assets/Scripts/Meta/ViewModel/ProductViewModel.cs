namespace Test.Meta
{
    public class ProductViewModel : IProductViewModel
    {
        private readonly Product _product;

        #region Ctor

        public ProductViewModel(Product product)
        {
            _product = product;
        }

        #endregion

        public string Name => _product.Name;
        public Money Price => _product.Price;
    }
}