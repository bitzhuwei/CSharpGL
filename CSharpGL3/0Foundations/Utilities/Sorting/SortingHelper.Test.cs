using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    class SortingHelper
    {
        static void Test()
        {
            const int length = 17;
            var array = new UnmanagedArray<float>(length);
            unsafe
            {
                var p = (float*)array.Header.ToPointer();
                for (int i = 0; i < length; i++)
                {
                    p[i] = i + length;
                }


                array.Sort(comparer: Comparer<float>.Default);
                //array.Sort(descending: true);

                float[] p2 = new float[length];
                for (int i = 0; i < length; i++)
                {
                    p2[i] = p[i];
                }
                Console.WriteLine();
            }

        }
    }
}
