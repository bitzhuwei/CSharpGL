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
        /// <param name="start">index of first value to be sorted.</param>
        /// <param name="length">length of <paramref name="array"/> to bo sorted.</param>
        /// <param name="comparer">
        /// If you want descending sort, make it returns -1 when <paramref name="array"/>[left] &lt; <paramref name="array"/>[right].
        /// <para>Otherwise, make it returns -1 when <paramref name="array"/>[left] &gt; <paramref name="array"/>[right].</para></param>
        public static void Sort(UnmanagedArray<TemplateStructType> array, int start, int length, Comparer<TemplateStructType> comparer)
        {
            QuickSort(array, start, start + length - 1, comparer);
        }

        private static void QuickSort(UnmanagedArray<TemplateStructType> array, int start, int end, Comparer<TemplateStructType> comparer)
        {
            if (start >= end) { return; }

            Stack<int> stack = new Stack<int>();
            stack.Push(end);
            stack.Push(start);
            QuickSort(array, comparer, stack);
        }

        private static void QuickSort(UnmanagedArray<TemplateStructType> array, Comparer<TemplateStructType> comparer, Stack<int> stack)
        {
            while (stack.Count > 0)
            {
                int start = stack.Pop();
                int end = stack.Pop();
                int index = QuickSortPartion(array, start, end, comparer);
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

        private static unsafe int QuickSortPartion(UnmanagedArray<TemplateStructType> array, int start, int end, Comparer<TemplateStructType> comparer)
        {
            TemplateStructType* pointer = (TemplateStructType*)array.Header.ToPointer();
            TemplateStructType pivot, startValue, endValue;
            pivot = pointer[start];
            while (start < end)
            {
                startValue = pointer[start];
                while (start < end && comparer.Compare(startValue, pivot) > 0)
                {
                    start++;
                    startValue = pointer[start];
                }

                endValue = pointer[end];
                while (start < end && comparer.Compare(endValue, pivot) < 0)
                {
                    end--;
                    endValue = pointer[end];
                }
                if (start < end)
                {
                    pointer[end] = startValue;
                    pointer[start] = endValue;
                }
            }

            return start;
        }

    }
}