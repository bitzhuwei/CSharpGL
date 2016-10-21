using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CSharpGL
{
    /// <summary>
    /// Helper class for sorting unmanaged array.
    /// </summary>
    public static partial class SortingHelper
    {
        /// <summary>
        /// Sort unmanaged array specified with <paramref name="array"/> at specified area.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="descending">true for descending sort; otherwise false.</param>
        public static void Sort(this UnmanagedArray<float> array, bool descending)
        {
            QuickSort(array, 0, array.Length - 1, descending);
        }

        /// <summary>
        /// Sort unmanaged array specified with <paramref name="array"/> at specified area.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="start">index of first value to be sorted.</param>
        /// <param name="length">length of <paramref name="array"/> to bo sorted.</param>
        /// <param name="descending">true for descending sort; otherwise false.</param>
        public static void Sort(this UnmanagedArray<float> array, int start, int length, bool descending)
        {
            QuickSort(array, start, start + length - 1, descending);
        }

        private static void QuickSort(UnmanagedArray<float> array, int start, int end, bool descending)
        {
            if (start >= end) { return; }

            var stack = new Stack<int>();
            stack.Push(end);
            stack.Push(start);
            QuickSort(array, descending, stack);
        }

        private static void QuickSort(UnmanagedArray<float> array, bool descending, Stack<int> stack)
        {
            while (stack.Count > 0)
            {
                int start = stack.Pop();
                int end = stack.Pop();
                int index = QuickSortPartion(array, start, end, descending);
                if (start < index - 1)
                {
                    stack.Push(index - 1); stack.Push(start);
                }
                if (index + 1 < end)
                {
                    stack.Push(end); stack.Push(index + 1);
                }
            }
        }

        private static unsafe int QuickSortPartion(UnmanagedArray<float> array, int start, int end, bool descending)
        {
            var pointer = (float*)array.Header.ToPointer();
            float pivot, startValue, endValue;
            pivot = pointer[start];
            while (start < end)
            {
                startValue = pointer[start];
                while ((start < end)
                    && ((descending && (startValue.CompareTo(pivot) > 0))
                        || (!descending) && (startValue.CompareTo(pivot) < 0)))
                {
                    start++;
                    startValue = pointer[start];
                }

                endValue = pointer[end];
                while ((start < end)
                    && ((descending && (endValue.CompareTo(pivot) < 0))
                        || (!descending) && (endValue.CompareTo(pivot) > 0)))
                {
                    end--;
                    endValue = pointer[end];
                }

                if (start < end)
                {
                    pointer[start] = startValue;
                    pointer[end] = endValue;
                }
            }

            return start;
        }
    }
}