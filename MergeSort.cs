using System;

namespace SortingAlgorithms
{
    class MergeSort
    {
        public static void Sort<T>(T[] array) where T : IComparable
        {
            MergeSort_Recursive<T>(array, 0, array.Length - 1);
        }

        static private void DoMerge<T>(T[] subarray, int left, int mid, int right) where T : IComparable
        {
            T[] temp = new T[subarray.Length];
            int i, left_end, num_elements, tmp_pos;

            left_end = (mid - 1);
            tmp_pos = left;
            num_elements = (right - left + 1);

            while ((left <= left_end) && (mid <= right))
            {
                if (subarray[left].CompareTo(subarray[mid]) <= 0)
                    temp[tmp_pos++] = subarray[left++];
                else
                    temp[tmp_pos++] = subarray[mid++];
            }

            while (left <= left_end)
                temp[tmp_pos++] = subarray[left++];

            while (mid <= right)
                temp[tmp_pos++] = subarray[mid++];

            for (i = 0; i < num_elements; i++)
            {
                subarray[right] = temp[right];
                right--;
            }
        }

        static private void MergeSort_Recursive<T>(T[] subarray, int left, int right) where T : IComparable
        {
            int mid;

            if (right > left)
            {
                mid = (right + left) / 2;
                MergeSort_Recursive(subarray, left, mid);
                MergeSort_Recursive(subarray, (mid + 1), right);

                DoMerge<T>(subarray, left, (mid + 1), right);
            }
        }
    }
}
