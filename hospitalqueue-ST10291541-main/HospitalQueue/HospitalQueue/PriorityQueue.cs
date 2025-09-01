using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalQueue
{
    public class PriorityQueue<T>
    {
        private List<(T item, int priority)> heap = new List<(T, int)>();

        private int Parent(int i) => (i - 1) / 2;
        private int Left(int i) => 2 * i + 1;
        private int Right(int i) => 2 * i + 2;

        private void Swap(int i, int j)
        {
            var temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }

        public void Enqueue(T item, int priority)
        {
            heap.Add((item, priority));
            int i = heap.Count - 1;

            // Bubble up (maintain max-heap property)
            while (i > 0 && heap[Parent(i)].priority < heap[i].priority)
            {
                Swap(i, Parent(i));
                i = Parent(i);
            }
        }

        public T Dequeue()
        {
            if (heap.Count == 0)
                throw new InvalidOperationException("The queue is empty.");

            var root = heap[0].item;
            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);

            Heapify(0);
            return root;
        }

        private void Heapify(int i)
        {
            int left = Left(i);
            int right = Right(i);
            int largest = i;

            if (left < heap.Count && heap[left].priority > heap[largest].priority)
                largest = left;

            if (right < heap.Count && heap[right].priority > heap[largest].priority)
                largest = right;

            if (largest != i)
            {
                Swap(i, largest);
                Heapify(largest);
            }
        }

        public bool IsEmpty() => heap.Count == 0;
    }
}

