using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Helper class for sorting unmanaged array.
    /// </summary>
    public static partial class SortingHelper
    {
        //static void Test()
        //{
        //    IntPtr pointer = IntPtr.Zero;// map, new, etc...
        //    unsafe
        //    {
        //        var array = (vec3*)pointer.ToPointer();
        //        int start = 0;
        //        int length = 100;
        //        Func<vec3, vec3, int> comparer = null;
        //        Sort(pointer, start, length, comparer);
        //    }
        //}

        ///// <summary>
        ///// Sort unmanaged array specified with <paramref name="pointer"/> at specified area.
        ///// </summary>
        ///// <param name="pointer"></param>
        ///// <param name="start">index of first value to be sorted.</param>
        ///// <param name="length">length of <paramref name="pointer"/> to bo sorted.</param>
        ///// <param name="comparer">
        ///// If you want descending sort, make it returns -1 when <paramref name="pointer"/>[left] &lt; <paramref name="pointer"/>[right].
        ///// <para>Otherwise, make it returns -1 when <paramref name="pointer"/>[left] &gt; <paramref name="pointer"/>[right].</para></param>
        //public static void Sort<T>(this IntPtr pointer, int start, int length, Func<T, T, int> comparer) where T : struct
        //{
        //    QuickSort(pointer, start, start + length - 1, comparer);
        //}

        //private static void QuickSort<T>(IntPtr pointer, int start, int end, Func<T, T, int> comparer) where T : struct
        //{
        //    Type type = typeof(T);
        //    int elementSize = Marshal.SizeOf(type);

        //    var stack = new Stack<int>();
        //    if (start < end)
        //    {
        //        stack.Push(end); stack.Push(start);
        //        while (stack.Count > 0)
        //        {
        //            int left = stack.Pop();
        //            int right = stack.Pop();
        //            int index = QuickSortPartion(pointer, left, right, comparer, type, elementSize);
        //            if (left < index - 1)
        //            {
        //                stack.Push(index - 1); stack.Push(left);
        //            }
        //            if (index + 1 < right)
        //            {
        //                stack.Push(right); stack.Push(index + 1);
        //            }
        //        }
        //    }
        //}

        //private static int QuickSortPartion<T>(IntPtr pointer, int start, int end, Func<T, T, int> comparer, Type type, int elementSize) where T : struct
        //{
        //    var pivotIndex = new IntPtr((int)pointer + start * elementSize);
        //    T pivot = (T)Marshal.PtrToStructure(pivotIndex, type);
        //    while (start < end)
        //    {
        //        var endIndex = new IntPtr((int)pointer + end * elementSize);
        //        T endValue = (T)Marshal.PtrToStructure(endIndex, type);
        //        while (start < end && comparer(endValue, pivot) < 0)
        //        {
        //            end--;
        //            endIndex = new IntPtr((int)pointer + end * elementSize);
        //            endValue = (T)Marshal.PtrToStructure(endIndex, type);
        //        }
        //        var startIndex = new IntPtr((int)pointer + start * elementSize);
        //        Marshal.StructureToPtr(endValue, startIndex, true);
        //        T startValue = (T)Marshal.PtrToStructure(startIndex, type);
        //        while (start < end && comparer(startValue, pivot) < 0)
        //        {
        //            start++;
        //            startIndex = new IntPtr((int)pointer + start * elementSize);
        //            startValue = (T)Marshal.PtrToStructure(startIndex, type);
        //        }
        //        Marshal.StructureToPtr(startValue, endIndex, true);
        //    }
        //    {
        //        var startIndex = new IntPtr((int)pointer + start * elementSize);
        //        Marshal.StructureToPtr(pivot, startIndex, true);
        //    }

        //    return start;
        //}
        /// <summary>
        /// Sort unmanaged array specified with <paramref name="pointer"/> at specified area.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="descending">true for descending sort; otherwise false.</param>
        public static void Sort<T>(this UnmanagedArray<T> array, bool descending = true) where T : struct,IComparable<T>
        {
            array.Sort(0, array.Length, descending);
        }
        /// <summary>
        /// Sort unmanaged array specified with <paramref name="pointer"/> at specified area.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="start">index of first value to be sorted.</param>
        /// <param name="length">length of <paramref name="pointer"/> to bo sorted.</param>
        /// <param name="descending">true for descending sort; otherwise false.</param>
        public static void Sort<T>(this UnmanagedArray<T> array, int start, int length, bool descending = true) where T : struct,IComparable<T>
        {
            if (array == null) { throw new ArgumentNullException("array"); }
            if (array.Header == IntPtr.Zero) { throw new Exception("Invalid array"); }
            if (array.Length < start + length) { throw new ArgumentOutOfRangeException(string.Format("Error: {0} < {1} + {2}", array.Length, start, length)); }

            IntPtr pointer = array.Header;
            Type type = typeof(T);
            int elementSize = Marshal.SizeOf(type);
            bool exchanges;
            do
            {
                exchanges = false;
                for (int i = 0; i < length - 1; i++)
                {
                    var index1 = new IntPtr((int)pointer + (start + i) * elementSize);
                    var index2 = new IntPtr((int)pointer + (start + i + 1) * elementSize);
                    T value1 = (T)Marshal.PtrToStructure(index1, type);
                    T value2 = (T)Marshal.PtrToStructure(index2, type);
                    if (descending)
                    {
                        if (value1.CompareTo(value2) < 0)
                        {
                            Marshal.StructureToPtr(value1, index2, true);
                            Marshal.StructureToPtr(value2, index1, true);
                            //当某轮比较没有发生移动时，就可以确定排序完成了
                            //否则应该继续排序
                            exchanges = true;
                        }
                    }
                    else // ascending
                    {
                        if (value1.CompareTo(value2) > 0)
                        {
                            Marshal.StructureToPtr(value1, index2, true);
                            Marshal.StructureToPtr(value2, index1, true);
                            //当某轮比较没有发生移动时，就可以确定排序完成了
                            //否则应该继续排序
                            exchanges = true;
                        }
                    }
                }
            } while (exchanges);
        }

        /// <summary>
        /// Sort unmanaged array specified with <paramref name="pointer"/> at specified area.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="start">index of first value to be sorted.</param>
        /// <param name="length">length of <paramref name="pointer"/> to bo sorted.</param>
        /// <param name="comparer">
        /// If you want descending sort, make it returns -1 when <paramref name="pointer"/>[left] &lt; <paramref name="pointer"/>[right].
        /// <para>Otherwise, make it returns -1 when <paramref name="pointer"/>[left] &gt; <paramref name="pointer"/>[right].</para></param>
        public static void Sort<T>(this UnmanagedArray<T> array, int start, int length, Func<T, T, int> comparer) where T : struct
        {
            IntPtr pointer = array.Header;
            Type type = typeof(T);
            int elementSize = Marshal.SizeOf(type);
            bool exchanges;
            do
            {
                exchanges = false;
                for (int i = 0; i < length - 1; i++)
                {
                    var index1 = new IntPtr((int)pointer + (start + i) * elementSize);
                    var index2 = new IntPtr((int)pointer + (start + i + 1) * elementSize);
                    T value1 = (T)Marshal.PtrToStructure(index1, type);
                    T value2 = (T)Marshal.PtrToStructure(index2, type);
                    if (comparer(value1, value2) < 0)
                    {
                        Marshal.StructureToPtr(value1, index2, true);
                        Marshal.StructureToPtr(value2, index1, true);
                        //当某轮比较没有发生移动时，就可以确定排序完成了
                        //否则应该继续排序
                        exchanges = true;
                    }
                }
            } while (exchanges);
        }
    }
}