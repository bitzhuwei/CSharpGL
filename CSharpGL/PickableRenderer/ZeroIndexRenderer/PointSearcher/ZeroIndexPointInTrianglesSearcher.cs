using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    class ZeroIndexPointInTriangleSearcher : ZeroIndexPointSearcher
    {
        /// <summary>
        /// 在三角形图元中拾取指定位置的Point
        /// </summary>
        /// <param name="arg">渲染参数</param>
        /// <param name="x">指定位置</param>
        /// <param name="y">指定位置</param>
        /// <param name="lastVertexId">三角形图元的最后一个顶点</param>
        /// <param name="modernRenderer">目标Renderer</param>
        /// <returns></returns>
        internal override uint Search(RenderEventArgs arg,
            int x, int y,
            uint lastVertexId, ZeroIndexRenderer modernRenderer)
        {
            // 创建临时索引
            OneIndexBufferPtr indexBufferPtr = null;
            using (var buffer = new OneIndexBuffer<uint>(DrawMode.Points, BufferUsage.StaticDraw))
            {
                buffer.Alloc(3);
                unsafe
                {
                    var array = (uint*)buffer.Header.ToPointer();
                    array[0] = lastVertexId - 0;
                    array[1] = lastVertexId - 1;
                    array[2] = lastVertexId - 2;
                }

                indexBufferPtr = buffer.GetBufferPtr() as OneIndexBufferPtr;
            }

            // 用临时索引渲染此三角形图元（仅渲染此三角形图元）
            modernRenderer.Render4InnerPicking(arg, indexBufferPtr);
            // id是拾取到的Line的Last Vertex Id
            uint id = ColorCodedPicking.ReadPixel(x, y, arg.CanvasRect.Height);

            indexBufferPtr.Dispose();

            // 对比临时索引，找到那个Line
            if (lastVertexId - 2 <= id && id <= lastVertexId - 0)
            { return id; }
            else
            { throw new Exception("This should not happen!"); }
        }
    }
}
