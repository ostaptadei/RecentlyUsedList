using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks;

namespace RecentlyUsedList
{
    public class UniqueStringsStack : HybridFlowProcessor<string>
    {
        private readonly bool _isStackSized = false;
        private readonly int _capacityBound;

        public int Length => _storage.Length;

        public UniqueStringsStack() : base() { }

        public UniqueStringsStack(bool restrictStack, int capacityBound = 5) : base()
        {
            if (_isStackSized = restrictStack)
                _capacityBound = capacityBound;
        }

        private bool Find(string itemToLookUp)
        {
            foreach (var item in _storage)
            {

                if (item == itemToLookUp)
                    return true;
            }
            return false;
        }

        public void Add(string item)
        {
            ArgumentException.ThrowIfNullOrEmpty(item);
            bool isItemDuplicate = Find(item);

            if (isItemDuplicate)
            {
                Console.WriteLine($"Duplicate string {item} was noticed. Moving it to the end...");
                _storage.Remove(item);
            }

            if (_isStackSized && _storage.Length == _capacityBound)
            {
                Dequeue();
            }

            Push(item);

        }

        public string ElementAt(int index)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(index);
            ArgumentOutOfRangeException.ThrowIfGreaterThan(index, Length - 1);
            return _storage.ElementAt(index);
        }


    }
}
