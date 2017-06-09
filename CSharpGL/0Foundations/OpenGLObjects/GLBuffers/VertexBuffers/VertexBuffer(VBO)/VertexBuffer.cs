using System;
using System.ComponentModel;

namespace CSharpGL
{
    /// <summary>
    /// type of Vertex Buffer Object, which represents one of vertex's attribute(position, color, uv coordinate, normal, etc).
    /// <para>In CSharpGL, one <see cref="VertexBuffer"/> contains only one kind of attribute.</para>
    /// </summary>
    public partial class VertexBuffer : GLBuffer, ICloneable
    {
        /// <summary>
        ///
        /// </summary>
        internal static OpenGL.glVertexAttribIPointer glVertexAttribIPointer;

        /// <summary>
        ///
        /// </summary>
        internal static OpenGL.glVertexAttribLPointer glVertexAttribLPointer;

        /// <summary>
        ///
        /// </summary>
        internal static OpenGL.glVertexAttribDivisor glVertexAttribDivisor;

        /// <summary>
        ///
        /// </summary>
        internal static OpenGL.glPatchParameteri glPatchParameteri;

        ///// <summary>
        ///// TODO: temporary field here. not know where to use it yet.
        ///// </summary>
        //internal static OpenGL.glPatchParameterfv glPatchParameterfv;

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
        /// <param name="bufferId">用glGenBuffers()得到的VBO的Id。<para>Id got from glGenBuffers();</para></param>
        /// <param name="config">This <paramref name="config"/> decides parameters' values in glVertexAttribPointer(attributeLocation, size, type, false, 0, IntPtr.Zero);
        /// </param>
        /// <param name="varNameInVertexShader">此顶点属性VBO对应于vertex shader中的哪个in变量？<para>Mapping variable's name in vertex shader.</para></param>
        /// <param name="length">此VBO含有多个个元素？<para>How many elements?</para></param>
        /// <param name="byteLength">此VBO中的数据在内存中占用多少个字节？<para>How many bytes in this buffer?</para></param>
        /// <param name="instancedDivisor">0: not instanced. 1: instanced divisor is 1.</param>
        /// <param name="patchVertexes">How many vertexes makes a patch? No patch if <paramref name="patchVertexes"/> is 0.</param>
        internal VertexBuffer(
            uint bufferId, VBOConfig config, string varNameInVertexShader, int length, int byteLength,
            uint instancedDivisor = 0, int patchVertexes = 0)
            : base(bufferId, length, byteLength)
        {
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
        public VBOConfig Config { get; set; }

        ///// <summary>
        ///// How many bytes are there in a primitive data type(float/uint/int etc)?
        ///// </summary>
        //public int DataTypeByteLength
        //{
        //    get
        //    {
        //        int result = this.Config.GetDataTypeByteLength();

        //        return result;
        //    }
        //}

        ///// <summary>
        ///// second parameter in glVertexAttribPointer(uint index, int size, uint type, bool normalized, int stride, IntPtr pointer);
        ///// <para>How many primitive data type(float/int/uint etc) are there in a data unit?</para>
        ///// </summary>
        //public int DataSize
        //{
        //    get
        //    {
        //        return this.Config.GetDataSize();
        //    }
        //}

        /// <summary>
        /// 0: not instanced. 1: instanced divisor is 1.
        /// </summary>
        public uint InstancedDivisor { get; set; }

        /// <summary>
        /// How many vertexes makes a patch? No patch if PatchVertexes is 0.
        /// </summary>
        [ReadOnly(true)]
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
            VBOConfigDetail detail = this.Config.Parse();
            int patchVertexes = this.PatchVertexes;
            uint divisor = this.InstancedDivisor;
            // 选中此VBO
            // select this VBO.
            glBindBuffer(OpenGL.GL_ARRAY_BUFFER, this.BufferId);
            for (uint i = 0; i < detail.locationCount; i++)
            {
                // 指定格式
                // set up data format.
                switch (detail.pointerType)
                {
                    case VertexAttribPointerType.Default:
                        glVertexAttribPointer(loc + i, detail.dataSize, detail.dataType, false, detail.stride, new IntPtr(i * detail.startOffsetUnit));
                        break;

                    case VertexAttribPointerType.Integer:
                        glVertexAttribIPointer(loc + i, detail.dataSize, detail.dataType, detail.stride, new IntPtr(i * detail.startOffsetUnit));
                        break;

                    case VertexAttribPointerType.Long:
                        glVertexAttribLPointer(loc + i, detail.dataSize, detail.dataType, detail.stride, new IntPtr(i * detail.startOffsetUnit));
                        break;

                    default:
                        throw new NotImplementedException();
                }

                if (patchVertexes > 0)// tessellation shading.
                {
                    if (glPatchParameteri != null)
                    {
                        if (glPatchParameteri == null) { glPatchParameteri = OpenGL.GetDelegateFor<OpenGL.glPatchParameteri>(); }
                        glPatchParameteri(OpenGL.GL_PATCH_VERTICES, patchVertexes);
                    }
                }
                // 启用
                // enable this VBO.
                glEnableVertexAttribArray(loc + i);
                if (divisor > 0)// instanced rendering.
                {
                    glVertexAttribDivisor(loc + i, divisor);
                }
            }
            glBindBuffer(OpenGL.GL_ARRAY_BUFFER, 0);
        }

        /// <summary>
        /// Shallow copy of this <see cref="VertexBuffer"/> instance.
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    internal enum VertexAttribPointerType
    {
        /// <summary>
        /// float
        /// </summary>
        Default,

        /// <summary>
        /// byte, short, int, uint,
        /// </summary>
        Integer,

        /// <summary>
        /// GL_DOUBLE
        /// </summary>
        Long,
    }
}