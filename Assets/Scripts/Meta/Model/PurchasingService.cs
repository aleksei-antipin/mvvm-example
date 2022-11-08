using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Test.Core;
using Test.Meta;
using UnityEngine;

namespace Test.Application
{
    public class PurchasingService
    {
        
        private class PurchaseTransaction : Transaction
        {
            private readonly Product _product;
            private readonly Player _player;
            
            public PurchaseTransaction(Product product, Player player)
            {
                _product = product;
                _player = player;
            }
            
            protected override async UniTask CreateResult(CancellationTokenSource cancellationTokenSource)
            {
                await UniTask.Delay(1000);
                
                cancellationTokenSource.Token.ThrowIfCancellationRequested();
                
                var isSpent = _player.Wallet.TrySpend(_product.Price);
                if (isSpent)
                {
                    _player.Inventory.AddItem(_product.ID);
                }
            }
        }
        
        private readonly Player _player;
        private readonly Market _market;
        
        #region Ctor

        public PurchasingService(Player player, Market market)
        {
            _player = player;
            _market = market;
        }
        
        #endregion


        public Transaction CreatePurchaseTransaction(Product product)
        {
            var transaction = new PurchaseTransaction(product, _player);
            return transaction;
        }
        
        public void PurchaseProduct(Product product)
        {
            var isSpent = _player.Wallet.TrySpend(product.Price);
            if (isSpent)
            {
                _player.Inventory.AddItem(product.ID);
            }
        }
    }
}

