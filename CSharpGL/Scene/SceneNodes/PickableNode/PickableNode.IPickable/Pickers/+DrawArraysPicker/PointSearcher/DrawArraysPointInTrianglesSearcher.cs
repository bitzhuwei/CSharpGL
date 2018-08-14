using System;

namespace CSharpGL
{
    internal class DrawArraysPointInTriangleSearcher : DrawArraysPointSearcher
    {
        /// <summary>
        /// 在三角形图元中拾取指定位置的Point
        /// </summary>
        /// <param name="arg">渲染参数</param>
        /// <param name="singleNodeVertexId">三角形图元的最后一个顶点</param>
        /// <param name="stageVertexId"></param>
        /// <param name="picker">目标Renderer</param>
        /// <returns></returns>
        internal override uint Search(PickingEventArgs arg, uint singleNodeVertexId, uint stageVertexId, DrawArraysPicker picker)
        {
            // 创建临时索引
            var array = new uint[] 
            { 
                singleNodeVertexId - 0,
                singleNodeVertexId - 1,
                singleNodeVertexId - 2
            };
            IndexBuffer buffer = array.GenIndexBuffer(BufferUsage.StaticDraw);
            var cmd = new DrawElementsCmd(buffer, DrawMode.Points);
            // 用临时索引渲染此三角形图元（仅渲染此三角形图元）
            picker.Node.Render4InnerPicking(arg,  cmd);
            // id是拾取到的Line的Last Vertex Id
            uint id = ColorCodedPicking.ReadStageVertexId(arg.X, arg.Y);

            buffer.Dispose();

            // 对比临时索引，找到那个Line
            if (stageVertexId - 2 <= id && id <= stageVertexId - 0)
            { return id; }
            else
            { throw new Exception("This should not happen!"); }
        }
    }
}