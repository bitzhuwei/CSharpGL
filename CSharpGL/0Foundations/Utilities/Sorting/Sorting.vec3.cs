using System;
using System.Runtime.InteropServices;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Helper class for sorting unmanaged array.
    /// </summary>
    public static partial class SortingHelper
    {
        /// <summary>
        /// Sort unmanaged array specified with <paramref name="pointer"/> at specified area.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <param name="comparer"></param>
        public static unsafe void Sort(vec3* array, int start, int length, Func<vec3, vec3, int> comparer)
        {
            bool exchanges;
            do
            {
                exchanges = false;
                for (int i = 0; i < length - 1; i++)
                {
                    if (comparer(array[start + i], array[start + i + 1]) < 0)
                    {
                        vec3 temp = array[start + i];
                        array[start + i] = array[start + i + 1];
                        array[start + i + 1] = temp;
                        //当某轮比较没有发生移动时，就可以确定排序完成了
                        //否则应该继续排序
                        exchanges = true;
                    }
                }
            } while (exchanges);
        }
    }
}