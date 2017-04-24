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
        /// <param name="comparer">
        /// If you want descending sort, make it returns -1 when <paramref name="array"/>[left] &lt; <paramref name="array"/>[right].
        /// <para>Otherwise, make it returns -1 when <paramref name="array"/>[left] &gt; <paramref name="array"/>[right].</para></param>
        public static void Sort<T>(this UnmanagedArray<T> array, Comparer<T> comparer) where T : struct
        {
            QuickSort(array, 0, array.Length - 1, comparer);
        }

        /// <summary>
        /// Sort unmanaged array specified with <paramref name="array"/> at specified area.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="start">index of first value to be sorted.</param>
        /// <param name="length">length of <paramref name="array"/> to bo sorted.</param>
        /// <param name="comparer">
        /// If you want descending sort, make it returns -1 when <paramref name="array"/>[left] &lt; <paramref name="array"/>[right].
        /// <para>Otherwise, make it returns -1 when <paramref name="array"/>[left] &gt; <paramref name="array"/>[right].</para></param>
        public static void Sort<T>(this UnmanagedArray<T> array, int start, int length, Comparer<T> comparer) where T : struct
        {
            QuickSort(array, start, start + length - 1, comparer);
        }

        private static void QuickSort<T>(UnmanagedArray<T> array, int start, int end, Comparer<T> comparer) where T : struct
        {
            if (start >= end) { return; }

            var stack = new Stack<int>();
            stack.Push(end);
            stack.Push(start);
            QuickSort(array, comparer, stack);
        }

        private static void QuickSort<T>(UnmanagedArray<T> array, Comparer<T> comparer, Stack<int> stack) where T : struct
        {
            IntPtr pointer = array.Header;
            Type type = typeof(T);
            int elementSize = Marshal.SizeOf(type);

            while (stack.Count > 0)
            {
                int start = stack.Pop();
                int end = stack.Pop();
                int index = QuickSortPartion(pointer, start, end, comparer, type, elementSize);
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

        private static int QuickSortPartion<T>(IntPtr pointer, int start, int end, Comparer<T> comparer, Type type, int elementSize) where T : struct
        {
            IntPtr pivotIndex, startIndex, endIndex;
            T pivot, startValue, endValue;
            pivotIndex = new IntPtr((int)pointer + start * elementSize);
            pivot = (T)Marshal.PtrToStructure(pivotIndex, type);
            while (start < end)
            {
                startIndex = new IntPtr((int)pointer + start * elementSize);
                startValue = (T)Marshal.PtrToStructure(startIndex, type);
                while (start < end && comparer(startValue, pivot) > 0)
                {
                    start++;
                    startIndex = new IntPtr((int)pointer + start * elementSize);
                    startValue = (T)Marshal.PtrToStructure(startIndex, type);
                }

                endIndex = new IntPtr((int)pointer + end * elementSize);
                endValue = (T)Marshal.PtrToStructure(endIndex, type);
                while (start < end && comparer(endValue, pivot) < 0)
                {
                    end--;
                    endIndex = new IntPtr((int)pointer + end * elementSize);
                    endValue = (T)Marshal.PtrToStructure(endIndex, type);
                }
                if (start < end)
                {
                    Marshal.StructureToPtr(endValue, startIndex, true);
                    Marshal.StructureToPtr(startValue, endIndex, true);
                }
            }

            return start;
        }

    }
}