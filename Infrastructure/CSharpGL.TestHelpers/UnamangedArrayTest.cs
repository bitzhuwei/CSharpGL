using System;
using System.IO;

namespace CSharpGL.TestHelpers
{
    public static class UnamangedArrayTest
    {
        /// <summary>
        /// This test shows that NOT all initial values in <see cref="UnmangedArray&lt;T&gt;"/> are zero.
        /// </summary>
        public static void TestInitialValue()
        {
            using (var writer = new StreamWriter("test-UnmanagedArray.txt"))
            {
                int length = 100000;
                {
                    var array1 = new UnmanagedArray<uint>(length);
                    unsafe
                    {
                        var array = (uint*)array1.Header.ToPointer();
                        for (int i = 0; i < length; i++)
                        {
                            if (array[i] != 0)
                            {
                                writer.WriteLine(string.Format("{0}: array[{1}] is [{2}].", typeof(uint), i, array[i]));
                            }
                        }
                    }
                }
                {
                    var array1 = new UnmanagedArray<vec3>(length);
                    unsafe
                    {
                        vec3 zero = new vec3(0, 0, 0);
                        var array = (vec3*)array1.Header.ToPointer();
                        for (int i = 0; i < length; i++)
                        {
                            if (array[i] != zero)
                            {
                                writer.WriteLine(string.Format("{0}: array[{1}] is [{2}].", typeof(vec3), i, array[i]));
                            }
                        }
                    }
                }
                {
                    var array1 = new UnmanagedArray<mat4>(length);
                    unsafe
                    {
                        mat4 zero = new mat4(0);
                        var array = (mat4*)array1.Header.ToPointer();
                        for (int i = 0; i < length; i++)
                        {
                            if (array[i] != zero)
                            {
                                writer.WriteLine(string.Format("{0}: array[{1}] is [{2}].", typeof(mat4), i, array[i]));
                            }
                        }
                    }
                }

                writer.WriteLine("Test finished.");
            }
        }
    }
}