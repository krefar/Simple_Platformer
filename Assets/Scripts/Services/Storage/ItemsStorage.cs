using System.Collections.Generic;

namespace Assets.Scripts.Services.Storage
{
    public abstract class ItemsStorage<T>
    {
        private List<T> _items;

        public abstract string Name { get; }

        public ItemsStorage()
        {
            _items = new List<T>();
        }

        public void Add(T item)
        {
            _items.Add(item);
        }

        public void Remove(T item)
        {
            _items.Remove(item);
        }

        public void Clear()
        {
            _items.Clear();
        }

        protected IEnumerable<T> GetAllItems()
        {
            return _items.AsReadOnly();
        }
    }
}
