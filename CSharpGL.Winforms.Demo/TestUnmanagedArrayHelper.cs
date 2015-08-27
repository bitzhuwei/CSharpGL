using CSharpGL.Maths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Winforms.Demo
{
    class TestUnmanagedArrayHelper
    {

        public static void TypicalScene()
        {
            const int count = 1000000;

            long startTick = 0;
            long interval, interval2;

            // 测试float类型
            {
                var floatArray = new UnmanagedArray<float>(count);
                startTick = DateTime.Now.Ticks;
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
                interval = DateTime.Now.Ticks - startTick;

                unsafe
                {
                    startTick = DateTime.Now.Ticks;
                    float* header = (float*)floatArray.FirstElement();
                    float* last = (float*)floatArray.LastElement();
                    float* tailAddress = (float*)floatArray.TailAddress();
                    int value = 0;
                    for (float* ptr = header; ptr <= last/*or: ptr < tailAddress*/; ptr++)
                    {
                        *ptr = value++;
                    }
                    int i = 0;
                    for (float* ptr = header; ptr <= last/*or: ptr < tailAddress*/; ptr++, i++)
                    {
                        var item = *ptr;
                        if (item != i)
                        { throw new Exception(); }
                    }
                    interval2 = DateTime.Now.Ticks - startTick;
                }
                Console.WriteLine("Ticks: safe: {0} vs unsafe: {1}", interval, interval2);
            }


            // 测试decimal类型
            {
                var decimalArray = new UnmanagedArray<decimal>(count);
                startTick = DateTime.Now.Ticks;
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
                interval = DateTime.Now.Ticks - startTick;

                unsafe
                {
                    startTick = DateTime.Now.Ticks;
                    decimal* header = (decimal*)decimalArray.FirstElement();
                    decimal* last = (decimal*)decimalArray.LastElement();
                    decimal* tailAddress = (decimal*)decimalArray.TailAddress();
                    int value = 0;
                    for (decimal* ptr = header; ptr <= last/*or: ptr < tailAddress*/; ptr++)
                    {
                        *ptr = value++;
                    }
                    int i = 0;
                    for (decimal* ptr = header; ptr <= last/*or: ptr < tailAddress*/; ptr++, i++)
                    {
                        var item = *ptr;
                        if (item != i)
                        { throw new Exception(); }
                    }
                    interval2 = DateTime.Now.Ticks - startTick;
                }
                Console.WriteLine("Ticks: safe: {0} vs unsafe: {1}", interval, interval2);
            }


            // 测试int类型
            {
                var intArray = new UnmanagedArray<int>(count);
                startTick = DateTime.Now.Ticks;
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
                interval = DateTime.Now.Ticks - startTick;

                unsafe
                {
                    startTick = DateTime.Now.Ticks;
                    int* header = (int*)intArray.FirstElement();
                    int* last = (int*)intArray.LastElement();
                    int* tailAddress = (int*)intArray.TailAddress();
                    int value = 0;
                    for (int* ptr = header; ptr <= last/*or: ptr < tailAddress*/; ptr++)
                    {
                        *ptr = value++;
                    }
                    int i = 0;
                    for (int* ptr = header; ptr <= last/*or: ptr < tailAddress*/; ptr++, i++)
                    {
                        var item = *ptr;
                        if (item != i)
                        { throw new Exception(); }
                    }
                    interval2 = DateTime.Now.Ticks - startTick;
                }
                Console.WriteLine("Ticks: safe: {0} vs unsafe: {1}", interval, interval2);
            }


            // 测试bool类型
            {
                var boolArray = new UnmanagedArray<bool>(count);
                startTick = DateTime.Now.Ticks;
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
                interval = DateTime.Now.Ticks - startTick;

                unsafe
                {
                    startTick = DateTime.Now.Ticks;
                    bool* header = (bool*)boolArray.FirstElement();
                    bool* last = (bool*)boolArray.LastElement();
                    bool* tailAddress = (bool*)boolArray.TailAddress();
                    int value = 0;
                    for (bool* ptr = header; ptr <= last/*or: ptr < tailAddress*/; ptr++)
                    {
                        *ptr = (value % 2 == 0);
                        value++;
                    }
                    int i = 0;
                    for (bool* ptr = header; ptr <= last/*or: ptr < tailAddress*/; ptr++, i++)
                    {
                        var item = *ptr;
                        if (item != (i % 2 == 0))
                        { throw new Exception(); }
                    }
                    interval2 = DateTime.Now.Ticks - startTick;
                }
                Console.WriteLine("Ticks: safe: {0} vs unsafe: {1}", interval, interval2);
            }

            // 测试vec3类型
            {
                var vec3Array = new UnmanagedArray<vec3>(count);
                startTick = DateTime.Now.Ticks;
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
                interval = DateTime.Now.Ticks - startTick;

                unsafe
                {
                    startTick = DateTime.Now.Ticks;
                    vec3* header = (vec3*)vec3Array.FirstElement();
                    vec3* last = (vec3*)vec3Array.LastElement();
                    vec3* tailAddress = (vec3*)vec3Array.TailAddress();
                    int i = 0;
                    for (vec3* ptr = header; ptr <= last/*or: ptr < tailAddress*/; ptr++)
                    {
                        *ptr = new vec3(i * 3 + 0, i * 3 + 1, i * 3 + 2);
                        i++;
                    }
                    i = 0;
                    for (vec3* ptr = header; ptr <= last/*or: ptr < tailAddress*/; ptr++, i++)
                    {
                        var item = *ptr;
                        var old = new vec3(i * 3 + 0, i * 3 + 1, i * 3 + 2);
                        if (item.x != old.x || item.y != old.y || item.z != old.z)
                        { throw new Exception(); }
                    }
                    interval2 = DateTime.Now.Ticks - startTick;
                }
                Console.WriteLine("Ticks: safe: {0} vs unsafe: {1}", interval, interval2);

            }

            // 测试mat4类型
            {
                var vec3Array = new UnmanagedArray<mat4>(count);
                startTick = DateTime.Now.Ticks;
                for (int i = 0; i < count; i++)
                {
                    vec3Array[i] = new mat4(new vec4(i, i + 1, i + 2, i + 3), new vec4(i, i + 1, i + 2, i + 3), new vec4(i, i + 1, i + 2, i + 3), new vec4(i, i + 1, i + 2, i + 3));
                }
                for (int i = 0; i < count; i++)
                {
                    var item = vec3Array[i];
                    var old = new mat4(new vec4(i, i + 1, i + 2, i + 3), new vec4(i, i + 1, i + 2, i + 3), new vec4(i, i + 1, i + 2, i + 3), new vec4(i, i + 1, i + 2, i + 3));
                    for (int col = 0; col < 4; col++)
                    {
                        for (int row = 0; row < 4; row++)
                        {
                            if (item[col][row] != old[col][row])
                            { throw new Exception(); }
                        }
                    }
                }
                interval = DateTime.Now.Ticks - startTick;

                unsafe
                {
                    startTick = DateTime.Now.Ticks;
                    mat4* header = (mat4*)vec3Array.FirstElement();
                    mat4* last = (mat4*)vec3Array.LastElement();
                    mat4* tailAddress = (mat4*)vec3Array.TailAddress();
                    int i = 0;
                    for (mat4* ptr = header; ptr <= last/*or: ptr < tailAddress*/; ptr++)
                    {
                        *ptr = new mat4(new vec4(i, i + 1, i + 2, i + 3), new vec4(i, i + 1, i + 2, i + 3), new vec4(i, i + 1, i + 2, i + 3), new vec4(i, i + 1, i + 2, i + 3));
                        i++;
                    }
                    i = 0;
                    for (mat4* ptr = header; ptr <= last/*or: ptr < tailAddress*/; ptr++, i++)
                    {
                        var item = *ptr;
                        var old = new mat4(new vec4(i, i + 1, i + 2, i + 3), new vec4(i, i + 1, i + 2, i + 3), new vec4(i, i + 1, i + 2, i + 3), new vec4(i, i + 1, i + 2, i + 3));
                        for (int col = 0; col < 4; col++)
                        {
                            for (int row = 0; row < 4; row++)
                            {
                                if (item[col][row] != old[col][row])
                                { throw new Exception(); }
                            }
                        }
                    }
                    interval2 = DateTime.Now.Ticks - startTick;
                }
                Console.WriteLine("Ticks: safe: {0} vs unsafe: {1}", interval, interval2);

            }

            // 立即释放所有非托管数组占用的内存，任何之前创建的UnmanagedBase数组都不再可用了。
            UnmanagedArray<int>.FreeAll();
        }
    }
}
