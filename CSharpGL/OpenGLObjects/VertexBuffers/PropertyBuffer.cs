using GLM;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    /// <summary>
    /// 顶点的属性数组。描述顶点的位置或颜色或UV等各种属性。
    /// <para>每个<see cref="PropertyBuffer"/>仅描述其中一个属性。</para>
    /// </summary>
    /// <typeparam name="T">此buffer存储的是哪种struct的数据？</typeparam>
    public class PropertyBuffer<T> : VertexBuffer<T> where T : struct
    {

        /// <summary>
        /// 顶点的属性数组。描述顶点的位置或颜色或UV等各种属性。
        /// <para>每个<see cref="PropertyBuffer"/>仅描述其中一个属性。</para>
        /// </summary>
        /// <param name="varNameInVertexShader">此顶点属性VBO对应于vertex shader中的哪个in变量？</param>
        /// <param name="dataSize">gl.VertexAttribPointer(attributeLocation, 3, OpenGL.GL_FLOAT, false, 0, IntPtr.Zero);
        /// <para>表示第2个参数</para>
        /// </param>
        /// <param name="dataType">GL_FLOAT etc
        /// <para>gl.VertexAttribPointer(attributeLocation, 3, OpenGL.GL_FLOAT, false, 0, IntPtr.Zero);</para>
        /// <para>表示第3个参数</para>
        /// </param>
        /// <param name="usage"></param>
        public PropertyBuffer(string varNameInVertexShader, int dataSize, uint dataType, BufferUsage usage)
            : base(usage)
        {
            Debug.Assert(typeof(T) == typeof(float) || typeof(T) == typeof(vec2) || typeof(T) == typeof(vec3) || typeof(T) == typeof(vec4));

            this.VarNameInVertexShader = varNameInVertexShader;
            this.DataSize = dataSize;
            this.DataType = dataType;
        }

        /// <summary>
        /// 此顶点属性VBO对应于vertex shader中的哪个in变量？
        /// </summary>
        public string VarNameInVertexShader { get; private set; }

        /// <summary>
        /// GL_FLOAT etc
        /// <para>gl.VertexAttribPointer(uint index, int size, uint type, bool normalized, int stride, IntPtr pointer);</para>
        /// <para>gl.VertexAttribPointer(attributeLocation, 3, OpenGL.GL_FLOAT, false, 0, IntPtr.Zero);</para>
        /// <para>表示第3个参数</para>
        /// </summary>
        public uint DataType { get; private set; }

        /// <summary>
        /// gl.VertexAttribPointer(attributeLocation, 3, OpenGL.GL_FLOAT, false, 0, IntPtr.Zero);
        /// <para>表示第2个参数</para>
        /// </summary>
        public int DataSize { get; private set; }

        protected override VertexBufferPtr Upload2GPU()
        {
            uint[] buffers = new uint[1];
            GL.GetDelegateFor<GL.glGenBuffers>()(1, buffers);
            GL.GetDelegateFor<GL.glBindBuffer>()(GL.GL_ARRAY_BUFFER, buffers[0]);
            GL.GetDelegateFor<GL.glBufferData>()(GL.GL_ARRAY_BUFFER, this.ByteLength, this.Header, (uint)this.Usage);

            PropertyBufferPtr bufferPtr = new PropertyBufferPtr(
                this.VarNameInVertexShader, buffers[0], this.DataSize, this.DataType, this.Length, this.ByteLength);

            return bufferPtr;
        }
    }
}
