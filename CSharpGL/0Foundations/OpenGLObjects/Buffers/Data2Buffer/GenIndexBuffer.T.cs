namespace CSharpGL
{
    public static partial class Data2Buffer
    {
        /// <summary>
        /// 生成一个用于存储索引的VBO。索引指定了<see cref="VertexBuffer"/>里各个顶点的渲染顺序。
        /// Generates a Vertex Buffer Object storing vertexes' indexes, which indicate the rendering order of each vertex.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="mode">用哪种方式渲染各个顶点？（OpenGL.GL_TRIANGLES etc.）</param>
        /// <param name="usage"></param>
        /// <param name="primCount">primCount in instanced rendering.</param>
        /// <returns></returns>
        public static OneIndexBuffer GenIndexBuffer(this byte data, DrawMode mode, BufferUsage usage, int primCount = 1)
        {
            var array = new byte[] { data };
            return GenIndexBuffer(array, mode, usage, primCount);
        }

        /// <summary>
        /// 生成一个用于存储索引的VBO。索引指定了<see cref="VertexBuffer"/>里各个顶点的渲染顺序。
        /// Generates a Vertex Buffer Object storing vertexes' indexes, which indicate the rendering order of each vertex.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="mode">用哪种方式渲染各个顶点？（OpenGL.GL_TRIANGLES etc.）</param>
        /// <param name="usage"></param>
        /// <param name="primCount">primCount in instanced rendering.</param>
        /// <returns></returns>
        public static OneIndexBuffer GenIndexBuffer(this ushort data, DrawMode mode, BufferUsage usage, int primCount = 1)
        {
            var array = new ushort[] { data };
            return GenIndexBuffer(array, mode, usage, primCount);
        }

        /// <summary>
        /// 生成一个用于存储索引的VBO。索引指定了<see cref="VertexBuffer"/>里各个顶点的渲染顺序。
        /// Generates a Vertex Buffer Object storing vertexes' indexes, which indicate the rendering order of each vertex.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="mode">用哪种方式渲染各个顶点？（OpenGL.GL_TRIANGLES etc.）</param>
        /// <param name="usage"></param>
        /// <param name="primCount">primCount in instanced rendering.</param>
        /// <returns></returns>
        public static OneIndexBuffer GenIndexBuffer(this uint data, DrawMode mode, BufferUsage usage, int primCount = 1)
        {
            var array = new uint[] { data };
            return GenIndexBuffer(array, mode, usage, primCount);
        }
    }
}