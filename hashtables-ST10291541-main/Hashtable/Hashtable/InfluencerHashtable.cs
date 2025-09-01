using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hashtable
{
    public class InfluencerHashtable
    {
        private class HashNode
        {
            public string Key { get; set; }
            public Influencer Value { get; set; }
            public HashNode Next { get; set; }

            public HashNode(string key, Influencer value)
            {
                Key = key;
                Value = value;
                Next = null;
            }
        }

        private readonly int size;
        private readonly HashNode[] buckets;

        public InfluencerHashtable(int size = 10)
        {
            this.size = size;
            buckets = new HashNode[size];
        }

        private int GetBucketIndex(string key)
        {
            return Math.Abs(key.GetHashCode()) % size;
        }

        // Insert or Update Influencer
        public void Insert(string key, Influencer value)
        {
            int index = GetBucketIndex(key);
            var head = buckets[index];

            // Check if key exists (update case)
            while (head != null)
            {
                if (head.Key == key)
                {
                    head.Value = value;
                    return;
                }
                head = head.Next;
            }

            // Insert new node at bucket head
            var newNode = new HashNode(key, value)
            {
                Next = buckets[index]
            };
            buckets[index] = newNode;
        }

        // Retrieve Influencer
        public Influencer Get(string key)
        {
            int index = GetBucketIndex(key);
            var head = buckets[index];

            while (head != null)
            {
                if (head.Key == key)
                    return head.Value;

                head = head.Next;
            }
            return null; // Not found
        }

        // Remove Influencer
        public bool Remove(string key)
        {
            int index = GetBucketIndex(key);
            var head = buckets[index];
            HashNode prev = null;

            while (head != null)
            {
                if (head.Key == key)
                {
                    if (prev == null)
                        buckets[index] = head.Next;
                    else
                        prev.Next = head.Next;
                    return true;
                }
                prev = head;
                head = head.Next;
            }
            return false; // Not found
        }
    }
}
