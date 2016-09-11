namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public class UniformBuffer : Buffer
    {

        internal static OpenGL.glGetUniformBlockIndex glGetUniformBlockIndex;
        internal static OpenGL.glUniformBlockBinding glUniformBlockBinding;
        internal static OpenGL.glBindBufferBase glBindBufferBase;

        /// <summary>
        /// 
        /// </summary>
        public UniformBuffer(BufferUsage usage)
            : base(usage)
        {
            if (glGetUniformBlockIndex == null)
            {
                glGetUniformBlockIndex = OpenGL.GetDelegateFor<OpenGL.glGetUniformBlockIndex>();
                glUniformBlockBinding = OpenGL.GetDelegateFor<OpenGL.glUniformBlockBinding>();
                glBindBufferBase = OpenGL.GetDelegateFor<OpenGL.glBindBufferBase>();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="elementCount"></param>
        public override void Create(int elementCount)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override BufferPtr Upload2GPU()
        {
            uint[] buffers = new uint[1];
            glGenBuffers(1, buffers);
            var target = (uint)BufferTarget.UniformBuffer;
            glBindBuffer(target, buffers[0]);
            glBufferData(target, this.ByteLength, this.Header, (uint)this.Usage);
            glBindBuffer(target, 0);

            var bufferPtr = new UniformBufferPtr(buffers[0], this.Length, this.ByteLength);

            return bufferPtr;
        }
    }
}