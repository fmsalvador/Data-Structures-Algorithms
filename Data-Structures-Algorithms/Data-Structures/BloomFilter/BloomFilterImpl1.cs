using System;
using System.Collections;

namespace Data_Structures_Algorithms.Data_Structures
{
    public class BloomFilterImpl1
    {
        public void Test()
        {
            BloomFilterImpl1 bloomFilter = new BloomFilterImpl1(1000, 3);

            // Add items
            bloomFilter.Add("apple");
            bloomFilter.Add("banana");
            bloomFilter.Add("grape");

            // Check if items are present
            Console.WriteLine(bloomFilter.Contains("apple")); // Output: True
            Console.WriteLine(bloomFilter.Contains("banana")); // Output: True
            Console.WriteLine(bloomFilter.Contains("grape")); // Output: True
            Console.WriteLine(bloomFilter.Contains("orange")); // Output: False (or True with a small probability)
        }

        private BitArray bitArray;
        private int size;
        private int hashFunctionsCount;


        public BloomFilterImpl1() { }

        public BloomFilterImpl1(int size, int hashFunctionsCount)
        {
            this.size = size;
            this.hashFunctionsCount = hashFunctionsCount;
            bitArray = new BitArray(size);
        }

        public void Add(string item)
        {
            for (int i = 0; i < hashFunctionsCount; i++)
            {
                int hashValue = HashFunction(item, i);
                bitArray.Set(hashValue, true);
            }
        }
        public bool Contains(string item)
        {
            for (int i = 0; i < hashFunctionsCount; i++)
            {
                int hashValue = HashFunction(item, i);
                if (!bitArray.Get(hashValue))
                {
                    return false;
                }
            }

            return true;
        }


        private int HashFunction(string item, int seed)
        {
            int hash = item.GetHashCode() ^ seed;
            return Math.Abs(hash) % size;
        }
    }
}
