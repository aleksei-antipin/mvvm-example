namespace Test.Meta
{
    public class Player
    {
        public int Id { get; }
        private readonly Inventory _inventory;
        private readonly Wallet _wallet;
        
        #region Ctor

        public Player(int id, Inventory inventory, Wallet wallet)
        {
                
        }
        
        #endregion
        
    }
}