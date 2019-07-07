using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sort;

namespace TestSort
{
    [TestClass]
    public class TestSort {
        public static ISort[] Sorts = new ISort[] {new DefaultArraySort()};

        [TestMethod]
        public void TestSort_Simple() {
            VerifySort(input: new[] { 1, 9, 5, 3, 2 }, expected: new int[] { 1, 2, 3, 5, 9 });
        }

        public static void VerifySort(int[] input, int[] expected) {
            foreach (ISort sort in Sorts) {
                int[] actual = sort.Sort(input);
                CollectionAssert.AreEqual(expected, actual);
            }
        }
    }
}
