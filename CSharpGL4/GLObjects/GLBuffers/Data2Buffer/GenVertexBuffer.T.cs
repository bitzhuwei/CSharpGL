using System;
using System.Runtime.InteropServices;

namespace CSharpGL
{
    public static partial class Data2Buffer
    {
        /// <summary>
        /// 生成顶点属性Buffer。描述顶点的位置或颜色或UV等各种属性。
        /// <para>每个<see cref="VertexBuffer"/>仅描述其中一个属性。</para>
        /// <para>Vertex Buffer Object that describes vertex' property(position, color, uv coordinate, etc.).</para>
        /// <para>Each <see cref="VertexBuffer"/> describes only 1 property.</para>
        /// </summary>
        /// <param name="data"></param>
        /// <param name="config">This <paramref name="config"/> decides parameters' values in glVertexAttribPointer(attributeLocation, size, type, false, 0, IntPtr.Zero);</param>
        /// <param name="usage"></param>
        /// <param name="instancedDivisor">0: not instanced. 1: instanced divisor is 1.</param>
        /// <param name="patchVertexes">How many vertexes makes a patch? No patch if <paramref name="patchVertexes"/> is 0.</param>
        /// <returns></returns>
        public static VertexBuffer GenVertexBuffer<T>(this T data, VBOConfig config, BufferUsage usage, uint instancedDivisor = 0, int patchVertexes = 0) where T : struct
        {
            var array = new T[] { data };
            return GenVertexBuffer(array, config, usage, instancedDivisor, patchVertexes);
            // another way to do this:
            //using (UnmanagedArrayBase unmanagedArray = new UnmanagedArray<T>(1))
            //{
            //    Marshal.StructureToPtr(data, unmanagedArray.Header, false);
            //    VertexBuffer buffer = GetVertexBufferObject(unmanagedArray, config, usage, instancedDivisor, patchVertexes);
            //    return buffer;
            //}
        }
    }
}