using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL
{
    /// <summary>
    /// Execute some drawing command(glDrawArrays etc..).
    /// </summary>
    public interface IDrawCommand
    {
        /// <summary>
        /// 执行渲染操作。
        /// <para>Render.</para>
        /// </summary>
        /// <param name="controlMode">index buffer is accessable randomly or only by frame.</param>
        void Draw(ControlMode controlMode);

    }

    /// <summary>
    /// 
    /// </summary>
    public enum ControlMode
    {
        /// <summary>
        /// 
        /// </summary>
        ByFrame,

        /// <summary>
        /// 
        /// </summary>
        Random,

    }
}