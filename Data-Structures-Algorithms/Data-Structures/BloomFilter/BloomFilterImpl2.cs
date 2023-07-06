using System;
using System.Collections;

namespace Data_Structures_Algorithms.Data_Structures
{
    public class BloomFilterImpl2
    {
        private BitArray bits = new BitArray(32);

        public void Test() 
        {
            BloomFilterImpl2 bloom = new BloomFilterImpl2();
            bloom.Add("string");
            bloom.Add("fresh");
            bloom.Add("basketball");
            bloom.CheckFor("basketball");
            bloom.CheckFor("soccer");
            Console.ReadLine();
        }

        // two toy hashing functions,
        private int RotateMore(string AddString)
        {
            int returnValue = 0;
            for (int i = 0; i < AddString.Length; i++)
            {
                returnValue += (int)(AddString[i] * i);
                returnValue %= 32;
            }
            return returnValue;
        }

        private int Rotate(string AddString)
        {
            int returnValue = 0;
            for (int i = 0; i < AddString.Length; i++)
            {
                returnValue += ((int)AddString[i]);
                returnValue %= 32;
            }
            return returnValue;
        }
        private void Add(string AddString)
        {
            Console.WriteLine("adding " + AddString);

            int Point1 = Rotate(AddString);
            int Point2 = RotateMore(AddString);
            bits[Point1] = true;
            bits[Point2] = true;

        }
        private bool Contains(string CheckString)
        {
            int Point1 = Rotate(CheckString);
            int Point2 = RotateMore(CheckString);
            if (bits[Point1] && bits[Point2])
                return true;
            else
                return false;
        }
        private void CheckFor(String key)
        {
            if (Contains(key))
                Console.WriteLine(key + " may be in there");
            else
                Console.WriteLine(key + " is not there");
        }
    }
}
