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
    }
}