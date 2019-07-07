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
        public void TestSort_Fuzz() {
            const uint arrSize = 100;
            const int randomRange = 10;

            var random = new Random();
            var input = new int[arrSize];
            for (int i = 0; i < arrSize; ++i) {
                input[i] = random.Next(minValue: -randomRange, maxValue: randomRange);
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