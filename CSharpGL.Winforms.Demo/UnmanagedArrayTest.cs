using CSharpGL.Maths;
using CSharpGL.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL.Winforms.Demo
{
    class UnmanagedArrayTest
    {
        internal static void TypicalScene()
        {
            const int count = 100;

            var floatArray = new UnmanagedArray<float>(count);
            for (int i = 0; i < count; i++)
            {
                floatArray[i] = i;
            }
            for (int i = 0; i < count; i++)
            {
                var item = floatArray[i];
                if (item != i)
                { throw new Exception(); }
            }

            var decimalArray = new UnmanagedArray<decimal>(count);
            for (int i = 0; i < count; i++)
            {
                decimalArray[i] = i;
            }
            for (int i = 0; i < count; i++)
            {
                var item = decimalArray[i];
                if (item != i)
                { throw new Exception(); }
            }


            var intArray = new UnmanagedArray<int>(count);
            for (int i = 0; i < count; i++)
            {
                intArray[i] = i;
            }
            for (int i = 0; i < count; i++)
            {
                var item = intArray[i];
                if (item != i)
                { throw new Exception(); }
            }


            var boolArray = new UnmanagedArray<bool>(count);
            for (int i = 0; i < count; i++)
            {
                boolArray[i] = i % 2 == 0;
            }
            for (int i = 0; i < count; i++)
            {
                var item = boolArray[i];
                if (item != (i % 2 == 0))
                { throw new Exception(); }
            }

            var vec3Array = new UnmanagedArray<vec3>(count);
            for (int i = 0; i < count; i++)
            {
                vec3Array[i] = new vec3(i * 3 + 0, i * 3 + 1, i * 3 + 2);
            }
            for (int i = 0; i < count; i++)
            {
                var item = vec3Array[i];
                var old = new vec3(i * 3 + 0, i * 3 + 1, i * 3 + 2);
                if (item.x != old.x || item.y != old.y || item.z != old.z)
                { throw new Exception(); }
            }

            foreach (var item in vec3Array.GetElements())
            {
                Console.WriteLine(item);
            }

            UnmanagedArray<int>.FreeAll();
        }
    }
}
