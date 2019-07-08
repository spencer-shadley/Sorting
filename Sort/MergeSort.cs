using System;
using System.Linq;

namespace Sort
{
    public class MergeSort : ISort
    {
        public int[] Sort(int[] arr) {
            if (arr == null) {
                throw new ArgumentNullException();
            }

            if (arr.Length == 1) {
                return arr;
            }

            int mid = arr.Length / 2;
            int[] left = arr.Take(mid).ToArray();
            int[] right = arr.Skip(mid).ToArray();

            left = this.Sort(left);
            right = this.Sort(right);
            return this.Merge(left, right);
        }

        public int[] Merge(int[] left, int[] right) {
            var sorted = new int[left.Length + right.Length];

            int sortedIndex = 0, leftIndex = 0, rightIndex = 0;

            while (sortedIndex < left.Length + right.Length) {
                if (leftIndex >= left.Length) {
                    sorted[sortedIndex++] = right[rightIndex++];
                } else if (rightIndex >= right.Length) {
                    sorted[sortedIndex++] = left[leftIndex++];
                }
                else {
                    sorted[sortedIndex++] = left[leftIndex] < right[rightIndex] ? left[leftIndex++] : right[rightIndex++];
                }
            }

            return sorted;
        }
    }
}
