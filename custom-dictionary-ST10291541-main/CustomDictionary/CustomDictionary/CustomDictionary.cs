using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDictionary
{

    public class CustomDictionary<TKey, TValue>
    {
        private List<KeyValuePair<TKey, TValue>> items = new List<KeyValuePair<TKey, TValue>>();

        public void Add(TKey key, TValue value)
        {
            if (ContainsKey(key))
                throw new ArgumentException("Key already exists.");
            items.Add(new KeyValuePair<TKey, TValue>(key, value));
        }

        public bool Update(TKey key, TValue newValue)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (EqualityComparer<TKey>.Default.Equals(items[i].Key, key))
                {
                    items[i] = new KeyValuePair<TKey, TValue>(key, newValue);
                    return true;
                }
            }
            return false;
        }

        public bool Remove(TKey key)
        {
            return items.RemoveAll(kv => EqualityComparer<TKey>.Default.Equals(kv.Key, key)) > 0;
        }

        public TValue GetValue(TKey key)
        {
            foreach (var item in items)
            {
                if (EqualityComparer<TKey>.Default.Equals(item.Key, key))
                    return item.Value;
            }
            throw new KeyNotFoundException("Key not found.");
        }

        public bool ContainsKey(TKey key)
        {
            foreach (var item in items)
            {
                if (EqualityComparer<TKey>.Default.Equals(item.Key, key))
                    return true;
            }
            return false;
        }

        public List<KeyValuePair<TKey, TValue>> GetAllItems()
        {
            return new List<KeyValuePair<TKey, TValue>>(items);
        }
    }

}
