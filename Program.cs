//Britton Whitaker, 9/10/2024, Lab 2 (Merge Sort)

using System;

namespace MergeSortLab
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Diagnostics.Debug.Assert(Enumerable.SequenceEqual(CombineSortedArrays(new int[] { 1, 3, 5 }, new int[] { -5, 3, 6, 7 }),new int[] { -5, 1, 3, 3, 5, 6, 7 }));
            System.Diagnostics.Debug.Assert(Enumerable.SequenceEqual(CombineSortedArrays(new int[]{-5, 2, 5, 8, 10}, new int[]{1, 2, 5}),new int[]{-5, 1, 2, 2, 5, 5, 8, 10}));

            int[] a = { 1, 3, 5, 7, 9 };
            int[] b = { 2, 4, 6, 27 };
            int[] result = CombineSortedArrays(a, b);
            Console.WriteLine(string.Join(", ", result));
        }

        public static int[] CombineSortedArrays(int[] a, int[] b)
        {
            int[] result = new int[a.Length + b.Length];
            int aCount = 0;
            int bCount = 0;

            for (int i = 0; i < result.Length; i++)
            {
                if (aCount >= a.Length)
                {
                    result[i] = b[bCount];
                    bCount++;
                }
                else if (bCount >= b.Length)
                {
                    result[i] = a[aCount];
                    aCount++;
                }
                else if (a[aCount] < b[bCount])
                {
                    result[i] = a[aCount];
                    aCount++;
                }
                else
                {
                    result[i] = b[bCount];
                    bCount++;
                }
            }

            return result;
        }


    }
}
