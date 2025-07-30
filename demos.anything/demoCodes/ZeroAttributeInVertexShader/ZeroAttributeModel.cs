using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZeroAttributeInVertexShader {

    /// <summary>
    /// Bufferable model with zero vertex attribute.
    /// </summary>
    public class ZeroAttributeModel : IBufferSource {
        /// <summary>
        /// 用哪种方式渲染各个顶点？（OpenGL.GL_TRIANGLES etc.）
        /// </summary>
        public CSharpGL.DrawMode Mode { get; private set; }

        /// <summary>
        /// 要渲染多少个元素？<para>How many vertexes to be rendered?</para>
        /// </summary>
        public int VertexCount { get; private set; }

        /// <summary>
        /// Bufferable model with zero vertex attribute.
        /// </summary>
        /// <param name="mode">渲染模式。</param>
        /// <param name="vertexCount">要渲染多少个元素？<para>How many vertexes to be rendered?</para></param>
        public ZeroAttributeModel(CSharpGL.DrawMode mode, int vertexCount) {
            this.Mode = mode;
            this.VertexCount = vertexCount;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="bufferName"></param>
        /// <param name="varNameInShader"></param>
        /// <returns></returns>
        public IEnumerable<VertexBuffer> GetVertexAttribute(string bufferName) {
            throw new Exception("No vertex attribute buffer for this model!");
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IDrawCommand> GetDrawCommand() {
            if (this.drawCmd == null) {
                this.drawCmd = new DrawArraysCmd(this.Mode, this.VertexCount);
            }

            yield return this.drawCmd;
        }

        private IDrawCommand drawCmd;

    }
}
