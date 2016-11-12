namespace CSharpGL
{
    internal class ZeroIndexLineInTriangleSearcher : ZeroIndexLineSearcher
    {
        /// <summary>
        /// 在三角形图元中拾取指定位置的Line
        /// </summary>
        /// <param name="arg">渲染参数</param>
        /// <param name="x">mouse position(Left Down is (0, 0)).</param>
        /// <param name="y">mouse position(Left Down is (0, 0)).</param>
        /// <param name="lastVertexId">三角形图元的最后一个顶点</param>
        /// <param name="modernRenderer">目标Renderer</param>
        /// <returns></returns>
        internal override uint[] Search(RenderEventArgs arg,
            int x, int y,
            uint lastVertexId, ZeroIndexRenderer modernRenderer)
        {
            // 创建临时索引
            OneIndexBuffer buffer = Buffer.Create(IndexElementType.UInt, 6, DrawMode.Lines, BufferUsage.StaticDraw);
            unsafe
            {
                var array = (uint*)buffer.MapBuffer(MapBufferAccess.WriteOnly);
                array[0] = lastVertexId - 1; array[1] = lastVertexId - 0;
                array[2] = lastVertexId - 2; array[3] = lastVertexId - 1;
                array[4] = lastVertexId - 0; array[5] = lastVertexId - 2;
                buffer.UnmapBuffer();
            }
            // 用临时索引渲染此三角形图元（仅渲染此三角形图元）
            modernRenderer.Render4InnerPicking(arg, buffer);
            // id是拾取到的Line的Last Vertex Id
            uint id = ColorCodedPicking.ReadStageVertexId(x, y);

            buffer.Dispose();

            // 对比临时索引，找到那个Line
            if (id + 2 == lastVertexId)
            { return new uint[] { id + 2, id, }; }
            else
            { return new uint[] { id - 1, id, }; }
        }
    }
}