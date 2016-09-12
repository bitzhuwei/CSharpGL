using System;

namespace CSharpGL
{
    /// <summary>
    /// Vertex' property buffer's pointer.
    /// </summary>
    public class VertexAttributeBufferPtr : BufferPtr
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
        /// 
        /// </summary>
        protected static OpenGL.glVertexAttribDivisor glVertexAttribDivisor;

        /// <summary>
        /// Vertex' property buffer's pointer.
        /// </summary>
        /// <param name="varNameInVertexShader">此顶点属性VBO对应于vertex shader中的哪个in变量？<para>Mapping variable's name in vertex shader.</para></param>
        /// <param name="bufferId">用glGenBuffers()得到的VBO的Id。<para>Id got from glGenBuffers();</para></param>
        /// <param name="dataSize">second parameter in glVertexAttribPointer(attributeLocation, size, type, false, 0, IntPtr.Zero);
        /// <para>How many float/int/uint are there in a data unit?</para>
        /// </param>
        /// <param name="dataType">third parameter in glVertexAttribPointer(attributeLocation, size, type, false, 0, IntPtr.Zero);
        /// </param>
        /// <param name="length">此VBO含有多个个元素？<para>How many elements?</para></param>
        /// <param name="byteLength">此VBO中的数据在内存中占用多少个字节？<para>How many bytes in this buffer?</para></param>
        /// <param name="instancedDivisor">0: not instanced. 1: instanced divisor is 1.</param>
        internal VertexAttributeBufferPtr(string varNameInVertexShader,
            uint bufferId, int dataSize, uint dataType, int length, int byteLength,
            uint instancedDivisor)
            : base(bufferId, length, byteLength)
        {
            if (glVertexAttribPointer == null)
            {
                glVertexAttribPointer = OpenGL.GetDelegateFor<OpenGL.glVertexAttribPointer>();
                glEnableVertexAttribArray = OpenGL.GetDelegateFor<OpenGL.glEnableVertexAttribArray>();
                glVertexAttribDivisor = OpenGL.GetDelegateFor<OpenGL.glVertexAttribDivisor>();
            }
            this.VarNameInVertexShader = varNameInVertexShader;
            this.DataSize = dataSize;
            this.DataType = dataType;
            this.InstancedDivisor = instancedDivisor;
        }

        /// <summary>
        /// 此顶点属性VBO对应于vertex shader中的哪个in变量？
        /// <para>Mapping variable's name in vertex shader.</para>
        /// </summary>
        public string VarNameInVertexShader { get; set; }

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
        /// <para>How many float/int/uint are there in a data unit?</para>
        /// </summary>
        public int DataSize { get; private set; }

        /// <summary>
        /// 0: not instanced. 1: instanced divisor is 1.
        /// </summary>
        public uint InstancedDivisor { get; private set; }

        /// <summary>
        ///Bind this buffer.
        /// </summary>
        public override void Bind()
        {
            glBindBuffer(OpenGL.GL_ARRAY_BUFFER, this.BufferId);
        }

        /// <summary>
        /// Unind this buffer.
        /// </summary>
        public override void Unbind()
        {
            glBindBuffer(OpenGL.GL_ARRAY_BUFFER, 0);
        }

        /// <summary>
        /// 在使用<see cref="VertexArrayObject"/>后，此方法只会执行一次。
        /// This method will only be invoked once when using <see cref="VertexArrayObject"/>.
        /// </summary>
        /// <param name="shaderProgram"></param>
        public void Standby(ShaderProgram shaderProgram)
        {
            int location = shaderProgram.GetAttributeLocation(this.VarNameInVertexShader);
            if (location < 0) { throw new ArgumentException(); }

            uint loc = (uint)location;
            // 选中此VBO
            // select this VBO.
            glBindBuffer(OpenGL.GL_ARRAY_BUFFER, this.BufferId);
            // 指定格式
            // set up data format.
            glVertexAttribPointer(loc, this.DataSize, this.DataType, false, 0, IntPtr.Zero);
            // 启用
            // enable this VBO.
            glEnableVertexAttribArray(loc);
            if (this.InstancedDivisor > 0)
            {
                glVertexAttribDivisor(loc, this.InstancedDivisor);
            }
        }
    }
}