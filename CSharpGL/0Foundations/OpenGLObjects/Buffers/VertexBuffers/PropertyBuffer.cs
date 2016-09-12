namespace CSharpGL
{
    /// <summary>
    /// 顶点属性Buffer。描述顶点的位置或颜色或UV等各种属性。
    /// <para>每个<see cref="PropertyBuffer&lt;T&gt;"/>仅描述其中一个属性。</para>
    /// <para>Vertex Buffer Object that describes vertex' property(position, color, uv coordinate, ect.).</para>
    /// <para>Each <see cref="PropertyBuffer&lt;T&gt;"/> describes only 1 property.</para>
    /// </summary>
    /// <typeparam name="T">此buffer存储的是哪种struct的数据？<para>type of index value.</para></typeparam>
    public class PropertyBuffer<T> : Buffer where T : struct
    {
        /// <summary>
        /// 顶点属性Buffer。描述顶点的位置或颜色或UV等各种属性。
        /// <para>每个<see cref="PropertyBuffer&lt;T&gt;"/>仅描述其中一个属性。</para>
        /// <para>Vertex Buffer Object that describes vertex' property(position, color, uv coordinate, ect.).</para>
        /// <para>Each <see cref="PropertyBuffer&lt;T&gt;"/> describes only 1 property.</para>
        /// </summary>
        /// <param name="varNameInVertexShader">此顶点属性VBO对应于vertex shader中的哪个in变量？<para>Mapping variable's name in vertex shader.</para></param>
        /// <param name="dataSize">second parameter in glVertexAttribPointer(attributeLocation, size, type, false, 0, IntPtr.Zero);
        /// <para>How many float/int/uint are there in a data unit?</para>
        /// </param>
        /// <param name="dataType">third parameter in glVertexAttribPointer(attributeLocation, size, type, false, 0, IntPtr.Zero);
        /// </param>
        /// <param name="usage"></param>
        /// <param name="instancedDivisor">0: not instanced. 1: instanced divisor is 1.</param>
        public PropertyBuffer(string varNameInVertexShader, int dataSize, uint dataType, BufferUsage usage, uint instancedDivisor = 0)
            : base(usage)
        {
            this.VarNameInVertexShader = varNameInVertexShader;
            this.DataSize = dataSize;
            this.DataType = dataType;
            this.InstancedDivisor = instancedDivisor;
        }

        /// <summary>
        /// 此顶点属性VBO对应于vertex shader中的哪个in变量？
        /// <para>Mapping variable's name in vertex shader.</para>
        /// </summary>
        public string VarNameInVertexShader { get; private set; }

        /// <summary>
        /// second parameter in glVertexAttribPointer(uint index, int size, uint type, bool normalized, int stride, IntPtr pointer);
        /// <para>How many float/int/uint are there in a data unit?</para>
        /// </summary>
        public int DataSize { get; private set; }

        /// <summary>
        /// GL_FLOAT etc
        /// <para>third parameter in glVertexAttribPointer(uint index, int size, uint type, bool normalized, int stride, IntPtr pointer);</para>
        /// </summary>
        public uint DataType { get; private set; }

        /// <summary>
        /// 0: not instanced. 1: instanced divisor is 1.
        /// </summary>
        public uint InstancedDivisor { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        protected override BufferPtr Upload2GPU()
        {
            uint[] buffers = new uint[1];
            glGenBuffers(1, buffers);
            glBindBuffer(OpenGL.GL_ARRAY_BUFFER, buffers[0]);
            glBufferData(OpenGL.GL_ARRAY_BUFFER, this.ByteLength, this.Header, (uint)this.Usage);
            glBindBuffer(OpenGL.GL_ARRAY_BUFFER, 0);

            var bufferPtr = new PropertyBufferPtr(
                this.VarNameInVertexShader, buffers[0], this.DataSize, this.DataType, this.Length, this.ByteLength, this.InstancedDivisor);

            return bufferPtr;
        }

        /// <summary>
        /// 申请指定长度的非托管数组。
        /// <para>create an unmanaged array to store data for this buffer.</para>
        /// </summary>
        /// <param name="elementCount">数组元素的数目。<para>How many elements?</para></param>
        public override void Create(int elementCount)
        {
            this.array = new UnmanagedArray<T>(elementCount);
        }
    }
}