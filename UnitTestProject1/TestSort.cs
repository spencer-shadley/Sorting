using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sort;

namespace TestSort
{
    [TestClass]
    public class TestSort
    {
        [TestMethod]
        public void TestSort_Simple() {
            ISort<int[]> sort = new DefaultArraySort();
            int[] actual = sort.Sort(new[] {1, 9, 5, 3, 2});
            var expected = new int[] {1, 2, 3, 5, 9};

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
