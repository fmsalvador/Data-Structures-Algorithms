using System;
using System.Collections.Generic;
using System.Linq;

namespace Data_Structures_Algorithms.Data_Structures
{
    public class HyperLogLog<T> where T : notnull
    {
        private const int P = 16;
        private readonly int[] registers;
        private readonly HashSet<int> setRegisters;

        public void TestHyperLogLog()
        {
            var hll = new HyperLogLog<int>() ;
            var realCardinality = 10000;
            var rand = new Random();

            for (var i = 0; i < 10000; i++)
            {
                var k = rand.Next(20000);
                hll.Add(k);
            }

            var estimatedCardinality = hll.Cardinality();
            var percentageDifference = GetPercentageDifference(realCardinality, estimatedCardinality);

            Console.WriteLine($"Percentage difference between real cardinality " +
                $"({realCardinality}) and estimated ({estimatedCardinality})  is {percentageDifference} percente");

        }

        public void TestHyperLogLogMerge()
        {
            var hll1 = new HyperLogLog<int>();
            var hll2 = new HyperLogLog<int>();
            var rand = new Random();
            var realCardinality = 5000;

            for (var i = 0; i < 5000; i++)
            {
                var k = rand.Next(20000);
                hll1.Add(k);
            }

            for (var i = 0; i < 5000; i++)
            {
                var k = rand.Next(20000);
                hll2.Add(k);
            }

            var hll = HyperLogLog<int>.Merge(hll1, hll2);


            var estimatedCardinality = hll.Cardinality();
            var percentageDifference = GetPercentageDifference(realCardinality, estimatedCardinality);

            Console.WriteLine($"Percentage (merged) difference between real cardinality " +
                $"({(2 * realCardinality)}) and estimated ({estimatedCardinality})  is {percentageDifference} percente");

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HyperLogLog{T}"/> class.
        /// </summary>
        public HyperLogLog()
        {
            var m = 1 << P;
            registers = new int[m];
            setRegisters = new HashSet<int>();
        }

        /// <summary>
        /// Merge's two HyperLogLog's together to form a union HLL.
        /// </summary>
        /// <param name="first">the first HLL.</param>
        /// <param name="second">The second HLL.</param>
        /// <returns>A HyperLogLog with the combined values of the two sets of registers.</returns>
        public static HyperLogLog<T> Merge(HyperLogLog<T> first, HyperLogLog<T> second)
        {
            var output = new HyperLogLog<T>();
            for (var i = 0; i < second.registers.Length; i++)
            {
                output.registers[i] = Math.Max(first.registers[i], second.registers[i]);
            }

            output.setRegisters.UnionWith(first.setRegisters);
            output.setRegisters.UnionWith(second.setRegisters);
            return output;
        }

        /// <summary>
        /// Adds an item to the HyperLogLog.
        /// </summary>
        /// <param name="item">The Item to be added.</param>
        public void Add(T item)
        {
            var x = item.GetHashCode();
            var binString = Convert.ToString(x, 2); // converts hash to binary
            var j = Convert.ToInt32(binString.Substring(0, Math.Min(P, binString.Length)), 2); // convert first b bits to register index
            var w = (int)Math.Log2(x ^ (x & (x - 1))); // find position of the right most 1.
            registers[j] = Math.Max(registers[j], w); // set the appropriate register to the appropriate value.
            setRegisters.Add(j);
        }

        /// <summary>
        /// Determines the approximate cardinality of the HyperLogLog.
        /// </summary>
        /// <returns>the approximate cardinality.</returns>
        public int Cardinality()
        {
            // calculate the bottom part of the harmonic mean of the registers
            double z = setRegisters.Sum(index => Math.Pow(2, -1 * registers[index]));

            // calculate the harmonic mean of the set registers
            return (int)Math.Ceiling(GetAlpha(P) * setRegisters.Count * (setRegisters.Count / z));
        }

        private static double GetPercentageDifference(double start, double end)
        {
            var increase = end - start;
            var percentage = Math.Abs(increase) / start;

            return percentage;
        }

        /// <summary>
        /// Gets the appropriate alpha for the given <paramref name="m" />
        /// </summary>
        /// <param name="m">size of the lookup table</param>
        /// <returns>alpha for bias correction</returns>
        private double GetAlpha(int m)
        {
            switch (m)
            {
                case 16:
                    return 0.673;
                case 32:
                    return 0.697;
                case 64:
                    return 0.709;
                default:
                    return 0.7213 / (1 + (1.079 / m));
            }
        }

    }
}
