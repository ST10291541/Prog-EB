using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportQueues
{
    public class CustomQueue<T>
    {
        private List<T> items = new List<T>();

        public void Enqueue(T item) => items.Add(item);

        public T Dequeue()
        {
            if (IsEmpty()) throw new InvalidOperationException("Queue is empty");
            T value = items[0];
            items.RemoveAt(0);
            return value;
        }

        public bool IsEmpty() => items.Count == 0;

        public int Count => items.Count;

        public T Peek()
        {
            if (IsEmpty()) throw new InvalidOperationException("Queue is empty");
            return items[0];
        }

        public CustomQueue<T> Clone()
        {
            var clone = new CustomQueue<T>();
            foreach (var item in items)
                clone.Enqueue(item);
            return clone;
        }
    }
}
