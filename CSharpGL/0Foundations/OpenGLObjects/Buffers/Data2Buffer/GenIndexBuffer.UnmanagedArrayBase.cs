namespace CSharpGL
{
    public static partial class Data2Buffer
    {
        /// <summary>
        /// 生成一个用于存储索引的VBO。索引指定了<see cref="VertexBuffer"/>里各个顶点的渲染顺序。
        /// Generates a Vertex Buffer Object storing vertexes' indexes, which indicate the rendering order of each vertex.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="mode">用哪种方式渲染各个顶点？（OpenGL.GL_TRIANGLES etc.）</param>
        /// <param name="usage"></param>
        /// <param name="primCount">primCount in instanced rendering.</param>
        /// <returns></returns>
        public static OneIndexBuffer GenIndexBuffer(this UnmanagedArray<byte> array, DrawMode mode, BufferUsage usage, int primCount = 1)
        {
            return GenIndexBuffer(array, mode, usage, IndexBufferElementType.UByte, primCount);
        }

        /// <summary>
        /// 生成一个用于存储索引的VBO。索引指定了<see cref="VertexBuffer"/>里各个顶点的渲染顺序。
        /// Generates a Vertex Buffer Object storing vertexes' indexes, which indicate the rendering order of each vertex.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="mode">用哪种方式渲染各个顶点？（OpenGL.GL_TRIANGLES etc.）</param>
        /// <param name="usage"></param>
        /// <param name="primCount">primCount in instanced rendering.</param>
        /// <returns></returns>
        public static OneIndexBuffer GenIndexBuffer(this UnmanagedArray<ushort> array, DrawMode mode, BufferUsage usage, int primCount = 1)
        {
            return GenIndexBuffer(array, mode, usage, IndexBufferElementType.UShort, primCount);
        }

        /// <summary>
        /// 生成一个用于存储索引的VBO。索引指定了<see cref="VertexBuffer"/>里各个顶点的渲染顺序。
        /// Generates a Vertex Buffer Object storing vertexes' indexes, which indicate the rendering order of each vertex.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="mode">用哪种方式渲染各个顶点？（OpenGL.GL_TRIANGLES etc.）</param>
        /// <param name="usage"></param>
        /// <param name="primCount">primCount in instanced rendering.</param>
        /// <returns></returns>
        public static OneIndexBuffer GenIndexBuffer(this UnmanagedArray<uint> array, DrawMode mode, BufferUsage usage, int primCount = 1)
        {
            return GenIndexBuffer(array, mode, usage, IndexBufferElementType.UInt, primCount);
        }

        /// <summary>
        /// 生成一个用于存储索引的VBO。索引指定了<see cref="VertexBuffer"/>里各个顶点的渲染顺序。
        /// Generates a Vertex Buffer Object storing vertexes' indexes, which indicate the rendering order of each vertex.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="mode">用哪种方式渲染各个顶点？（OpenGL.GL_TRIANGLES etc.）</param>
        /// <param name="usage"></param>
        /// <param name="elementType"></param>
        /// <param name="primCount">primCount in instanced rendering.</param>
        /// <returns></returns>
        private static OneIndexBuffer GenIndexBuffer(this UnmanagedArrayBase array, DrawMode mode, BufferUsage usage, IndexBufferElementType elementType, int primCount = 1)
        {
            if (glGenBuffers == null)
            {
                InitFunctions();
            }

            uint[] buffers = new uint[1];
            glGenBuffers(1, buffers);
            const uint target = OpenGL.GL_ELEMENT_ARRAY_BUFFER;
            glBindBuffer(target, buffers[0]);
            glBufferData(target, array.ByteLength, array.Header, (uint)usage);
            glBindBuffer(target, 0);

            var buffer = new OneIndexBuffer(buffers[0], mode, elementType, array.Length, array.ByteLength, primCount);

            return buffer;
        }
    }
}