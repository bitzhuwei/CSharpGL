namespace CSharpGL
{
    internal class DrawArraysLineInTriangleSearcher : DrawArraysLineSearcher
    {
        /// <summary>
        /// 在三角形图元中拾取指定位置的Line
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="flatColorVertexId">三角形图元的最后一个顶点</param>
        /// <param name="picker"></param>
        /// <returns></returns>
        internal override uint[] Search(PickingEventArgs arg,
            uint flatColorVertexId, DrawArraysPicker picker)
        {
            // 创建临时索引
            IndexBuffer buffer = GLBuffer.Create(IndexBufferElementType.UInt, 6, BufferUsage.StaticDraw);
            unsafe
            {
                var array = (uint*)buffer.MapBuffer(MapBufferAccess.WriteOnly);
                array[0] = flatColorVertexId - 1; array[1] = flatColorVertexId - 0;
                array[2] = flatColorVertexId - 2; array[3] = flatColorVertexId - 1;
                array[4] = flatColorVertexId - 0; array[5] = flatColorVertexId - 2;
                buffer.UnmapBuffer();
            }
            var cmd = new DrawElementsCmd(buffer, DrawMode.Lines);
            // 用临时索引渲染此三角形图元（仅渲染此三角形图元）
            picker.Node.Render4InnerPicking(arg, cmd);
            // id是拾取到的Line的Last Vertex Id
            uint id = ColorCodedPicking.ReadStageVertexId(arg.X, arg.Y);

            buffer.Dispose();

            // 对比临时索引，找到那个Line
            if (id + 2 == flatColorVertexId)
            { return new uint[] { id + 2, id, }; }
            else
            { return new uint[] { id - 1, id, }; }
        }
    }
}