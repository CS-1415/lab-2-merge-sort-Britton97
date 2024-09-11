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
            System.Diagnostics.Debug.Assert(Enumerable.SequenceEqual(SortViaMergesort(new int[]{6, 1, -5, 3, 5, 3, 7}),new int[]{-5, 1, 3, 3, 5, 6, 7}));
            System.Diagnostics.Debug.Assert(Enumerable.SequenceEqual(SortViaMergesort(new int[]{1, 10, -5, 2, 5, 2, 5, 8}),new int[]{-5, 1, 2, 2, 5, 5, 8, 10}));

            int[] a = { 1, 3, 5, 7, 9 };
            int[] b = { 2, 4, 6, 27 };
            //int[] result = CombineSortedArrays(a, b);
            int[] result = SortViaMergesort(new int[] { 38, 27, 43, 3, 9, 82, 10 });
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

        //this works by giving MergeSort an array, 
        //if the array is one long then it returns the array
        //else it splits the array in half and calls MergeSort on the left and right halves
        //it will continue until each array is one long
        //at the bottom it will give the the left and right arrays of size 1 to combineSortedArrays and make a sorted array of size 2
        //then keep combining the progressively larger sorted arrays until the original array is sorted
        public static int[] SortViaMergesort(int[] a)
        {
            if (a.Length <= 1) //reached the bottom of the recursion
            {
                return a;
            }

            int middle = a.Length / 2; //split the array in half
            int[] left = new int[middle]; //create two new arrays to hold the left and right halves
            int[] right = new int[a.Length - middle];

            for (int i = 0; i < left.Length; i++) //populate the left array by copying the first half of the original array
            {
                left[i] = a[i];
            }

            for (int i = 0; i < right.Length; i++) //populate the right array by copying the second half of the original array
            {
                right[i] = a[i + middle];
            }

            left = SortViaMergesort(left); //recursively call MergeSort on the left and right arrays
            right = SortViaMergesort(right);

            return CombineSortedArrays(left, right); //combine the sorted left and right arrays
        }
    }
}
