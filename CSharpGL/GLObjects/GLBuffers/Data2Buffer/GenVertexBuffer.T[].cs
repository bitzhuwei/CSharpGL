using System;
using System.Runtime.InteropServices;

namespace CSharpGL
{
    public static partial class Data2Buffer
    {

        /// <summary>
        /// 获取顶点属性Buffer。描述顶点的位置或颜色或UV等各种属性。
        /// <para>每个<see cref="VertexBuffer"/>仅描述其中一个属性。</para>
        /// <para>Vertex Buffer Object that describes vertex' property(position, color, uv coordinate, etc.).</para>
        /// <para>Each <see cref="VertexBuffer"/> describes only 1 property.</para>
        /// </summary>
        /// <param name="array"></param>
        /// <param name="config">This <paramref name="config"/> decides parameters' values in glVertexAttribPointer(attributeLocation, size, type, false, 0, IntPtr.Zero);</param>
        /// <param name="usage"></param>
        /// <param name="instancedDivisor">0: not instanced. 1: instanced divisor is 1.</param>
        /// <param name="patchVertexes">How many vertexes makes a patch? No patch if <paramref name="patchVertexes"/> is 0.</param>
        /// <returns></returns>
        public static VertexBuffer GenVertexBuffer<T>(this T[] array, VBOConfig config, BufferUsage usage, uint instancedDivisor = 0, int patchVertexes = 0) where T : struct
        {
            GCHandle pinned = GCHandle.Alloc(array, GCHandleType.Pinned);
            IntPtr header = pinned.AddrOfPinnedObject();
            // same result with: IntPtr header = Marshal.UnsafeAddrOfPinnedArrayElement(array, 0);
            UnmanagedArrayBase unmanagedArray = new TempUnmanagedArray<T>(header, array.Length);// It's not neecessary to call Dispose() for this unmanaged array.
            VertexBuffer buffer = GenVertexBuffer(unmanagedArray, config, usage, instancedDivisor, patchVertexes);
            pinned.Free();

            return buffer;
        }

    }
}