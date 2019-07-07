using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sort;

namespace TestSort
{
    [TestClass]
    public class TestSort {
        public static ISort[] Sorts = new ISort[] {new DefaultArraySort()};

        [TestMethod]
        public void TestSort_Simple()
        {
            VerifySort(input: new[] { 1, 9, 5, 3, 2 }, expected: new int[] { 1, 2, 3, 5, 9 });
        }

        [TestMethod]
        public void TestSort_Reverse()
        {
            VerifySort(input: new[] { 5,4,3,2,1,0 }, expected: new int[] { 0,1,2,3,4,5 });
        }

        [TestMethod]
        public void TestSort_Duplicates()
        {
            VerifySort(input: new[] { 1, 1, 5, 1, 2 }, expected: new int[] { 1, 1, 1, 2, 5 });
        }

        [TestMethod]
        public void TestSort_Sorted()
        {
            VerifySort(input: new[] { 1, 2, 3, 4, 5 }, expected: new int[] { 1, 2, 3, 4, 5 });
        }

        [TestMethod]
        public void TestSort_Negatives_All()
        {
            VerifySort(input: new[] { -1, -9, -5, -3, -2 }, expected: new int[] { -9, -5, -3, -2, -1 });
        }

        [TestMethod]
        public void TestSort_Negatives_Mixed()
        {
            VerifySort(input: new[] { -1, 9, 0, -5, 3, 2 }, expected: new int[] { -5, -1, 0, 2, 3, 9 });
        }

        [TestMethod]
        public void TestSort_Zeroes_All()
        {
            VerifySort(input: new[] { 0, 0, 0 }, expected: new int[] { 0, 0, 0 });
        }

        [TestMethod]
        public void TestSort_Zeroes_Mixed()
        {
            VerifySort(input: new[] { 0, 8, 0 }, expected: new int[] { 0, 0, 8 });
        }

        [TestMethod]
        public void TestSort_Fuzz_Small()
        {
            VerifyFuzz(10, 10);
        }

        [TestMethod]
        public void TestSort_Fuzz_Large()
        {
            VerifyFuzz(10000, 10000000);
        }

        public static void VerifyFuzz(uint arrSize, int range) {
            var random = new Random();
            var input = new int[arrSize];
            for (int i = 0; i < arrSize; ++i)
            {
                input[i] = random.Next(minValue: -range, maxValue: range);
            }

            var arr = (int[])input.Clone();
            Array.Sort(input);
            VerifySort(input: arr, expected: input);
        }

        public static void VerifySort(int[] input, int[] expected) {
            foreach (ISort sort in Sorts) {
                int[] actual = sort.Sort(input);
                CollectionAssert.AreEqual(expected, actual);
            }
        }
    }
}
