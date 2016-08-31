using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// pixel unpack buffer's pointer.
    /// </summary>
    public class PixelUnpackBufferPtr : BufferPtr
    {
        /// <summary>
        /// 
        /// </summary>
        protected static OpenGL.glVertexAttribPointer glVertexAttribPointer;
        /// <summary>
        /// 
        /// </summary>
        protected static OpenGL.glEnableVertexAttribArray glEnableVertexAttribArray;

        /// <summary>
        /// pixel unpack buffer's pointer.
        /// </summary>
        /// <param name="bufferId">用glGenBuffers()得到的VBO的Id。<para>Id got from glGenBuffers();</para></param>
        /// <param name="dataSize">second parameter in glVertexAttribPointer(attributeLocation, size, type, false, 0, IntPtr.Zero);
        /// </param>
        /// <param name="dataType">third parameter in glVertexAttribPointer(attributeLocation, size, type, false, 0, IntPtr.Zero);
        /// </param>
        /// <param name="length">此VBO含有多个个元素？<para>How many elements?</para></param>
        /// <param name="byteLength">此VBO中的数据在内存中占用多少个字节？<para>How many bytes in this buffer?</para></param>
        internal PixelUnpackBufferPtr(
            uint bufferId, int dataSize, uint dataType, int length, int byteLength)
            : base(bufferId, length, byteLength)
        {
            if (glVertexAttribPointer == null)
            {
                glVertexAttribPointer = OpenGL.GetDelegateFor<OpenGL.glVertexAttribPointer>();
                glEnableVertexAttribArray = OpenGL.GetDelegateFor<OpenGL.glEnableVertexAttribArray>();
            }
            this.DataSize = dataSize;
            this.DataType = dataType;
        }

        /// <summary>
        /// GL_FLOAT etc
        /// <para>third parameter in glVertexAttribPointer(uint index, int size, uint type, bool normalized, int stride, IntPtr pointer);</para>
        /// </summary>
        public uint DataType { get; private set; }

        /// <summary>
        /// <see cref="DataType"/>有多少字节？
        /// </summary>
        public int DataTypeByteLength
        {
            get
            {
                if (DataType == OpenGL.GL_FLOAT)
                { return sizeof(float); }
                else if (DataType == OpenGL.GL_BYTE)
                { return sizeof(byte); }
                else if (DataType == OpenGL.GL_UNSIGNED_BYTE)
                { return sizeof(byte); }
                else if (DataType == OpenGL.GL_SHORT)
                { return sizeof(short); }
                else if (DataType == OpenGL.GL_UNSIGNED_SHORT)
                { return sizeof(ushort); }
                else
                { throw new NotImplementedException(); }
            }
        }

        /// <summary>
        /// second parameter in glVertexAttribPointer(uint index, int size, uint type, bool normalized, int stride, IntPtr pointer);
        /// </summary>
        public int DataSize { get; private set; }

        /// <summary>
        /// 在使用<see cref="VertexArrayObject"/>后，此方法只会执行一次。
        /// This method will only be invoked once when using <see cref="VertexArrayObject"/>.
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="shaderProgram"></param>
        public override void Render(RenderEventArgs arg, ShaderProgram shaderProgram)
        {
            // 选中此VBO
            // select this VBO.
            glBindBuffer(OpenGL.GL_PIXEL_UNPACK_BUFFER, this.BufferId);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Bind()
        {
            OpenGL.BindBuffer(OpenGL.GL_PIXEL_UNPACK_BUFFER, this.BufferId);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Unbind()
        {
            OpenGL.BindBuffer(OpenGL.GL_PIXEL_UNPACK_BUFFER, 0);
        }
    }
}
