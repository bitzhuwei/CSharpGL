using System;
using System.Runtime.InteropServices;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Helper class for sorting unmanaged array.
    /// </summary>
    public static class SortingHelper
    {
        static void Test()
        {
            IntPtr pointer = IntPtr.Zero;// map, new, etc...
            unsafe
            {
                var array = (vec3*)pointer.ToPointer();
                int start = 0;
                int length = 100;
                Func<vec3, vec3, int> comparer = null;
                Sort(pointer, start, length, comparer);
            }
        }

        /// <summary>
        /// Sort unmanaged array specified with <paramref name="pointer"/> at specified area.
        /// </summary>
        /// <param name="pointer"></param>
        /// <param name="start">index of first value to be sorted.</param>
        /// <param name="length">length of <paramref name="pointer"/> to bo sorted.</param>
        /// <param name="comparer">
        /// If you want descending sort, make it returns -1 when <paramref name="pointer"/>[left] &lt; <paramref name="pointer"/>[right].
        /// <para>Otherwise, make it returns -1 when <paramref name="pointer"/>[left] &gt; <paramref name="pointer"/>[right].</para></param>
        private static void Sort<T>(this IntPtr pointer, int start, int length, Func<T, T, int> comparer) where T : struct
        {
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

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="array"></param>
        ///// <param name="start"></param>
        ///// <param name="length"></param>
        ///// <param name="comparer"></param>
        //public static unsafe void Sort(vec3* array, int start, int length, Func<vec3, vec3, int> comparer)
        //{
        //    bool exchanges;
        //    do
        //    {
        //        exchanges = false;
        //        for (int i = 0; i < length - 1; i++)
        //        {
        //            if (comparer(array[start + i], array[start + i + 1]) < 0)
        //            {
        //                vec3 temp = array[start + i];
        //                array[start + i] = array[start + i + 1];
        //                array[start + i + 1] = temp;
        //                //当某轮比较没有发生移动时，就可以确定排序完成了
        //                //否则应该继续排序
        //                exchanges = true;
        //            }
        //        }
        //    } while (exchanges);
        //}
    }
}