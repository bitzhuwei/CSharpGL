using System;

namespace CSharpGL
{
    /// <summary>
    /// Vertex' attribute buffer's pointer.
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
        ///
        /// </summary>
        protected static OpenGL.glPatchParameteri glPatchParameteri;

        /// <summary>
        /// TODO: temporary field here. not know where to use it yet.
        /// </summary>
        protected static OpenGL.glPatchParameterfv glPatchParameterfv;

        /// <summary>
        /// Target that this buffer should bind to.
        /// </summary>
        public override BufferTarget Target
        {
            get { return BufferTarget.ArrayBuffer; }
        }

        /// <summary>
        /// Vertex' attribute buffer's pointer.
        /// </summary>
        /// <param name="varNameInVertexShader">此顶点属性VBO对应于vertex shader中的哪个in变量？<para>Mapping variable's name in vertex shader.</para></param>
        /// <param name="bufferId">用glGenBuffers()得到的VBO的Id。<para>Id got from glGenBuffers();</para></param>
        /// <param name="config">This <paramref name="config"/> decides parameters' values in glVertexAttribPointer(attributeLocation, size, type, false, 0, IntPtr.Zero);
        /// </param>
        /// <param name="length">此VBO含有多个个元素？<para>How many elements?</para></param>
        /// <param name="byteLength">此VBO中的数据在内存中占用多少个字节？<para>How many bytes in this buffer?</para></param>
        /// <param name="instancedDivisor">0: not instanced. 1: instanced divisor is 1.</param>
        /// <param name="patchVertexes">How many vertexes makes a patch? No patch if <paramref name="patchVertexes"/> is 0.</param>
        internal VertexAttributeBufferPtr(string varNameInVertexShader,
            uint bufferId, VertexAttributeConfig config, int length, int byteLength,
            uint instancedDivisor = 0, int patchVertexes = 0)
            : base(bufferId, length, byteLength)
        {
            if (glVertexAttribPointer == null)
            {
                glVertexAttribPointer = OpenGL.GetDelegateFor<OpenGL.glVertexAttribPointer>();
                glEnableVertexAttribArray = OpenGL.GetDelegateFor<OpenGL.glEnableVertexAttribArray>();
                glVertexAttribDivisor = OpenGL.GetDelegateFor<OpenGL.glVertexAttribDivisor>();
                glPatchParameteri = OpenGL.GetDelegateFor<OpenGL.glPatchParameteri>();
                glPatchParameterfv = OpenGL.GetDelegateFor<OpenGL.glPatchParameterfv>();
            }

            this.VarNameInVertexShader = varNameInVertexShader;
            this.Config = config;
            this.InstancedDivisor = instancedDivisor;
            this.PatchVertexes = patchVertexes;
        }

        /// <summary>
        /// 此顶点属性VBO对应于vertex shader中的哪个in变量？
        /// <para>Mapping variable's name in vertex shader.</para>
        /// </summary>
        public string VarNameInVertexShader { get; set; }

        /// <summary>
        /// third parameter in glVertexAttribPointer(uint index, int size, uint type, bool normalized, int stride, IntPtr pointer);
        /// </summary>
        public VertexAttributeConfig Config { get; private set; }

        /// <summary>
        /// How many bytes are there in a primitive data type(float/uint/int etc)?
        /// </summary>
        public int DataTypeByteLength
        {
            get
            {
                int result = 0;
                switch (this.Config)
                {
                    case VertexAttributeConfig.Byte:
                        result = sizeof(byte);
                        break;

                    case VertexAttributeConfig.BVec2:
                        result = sizeof(byte);
                        break;

                    case VertexAttributeConfig.BVec3:
                        result = sizeof(byte);
                        break;

                    case VertexAttributeConfig.BVec4:
                        result = sizeof(byte);
                        break;

                    case VertexAttributeConfig.Int:
                        result = sizeof(int);
                        break;

                    case VertexAttributeConfig.IVec2:
                        result = sizeof(int);
                        break;

                    case VertexAttributeConfig.IVec3:
                        result = sizeof(int);
                        break;

                    case VertexAttributeConfig.IVec4:
                        result = sizeof(int);
                        break;

                    case VertexAttributeConfig.UInt:
                        result = sizeof(uint);
                        break;

                    case VertexAttributeConfig.UVec2:
                        result = sizeof(uint);
                        break;

                    case VertexAttributeConfig.UVec3:
                        result = sizeof(uint);
                        break;

                    case VertexAttributeConfig.UVec4:
                        result = sizeof(uint);
                        break;

                    case VertexAttributeConfig.Float:
                        result = sizeof(float);
                        break;

                    case VertexAttributeConfig.Vec2:
                        result = sizeof(float);
                        break;

                    case VertexAttributeConfig.Vec3:
                        result = sizeof(float);
                        break;

                    case VertexAttributeConfig.Vec4:
                        result = sizeof(float);
                        break;

                    case VertexAttributeConfig.Double:
                        result = sizeof(double);
                        break;

                    case VertexAttributeConfig.DVec2:
                        result = sizeof(double);
                        break;

                    case VertexAttributeConfig.DVec3:
                        result = sizeof(double);
                        break;

                    case VertexAttributeConfig.DVec4:
                        result = sizeof(double);
                        break;

                    case VertexAttributeConfig.Mat2:
                        result = sizeof(float);
                        break;

                    case VertexAttributeConfig.Mat3:
                        result = sizeof(float);
                        break;

                    case VertexAttributeConfig.Mat4:
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
        /// <para>How many primitive data type(float/int/uint etc) are there in a data unit?</para>
        /// </summary>
        public int DataSize
        {
            get
            {
                int locationCount;
                int dataSize;
                uint dataType;
                int stride;
                int startOffsetUnit;
                this.Config.Parse(out locationCount, out dataSize, out dataType, out stride, out startOffsetUnit);
                return dataSize;
            }
        }

        /// <summary>
        /// 0: not instanced. 1: instanced divisor is 1.
        /// </summary>
        public uint InstancedDivisor { get; private set; }

        /// <summary>
        /// How many vertexes makes a patch? No patch if PatchVertexes is 0.
        /// </summary>
        public int PatchVertexes { get; set; }

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
            //glBindBuffer(OpenGL.GL_ARRAY_BUFFER, this.BufferId);
            glBindBuffer((uint)this.Target, this.BufferId);
            // 指定格式
            // set up data format.
            int locationCount;
            int dataSize;
            uint dataType;
            int stride;
            int startOffsetUnit;
            this.Config.Parse(out locationCount, out dataSize, out dataType, out stride, out startOffsetUnit);
            int patchVertexes = this.PatchVertexes;
            uint divisor = this.InstancedDivisor;
            for (uint i = 0; i < locationCount; i++)
            {
                glVertexAttribPointer(loc + i, dataSize, dataType, false, stride, new IntPtr(i * startOffsetUnit));
                if (patchVertexes > 0)// tessellation shading.
                { glPatchParameteri(OpenGL.GL_PATCH_VERTICES, patchVertexes); }
                // 启用
                // enable this VBO.
                glEnableVertexAttribArray(loc + i);
                if (divisor > 0)// instanced rendering.
                {
                    // TODO: what if this is mat4? ...
                    glVertexAttribDivisor(loc + i, divisor);
                }
            }
        }
    }
}