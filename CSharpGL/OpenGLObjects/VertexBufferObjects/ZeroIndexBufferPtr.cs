using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    // 没有显式索引时的渲染方法。
    /// <summary>
    /// Wraps glDrawArrays(uint mode, int first, int count).
    /// </summary>
    public sealed class ZeroIndexBufferPtr : IndexBufferPtr
    {
        /// <summary>
        /// Wraps glDrawArrays(uint mode, int first, int count).
        /// </summary>
        /// <param name="mode">用哪种方式渲染各个顶点？（OpenGL.GL_TRIANGLES etc.）</param>
        ///<param name="firstVertex">要渲染的第一个顶点的索引</param>
        /// <param name="vertexCount">要渲染多少个顶点？</param>
        internal ZeroIndexBufferPtr(DrawMode mode, int firstVertex, int vertexCount)
            : base(mode, 0, vertexCount, vertexCount * sizeof(uint))
        {
            this.FirstVertex = firstVertex;
            this.VertexCount = vertexCount;
            this.OriginalVertexCount = vertexCount;
        }

        /// <summary>
        /// 要渲染的第一个顶点的索引。
        /// </summary>
        public int FirstVertex { get; set; }

        /// <summary>
        /// 要渲染多少个顶点。
        /// </summary>
        public int VertexCount { get; set; }

        public int OriginalVertexCount { get; private set; }

        public override void Render(RenderEventArg arg, ShaderProgram shaderProgram)
        {
            if (arg.RenderMode == RenderModes.ColorCodedPicking
                && arg.PickingGeometryType == GeometryType.Point
                && this.Mode.ToGeometryType() == GeometryType.Line)// picking point from a line
            {
                // this maybe render points that should not appear. 
                // so need to select by another picking.
                OpenGL.DrawArrays((uint)DrawMode.Points, this.FirstVertex, this.VertexCount);
            }
            else
            {
                OpenGL.DrawArrays((uint)this.Mode, this.FirstVertex, this.VertexCount);
            }
        }

        public override string ToString()
        {
            return string.Format("OpenGL.DrawArrays({0}, {1}, {2})",
                this.Mode, this.FirstVertex, this.VertexCount);
        }
    }
}
