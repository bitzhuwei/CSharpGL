using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL {
    /// <summary>
    /// Execute some drawing command(glDrawArrays etc..).
    /// </summary>

    public interface IDrawCommand {
        /// <summary>
        /// 用哪种方式渲染各个顶点？（GL.GL_TRIANGLES etc.）
        /// </summary>
        DrawMode Mode { get; set; }

        /// <summary>
        /// 执行渲染操作。
        /// <para>Render.</para>
        /// </summary>
        void Draw();

    }

}