using System;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace Test.Core
{
    public enum TransactionStatus
    {
        Success = 0,
        Failed = 1,
        Cancelled = 2,
        Undefined = 3
    }

    public abstract class Transaction
    {
        private readonly CancellationTokenSource _cancellationTokenSource = new();
        public TransactionStatus Status { get; protected set; } = TransactionStatus.Undefined;
        public string Error { get; protected set; }

        public async UniTask RunTransaction()
        {
            try
            {
                await CreateResult(_cancellationTokenSource);
                Status = TransactionStatus.Success;
            }
            catch (Exception e)
            {
                if (e is OperationCanceledException)
                {
                    Status = TransactionStatus.Cancelled;
                    return;
                }

                Error = e.Message;
                Status = TransactionStatus.Failed;
            }
        }

        public void Cancel()
        {
            _cancellationTokenSource.Cancel();
        }

        protected abstract UniTask CreateResult(CancellationTokenSource cancellationTokenSource);
    }

    public abstract class Transaction<T>
    {
        private readonly CancellationTokenSource _cancellationTokenSource = new();
        public TransactionStatus Status { get; protected set; } = TransactionStatus.Undefined;
        public string Error { get; protected set; }

        public async UniTask<T> RunTransaction()
        {
            try
            {
                return await CreateResult(_cancellationTokenSource);
                Status = TransactionStatus.Success;
            }
            catch (Exception e)
            {
                if (e is OperationCanceledException) Status = TransactionStatus.Cancelled;

                Error = e.Message;
                Status = TransactionStatus.Failed;
                return default;
            }
        }

        public void Cancel()
        {
            _cancellationTokenSource.Cancel();
        }

        protected abstract UniTask<T> CreateResult(CancellationTokenSource cancellationTokenSource);
    }
}