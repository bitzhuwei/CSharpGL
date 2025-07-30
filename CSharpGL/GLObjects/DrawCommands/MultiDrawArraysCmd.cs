using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL {
    /// <summary>
    /// Render something using 'glMultiDrawArrays'.
    /// </summary>
    [Browsable(true)]

    public unsafe class MultiDrawArraysCmd : IDrawCommand {
        public readonly int[] first;
        public readonly int[] count;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="first"></param>
        /// <param name="count"></param>
        public MultiDrawArraysCmd(DrawMode mode, int[] first, int[] count) {
            if (first == null || count == null) { throw new System.ArgumentNullException(); }
            if (first.Length != count.Length) { throw new System.ArgumentException(); }

            this.Mode = mode;
            this.first = first;
            this.count = count;
        }

        #region IDrawCommand

        /// <summary>
        /// 用哪种方式渲染各个顶点？（GL.GL_TRIANGLES etc.）
        /// </summary>
        public DrawMode Mode { get; set; }

        /// <summary>
        /// 执行此VBO的渲染操作。
        /// <para>Render using this VBO.</para>
        /// </summary>
        public void Draw() {
            var gl = GL.current; if (gl == null) { return; }
            gl.glMultiDrawArrays((GLenum)this.Mode, this.first, this.count, this.first.Length);
        }

        #endregion IDrawCommand

    }
}