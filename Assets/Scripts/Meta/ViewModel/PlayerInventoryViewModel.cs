using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DM.NotifierTypes;
using UnityEngine;

namespace Test.Meta
{
    public class PlayerInventoryViewModel : ITextReportViewModel
    {
        private readonly Inventory _inventory;

        #region Ctor

        public PlayerInventoryViewModel(Inventory inventory)
        {
            _inventory = inventory;
  
            Report = new ();
            UpdateReport();
            _inventory.InventoryStateUpdated += UpdateReport;
        }

        #endregion

        private void UpdateReport()
        {
            Report.Value = _inventory.Entries
                .Aggregate("", (a, b) => a + "\n" + $"{b.Value}");
        }
        
        public NotifierProperty<string> Report { get; }
        
    }

}
