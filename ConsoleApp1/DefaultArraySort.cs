using System;

namespace Sort
{
    public class DefaultArraySort : ISort<int[]>
    {
        public int[] Sort(int[] arr) {
            Array.Sort(arr);
            return arr;
        }
    }
}
