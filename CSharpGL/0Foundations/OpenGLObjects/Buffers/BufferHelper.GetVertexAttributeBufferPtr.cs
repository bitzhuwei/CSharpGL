using System;

namespace CSharpGL
{
    /// <summary>
    /// Vertex Buffer Object.
    /// </summary>
    public static partial class BufferHelper
    {

        /// <summary>
        /// 获取顶点属性Buffer。描述顶点的位置或颜色或UV等各种属性。
        /// <para>每个<see cref="VertexAttributeBuffer&lt;T&gt;"/>仅描述其中一个属性。</para>
        /// <para>Vertex Buffer Object that describes vertex' property(position, color, uv coordinate, etc.).</para>
        /// <para>Each <see cref="VertexAttributeBuffer&lt;T&gt;"/> describes only 1 property.</para>
        /// <para>Note: If <typeparamref name="T"/> matches one of this.Config's value, then (Ptr.ByteLength / (Ptr.DataSize * Ptr.DataTypeByteLength)) equals (Ptr.Length).</para>
        /// <para><typeparamref name="T"/> is type of element of this array in application level.</para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="varNameInVertexShader">此顶点属性VBO对应于vertex shader中的哪个in变量？<para>Mapping variable's name in vertex shader.</para></param>
        /// <param name="config">This <paramref name="config"/> decides parameters' values in glVertexAttribPointer(attributeLocation, size, type, false, 0, IntPtr.Zero);</param>
        /// <param name="usage"></param>
        /// <param name="instancedDivisor">0: not instanced. 1: instanced divisor is 1.</param>
        /// <param name="patchVertexes">How many vertexes makes a patch? No patch if <paramref name="patchVertexes"/> is 0.</param>
        /// <returns></returns>
        public static VertexAttributeBufferPtr GetVertexAttributeBufferPtr<T>(this UnmanagedArray<T> array, string varNameInVertexShader, VertexAttributeConfig config, BufferUsage usage, uint instancedDivisor = 0, int patchVertexes = 0) where T : struct
        {
            if (glGenBuffers == null)
            {

            }
            uint[] buffers = new uint[1];
            glGenBuffers(1, buffers);
            const uint target = OpenGL.GL_ARRAY_BUFFER;
            glBindBuffer(target, buffers[0]);
            glBufferData(target, array.ByteLength, array.Header, (uint)usage);
            glBindBuffer(target, 0);

            var bufferPtr = new VertexAttributeBufferPtr(
                varNameInVertexShader, buffers[0], config, array.Length, array.ByteLength, instancedDivisor, patchVertexes);

            return bufferPtr;
        }
    }
}