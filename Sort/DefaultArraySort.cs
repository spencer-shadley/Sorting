using System;

namespace Sort
{
    public class DefaultArraySort : ISort
    {
        public int[] Sort(int[] arr) {
            Array.Sort(arr);
            return arr;
        }
    }
}
