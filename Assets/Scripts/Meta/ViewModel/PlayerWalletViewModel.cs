using System.Linq;
using DM.NotifierTypes;

namespace Test.Meta
{
    public class PlayerWalletViewModel : ITextReportViewModel
    {
        private readonly Wallet _wallet;

        #region Ctor

        public PlayerWalletViewModel(Wallet wallet)
        {
            _wallet = wallet;
  
            Report = new ();
            UpdateReport();
            _wallet.WalletStateChanged += UpdateReport;
        }

        #endregion

        private void UpdateReport()
        {
            Report.Value = _wallet.Money
                .Aggregate("", (a, b) => a + "\n" + $"{b.Key}: {b.Value}");
        }
        
        public NotifierProperty<string> Report { get; }
    }
}