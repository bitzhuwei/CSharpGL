using System;
using System.ComponentModel;

namespace CSharpGL {
    /// <summary>
    /// type of Vertex Buffer Object, which represents one of vertex's attribute(position, color, uv coordinate, normal, etc).
    /// <para>In CSharpGL, one <see cref="VertexBuffer"/> object contains only one kind of attribute.</para>
    /// </summary>
    public unsafe partial class VertexBuffer : GLBuffer {

        /// <summary>
        /// third parameter in glVertexAttribPointer(uint index, int size, uint type, bool normalized, int stride, IntPtr pointer);
        /// </summary>
        public readonly VBOConfig config;

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
        public readonly uint instancedDivisor;

        /// <summary>
        /// How many vertexes makes a patch? No patch if PatchVertexes is 0.
        /// </summary>
        public readonly int patchVertexes;

        /// <summary>
        /// Vertex' attribute buffer's pointer.
        /// </summary>
        /// <param name="bufferId">用glGenBuffers()得到的VBO的Id。<para>Id got from glGenBuffers();</para></param>
        /// <param name="config">This <paramref name="config"/> decides parameters' values in glVertexAttribPointer(attributeLocation, size, type, false, 0, IntPtr.Zero);
        /// </param>
        /// <param name="vertexCount">此VBO含有多个个元素？<para>How many elements?</para></param>
        /// <param name="byteLength">此VBO中的数据在内存中占用多少个字节？<para>How many bytes in this buffer?</para></param>
        /// <param name="instancedDivisor">0: not instanced. 1: instanced divisor is 1.</param>
        /// <param name="patchVertexes">How many vertexes makes a patch? No patch if <paramref name="patchVertexes"/> is 0.</param>
        internal VertexBuffer(
            uint bufferId, VBOConfig config, int vertexCount, int byteLength, Usage usage,
            uint instancedDivisor = 0, int patchVertexes = 0)
            : base(Target.ArrayBuffer, bufferId, vertexCount, byteLength, usage) {
            this.config = config;
            this.instancedDivisor = instancedDivisor;
            this.patchVertexes = patchVertexes;
        }

        /// <summary>
        /// 在使用<see cref="VertexArrayObject"/>后，此方法只会执行一次。
        /// This method will only be invoked once when using <see cref="VertexArrayObject"/>.
        /// </summary>
        /// <param name="shaderProgram"></param>
        /// <param name="varNameInVertexShader"></param>
        public void Standby(GLProgram shaderProgram, string varNameInVertexShader) {
            var gl = GL.current; if (gl == null) { return; }
            int location = shaderProgram.GetAttributeLocation(varNameInVertexShader);
            if (location < 0) { throw new ArgumentException(); }

            uint loc = (uint)location;
            VBOConfigDetail detail = this.config.Parse();
            int patchVertexes = this.patchVertexes;
            uint divisor = this.instancedDivisor;
            // 选中此VBO
            // select this VBO.
            gl.glBindBuffer(GL.GL_ARRAY_BUFFER, this.bufferId);
            for (uint i = 0; i < detail.locationCount; i++) {
                // 指定格式
                // set up data format.
                switch (detail.pointerType) {
                case VertexAttribPointerType.Default:
                gl.glVertexAttribPointer(loc + i, detail.dataSize, detail.dataType, false, detail.stride, new IntPtr(i * detail.startOffsetUnit));
                break;

                case VertexAttribPointerType.Integer:
                gl.glVertexAttribIPointer(loc + i, detail.dataSize, detail.dataType, detail.stride, new IntPtr(i * detail.startOffsetUnit));
                break;

                case VertexAttribPointerType.Long:
                gl.glVertexAttribLPointer(loc + i, detail.dataSize, detail.dataType, detail.stride, new IntPtr(i * detail.startOffsetUnit));
                break;

                default:
                throw new NotSupportedException(detail.pointerType.ToString());
                }

                if (patchVertexes > 0)// tessellation shading.
                {
                    gl.glPatchParameteri(GL.GL_PATCH_VERTICES, patchVertexes);
                }
                // 启用
                // enable this VBO.
                gl.glEnableVertexAttribArray(loc + i);
                if (divisor > 0)// instanced rendering.
                {
                    gl.glVertexAttribDivisor(loc + i, divisor);
                }
            }
            gl.glBindBuffer(GL.GL_ARRAY_BUFFER, 0);
        }

        ///// <summary>
        ///// Shallow copy of this <see cref="VertexBuffer"/> instance.
        ///// </summary>
        ///// <returns></returns>
        //public object Clone() {
        //    return this.MemberwiseClone();
        //}
    }

    internal enum VertexAttribPointerType {
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