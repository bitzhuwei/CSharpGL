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
            uint bufferId, VertexAttributeDataType dataType, int length, int byteLength,
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
            this.DataType = dataType;
            this.InstancedDivisor = instancedDivisor;
        }

        /// <summary>
        /// 此顶点属性VBO对应于vertex shader中的哪个in变量？
        /// <para>Mapping variable's name in vertex shader.</para>
        /// </summary>
        public string VarNameInVertexShader { get; set; }

        /// <summary>
        /// third parameter in glVertexAttribPointer(uint index, int size, uint type, bool normalized, int stride, IntPtr pointer);
        /// </summary>
        public VertexAttributeDataType DataType { get; private set; }

        /// <summary>
        /// <see cref="DataType"/>有多少字节？
        /// </summary>
        public int DataTypeByteLength
        {
            get
            {
                int result = 0;
                switch (this.DataType)
                {
                    case VertexAttributeDataType.Byte:
                        result = sizeof(byte);
                        break;
                    case VertexAttributeDataType.BVec2:
                        result = sizeof(byte);
                        break;
                    case VertexAttributeDataType.BVec3:
                        result = sizeof(byte);
                        break;
                    case VertexAttributeDataType.BVec4:
                        result = sizeof(byte);
                        break;
                    case VertexAttributeDataType.Int:
                        result = sizeof(int);
                        break;
                    case VertexAttributeDataType.IVec2:
                        result = sizeof(int);
                        break;
                    case VertexAttributeDataType.IVec3:
                        result = sizeof(int);
                        break;
                    case VertexAttributeDataType.IVec4:
                        result = sizeof(int);
                        break;
                    case VertexAttributeDataType.UInt:
                        result = sizeof(uint);
                        break;
                    case VertexAttributeDataType.UVec2:
                        result = sizeof(uint);
                        break;
                    case VertexAttributeDataType.UVec3:
                        result = sizeof(uint);
                        break;
                    case VertexAttributeDataType.UVec4:
                        result = sizeof(uint);
                        break;
                    case VertexAttributeDataType.Float:
                        result = sizeof(float);
                        break;
                    case VertexAttributeDataType.Vec2:
                        result = sizeof(float);
                        break;
                    case VertexAttributeDataType.Vec3:
                        result = sizeof(float);
                        break;
                    case VertexAttributeDataType.Vec4:
                        result = sizeof(float);
                        break;
                    case VertexAttributeDataType.Double:
                        result = sizeof(double);
                        break;
                    case VertexAttributeDataType.DVec2:
                        result = sizeof(double);
                        break;
                    case VertexAttributeDataType.DVec3:
                        result = sizeof(double);
                        break;
                    case VertexAttributeDataType.DVec4:
                        result = sizeof(double);
                        break;
                    case VertexAttributeDataType.Mat2:
                        result = sizeof(float);
                        break;
                    case VertexAttributeDataType.Mat3:
                        result = sizeof(float);
                        break;
                    case VertexAttributeDataType.Mat4:
                        result = sizeof(float);
                        break;
                    default:
                        throw new System.NotImplementedException();
                }

                return result;
            }
        }

        /// <summary>
        /// second parameter in glVertexAttribPointer(uint index, int size, uint type, bool normalized, int stride, IntPtr pointer);
        /// <para>How many float/int/uint are there in a data unit?</para>
        /// </summary>
        public int DataSize
        {
            get
            {
                int dataSize;
                uint dataType;
                this.DataType.Parse(out dataSize, out dataType);
                return dataSize;
            }
        }

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
            int dataSize;
            uint dataType;
            this.DataType.Parse(out dataSize, out dataType);
            glVertexAttribPointer(loc, dataSize, dataType, false, 0, IntPtr.Zero);
            // 启用
            // enable this VBO.
            glEnableVertexAttribArray(loc);
            if (this.InstancedDivisor > 0)
            {
                // TODO: what if this is mat4? ...
                glVertexAttribDivisor(loc, this.InstancedDivisor);
            }
        }
    }
}