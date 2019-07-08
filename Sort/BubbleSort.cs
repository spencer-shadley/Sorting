using System;

namespace Sort
{
    public class BubbleSort : ISort
    {
        public int[] Sort(int[] arr) {
            if (arr == null) {
                throw new ArgumentNullException();
            }

            bool wasSwapped = false;
            do {
                for (int i = 0; i < arr.Length - 1; ++i) {
                    wasSwapped = false;

                    int left = arr[i];
                    int right = arr[i + 1];

                    if (left <= right) continue;

                    arr[i] = right;
                    arr[i + 1] = left;
                    wasSwapped = true;
                }
            } while (wasSwapped);

            return arr;
        }
    }
}
