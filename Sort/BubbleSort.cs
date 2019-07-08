using System;

namespace Sort
{
    public class BubbleSort : ISort
    {
        public int[] Sort(int[] unsorted) {
            if (unsorted == null) {
                throw new ArgumentNullException();
            }

            bool wasSwapped = false;
            do {
                for (int i = 0; i < unsorted.Length - 1; ++i) {
                    wasSwapped = false;

                    int left = unsorted[i];
                    int right = unsorted[i + 1];

                    if (left <= right) continue;

                    unsorted[i] = right;
                    unsorted[i + 1] = left;
                    wasSwapped = true;
                }
            } while (wasSwapped);

            return unsorted;
        }
    }
}
