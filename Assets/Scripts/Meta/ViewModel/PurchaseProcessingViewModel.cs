using Test.Core;

namespace Test.Meta
{
    public class PurchaseProcessingViewModel : ICancelableProcessingViewModel
    {
        private readonly Transaction _transaction;

        public PurchaseProcessingViewModel(Transaction transaction)
        {
            _transaction = transaction; 
        }

        public void HandleCancel()
        {
            _transaction.Cancel();
        }
    }
}