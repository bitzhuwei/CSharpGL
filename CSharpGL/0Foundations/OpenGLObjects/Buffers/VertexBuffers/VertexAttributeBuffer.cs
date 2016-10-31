namespace CSharpGL
{
    /// <summary>
    /// 顶点属性Buffer。描述顶点的位置或颜色或UV等各种属性。
    /// <para>每个<see cref="VertexAttributeBuffer&lt;T&gt;"/>仅描述其中一个属性。</para>
    /// <para>Vertex Buffer Object that describes vertex' property(position, color, uv coordinate, etc.).</para>
    /// <para>Each <see cref="VertexAttributeBuffer&lt;T&gt;"/> describes only 1 property.</para>
    /// <para>Note: If <typeparamref name="T"/> matches one of this.Config's value, then (Ptr.ByteLength / (Ptr.DataSize * Ptr.DataTypeByteLength)) equals (Ptr.Length).</para>
    /// <para><typeparamref name="T"/> is type of element of this array in application level.</para>
    /// </summary>
    /// <typeparam name="T">element type in this array in application level.</typeparam>
    public partial class VertexAttributeBuffer<T> : Buffer where T : struct
    {
        /// <summary>
        /// 顶点属性Buffer。描述顶点的位置或颜色或UV等各种属性。
        /// <para>每个<see cref="VertexAttributeBuffer&lt;T&gt;"/>仅描述其中一个属性。</para>
        /// <para>Vertex Buffer Object that describes vertex' property(position, color, uv coordinate, etc.).</para>
        /// <para>Each <see cref="VertexAttributeBuffer&lt;T&gt;"/> describes only 1 property.</para>
        /// <para>Note: If <typeparamref name="T"/> matches one of this.Config's value, then (Ptr.ByteLength / (Ptr.DataSize * Ptr.DataTypeByteLength)) equals (Ptr.Length).</para>
        /// <para><typeparamref name="T"/> is type of element of this array in application level.</para>
        /// </summary>
        /// <param name="varNameInVertexShader">此顶点属性VBO对应于vertex shader中的哪个in变量？<para>Mapping variable's name in vertex shader.</para></param>
        /// <param name="config">This <paramref name="config"/> decides parameters' values in glVertexAttribPointer(attributeLocation, size, type, false, 0, IntPtr.Zero);
        /// </param>
        /// <param name="usage"></param>
        /// <param name="instancedDivisor">0: not instanced. 1: instanced divisor is 1.</param>
        /// <param name="patchVertexes">How many vertexes makes a patch? No patch if <paramref name="patchVertexes"/> is 0.</param>
        public VertexAttributeBuffer(string varNameInVertexShader, VertexAttributeConfig config, BufferUsage usage, uint instancedDivisor = 0, int patchVertexes = 0)
            : base(usage)
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
        public string VarNameInVertexShader { get; private set; }

        /// <summary>
        /// third parameter in glVertexAttribPointer(uint index, int size, uint type, bool normalized, int stride, IntPtr pointer);
        /// </summary>
        public VertexAttributeConfig Config { get; private set; }

        /// <summary>
        /// 0: not instanced. 1: instanced divisor is 1.
        /// </summary>
        public uint InstancedDivisor { get; private set; }

        /// <summary>
        /// How many vertexes makes a patch? No patch if PatchVertexes is 0.
        /// </summary>
        public int PatchVertexes { get; set; }

        private VertexAttributeBufferPtr bufferPtr = null;

        /// <summary>
        /// 将此Buffer的数据上传到GPU内存，并获取在GPU上的指针。执行此方法后，此对象中的非托管内存即可释放掉，不再占用CPU内存。
        /// Uploads this buffer to GPU memory and gets its pointer.
        /// It's totally OK to free memory of unmanaged array stored in this buffer object after this method invoked.
        /// </summary>
        /// <returns></returns>
        public VertexAttributeBufferPtr GetBufferPtr()
        {
            if (bufferPtr == null)
            {
                if (glGenBuffers == null)
                {
                    glGenBuffers = OpenGL.GetDelegateFor<OpenGL.glGenBuffers>();
                    glBindBuffer = OpenGL.GetDelegateFor<OpenGL.glBindBuffer>();
                    glBufferData = OpenGL.GetDelegateFor<OpenGL.glBufferData>();
                }

                bufferPtr = Upload2GraphicsCard();
            }

            return bufferPtr;
        }

        /// <summary>
        /// 将此Buffer的数据上传到GPU内存，并获取在GPU上的指针。执行此方法后，此对象中的非托管内存即可释放掉，不再占用CPU内存。
        /// Uploads this buffer to GPU memory and gets its pointer.
        /// It's totally OK to free memory of unmanaged array stored in this buffer object after this method invoked.
        /// </summary>
        /// <returns></returns>
        protected VertexAttributeBufferPtr Upload2GraphicsCard()
        {
            uint[] buffers = new uint[1];
            glGenBuffers(1, buffers);
            const uint target = OpenGL.GL_ARRAY_BUFFER;
            glBindBuffer(target, buffers[0]);
            glBufferData(target, this.ByteLength, this.Header, (uint)this.Usage);
            glBindBuffer(target, 0);

            var bufferPtr = new VertexAttributeBufferPtr(
                this.VarNameInVertexShader, buffers[0], this.Config, this.Length, this.ByteLength, this.InstancedDivisor, this.PatchVertexes);

            return bufferPtr;
        }

        /// <summary>
        /// 申请指定长度的非托管数组。
        /// <para>create an unmanaged array to store data for this buffer.</para>
        /// </summary>
        /// <param name="elementCount">数组元素的数目。<para>How many elements?</para></param>
        protected override UnmanagedArrayBase DoAlloc(int elementCount)
        {
            return new UnmanagedArray<T>(elementCount);
        }
    }
}