using System;
using System.Collections.Generic;

namespace Test.Meta
{
    public class InventoryEntry
    {
        public InventoryEntry(int itemId, int count = 0)
        {
            ItemId = itemId;
            Count = count;
        }

        public int ItemId { get; }
        public int Count { get; private set; }

        public bool TrySpend(int countToSpend)
        {
            if (Count - countToSpend < 0 || countToSpend < 0)
                return false;

            Count -= countToSpend;
            return true;
        }

        public void Add(int count)
        {
            if (count > 0)
                Count += count;
        }

        public override string ToString()
        {
            return $"Item id: {ItemId}, count: {Count}";
        }
    }

    public class Inventory
    {
        private readonly Dictionary<int, InventoryEntry> _entries;

        public Inventory(Dictionary<int, InventoryEntry> entries = null)
        {
            _entries = entries ?? new Dictionary<int, InventoryEntry>();
        }

        public IReadOnlyDictionary<int, InventoryEntry> Entries => _entries;

        public event Action InventoryStateUpdated;

        public void AddItem(int id, int count = 1)
        {
            if (_entries.ContainsKey(id))
                _entries[id].Add(count);
            else
                _entries.Add(id, new InventoryEntry(id, count));
            InventoryStateUpdated?.Invoke();
        }
    }
}