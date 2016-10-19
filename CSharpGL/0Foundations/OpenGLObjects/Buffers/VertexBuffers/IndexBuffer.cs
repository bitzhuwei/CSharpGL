using System.Diagnostics;
namespace CSharpGL
{
    /// <summary>
    /// 用于存储索引的VBO。
    /// <para>Vertex Buffer Object storing vertex' index.</para>
    /// </summary>
    public abstract class IndexBuffer : Buffer
    {
        /// <summary>
        /// 用于存储索引的VBO。
        /// <para>Vertex Buffer Object storing vertex' index.</para>
        /// </summary>
        /// <param name="mode">用哪种方式渲染各个顶点？（OpenGL.GL_TRIANGLES etc.）</param>
        /// <param name="usage"></param>
        /// <param name="primCount">primCount in instanced rendering.</param>
        public IndexBuffer(DrawMode mode, BufferUsage usage, int primCount)
            : base(usage)
        {
            Debug.Assert(primCount > 0);

            this.Mode = mode;
            this.PrimCount = primCount;
        }

        /// <summary>
        /// 用哪种方式渲染各个顶点？（OpenGL.GL_TRIANGLES etc.）
        /// </summary>
        public DrawMode Mode { get; private set; }

        /// <summary>
        /// primCount in instanced rendering.
        /// </summary>
        public int PrimCount { get; private set; }

        /// <summary>
        /// 将此Buffer的数据上传到GPU内存，并获取在GPU上的指针。执行此方法后，此对象中的非托管内存即可释放掉，不再占用CPU内存。
        /// Uploads this buffer to GPU memory and gets its pointer.
        /// It's totally OK to free memory of unmanaged array stored in this buffer object after this method invoked.
        /// </summary>
        /// <returns></returns>
        protected abstract IndexBufferPtr Upload2GraphicsCard();

        private IndexBufferPtr bufferPtr = null;

        /// <summary>
        /// 将此Buffer的数据上传到GPU内存，并获取在GPU上的指针。执行此方法后，此对象中的非托管内存即可释放掉，不再占用CPU内存。
        /// Uploads this buffer to GPU memory and gets its pointer.
        /// It's totally OK to free memory of unmanaged array stored in this buffer object after this method invoked.
        /// </summary>
        /// <returns></returns>
        public IndexBufferPtr GetBufferPtr()
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
    }
}