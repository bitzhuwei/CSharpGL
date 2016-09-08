namespace CSharpGL
{
    /// <summary>
    /// Buffer object that not work as input variable in shader.
    /// </summary>
    public class IndependentBufferPtr : BufferPtr
    {
        /// <summary>
        ///
        /// </summary>
        public BufferTarget Target { get; private set; }

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
        /// <param name="target"></param>
        /// <param name="bufferId">用glGenBuffers()得到的VBO的Id。<para>Id got from glGenBuffers();</para></param>
        /// <param name="length">此VBO含有多个个元素？<para>How many elements?</para></param>
        /// <param name="byteLength">此VBO中的数据在内存中占用多少个字节？<para>How many bytes in this buffer?</para></param>
        internal IndependentBufferPtr(BufferTarget target,
            uint bufferId, int length, int byteLength)
            : base(bufferId, length, byteLength)
        {
            if (glVertexAttribPointer == null)
            {
                glVertexAttribPointer = OpenGL.GetDelegateFor<OpenGL.glVertexAttribPointer>();
                glEnableVertexAttribArray = OpenGL.GetDelegateFor<OpenGL.glEnableVertexAttribArray>();
            }

            this.Target = target;
        }

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
            glBindBuffer((uint)this.Target, this.BufferId);
        }

        /// <summary>
        /// Bind this buffer.
        /// </summary>
        public override void Bind()
        {
            glBindBuffer((uint)this.Target, this.BufferId);
        }

        /// <summary>
        /// Unind this buffer.
        /// </summary>
        public override void Unbind()
        {
            glBindBuffer((uint)this.Target, 0);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("Id: {0}, {1}, ByteLength: {2}", this.BufferId, this.Target, this.ByteLength);
        }
    }
}