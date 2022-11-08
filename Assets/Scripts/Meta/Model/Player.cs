namespace Test.Meta
{
    public class Player
    {
        public int Id { get; }

        public Inventory Inventory { get; }

        public Wallet Wallet { get; }

        #region Ctor

        public Player(int id, Inventory inventory, Wallet wallet)
        {
            Id = id;
            Inventory = inventory;
            Wallet = wallet;
        }
        
        #endregion
        
    }
}