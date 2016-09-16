namespace CSharpGL
{
    // http://blog.csdn.net/csxiaoshui/article/details/32101977
    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T">此buffer存储的是哪种struct的数据？<para>type of index value.</para></typeparam>
    public class UniformBuffer<T> : IndependentBuffer<T> where T : struct
    {
        internal static OpenGL.glGetUniformBlockIndex glGetUniformBlockIndex;
        internal static OpenGL.glUniformBlockBinding glUniformBlockBinding;
        internal static OpenGL.glBindBufferBase glBindBufferBase;

        /// <summary>
        ///
        /// </summary>
        /// <param name="usage"></param>
        /// <param name="noDataCopyed"></param>
        public UniformBuffer(BufferUsage usage, bool noDataCopyed = false)
            : base(usage, noDataCopyed)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        protected override BufferPtr Upload2GPU()
        {
            if (glGetUniformBlockIndex == null)
            {
                glGetUniformBlockIndex = OpenGL.GetDelegateFor<OpenGL.glGetUniformBlockIndex>();
                glUniformBlockBinding = OpenGL.GetDelegateFor<OpenGL.glUniformBlockBinding>();
                glBindBufferBase = OpenGL.GetDelegateFor<OpenGL.glBindBufferBase>();
            }

            uint[] buffers = new uint[1];
            glGenBuffers(1, buffers);
            const uint target = OpenGL.GL_UNIFORM_BUFFER;
            glBindBuffer(target, buffers[0]);
            glBufferData(target, this.ByteLength, this.Header, (uint)this.Usage);
            glBindBuffer(target, 0);

            var bufferPtr = new UniformBufferPtr(buffers[0], this.Length, this.ByteLength);

            return bufferPtr;
        }
    }
}