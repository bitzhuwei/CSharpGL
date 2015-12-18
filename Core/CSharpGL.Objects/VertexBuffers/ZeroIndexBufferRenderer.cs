using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects.VertexBuffers
{
    /// <summary>
    /// 没有显式索引时的渲染方法。
    /// </summary>
    public class ZeroIndexBufferRenderer : IndexBufferBaseRenderer
    {
        /// <summary>
        /// 没有显式索引时的渲染方法。
        /// </summary>
        /// <param name="bufferID">用GL.GenBuffers()得到的VBO的ID。</param>
        /// <param name="mode">用哪种方式渲染各个顶点？（OpenGL.GL_TRIANGLES etc.）</param>
        ///<param name="firstVertex">要渲染的第一个顶点的索引</param>
        /// <param name="vertexCount">要渲染多少个顶点？</param>
        internal ZeroIndexBufferRenderer(DrawMode mode, int firstVertex, int vertexCount)
            : base(mode, 0)
        {
            this.FirstVertex = firstVertex;
            this.VertexCount = vertexCount;
        }

        /// <summary>
        /// 要渲染的第一个顶点的索引。
        /// </summary>
        public int FirstVertex { get; set; }

        /// <summary>
        /// 数组中有多少个顶点。
        /// </summary>
        public int VertexCount { get; set; }

        public override void Render(RenderEventArgs e, Shaders.ShaderProgram shaderProgram)
        {
            GL.DrawArrays(this.Mode, 0, this.VertexCount);
        }
    }
}
