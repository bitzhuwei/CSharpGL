using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects.VertexBuffers
{
    /// <summary>
    /// 顶点的属性数组。描述顶点的位置或颜色或UV等各种属性。
    /// <para>每个<see cref="PropertyBuffer"/>仅描述其中一个属性。</para>
    /// </summary>
    public abstract class PropertyBuffer : VertexBuffer
    {

        /// <summary>
        /// 顶点的属性数组。描述顶点的位置或颜色或UV等各种属性。
        /// <para>每个<see cref="PropertyBuffer"/>仅描述其中一个属性。</para>
        /// </summary>
        /// <param name="dataSize">gl.VertexAttribPointer(attributeLocation, 3, OpenGL.GL_FLOAT, false, 0, IntPtr.Zero);
        /// <para>表示第2个参数</para>
        /// </param>
        /// <param name="dataType">GL_FLOAT etc
        /// <para>gl.VertexAttribPointer(attributeLocation, 3, OpenGL.GL_FLOAT, false, 0, IntPtr.Zero);</para>
        /// <para>表示第3个参数</para>
        /// </param>
        public PropertyBuffer(int dataSize, uint dataType)
        {
            this.DataSize = DataSize;
            this.DataType = DataType;
        }

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
    }
}
