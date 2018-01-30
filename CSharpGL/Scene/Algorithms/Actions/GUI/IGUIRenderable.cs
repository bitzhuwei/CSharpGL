using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;

namespace CSharpGL
{
    /// <summary>
    /// Render something.
    /// </summary>
    [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
    public interface IGUIRenderable
    {
        /// <summary>
        /// 
        /// </summary>
        ThreeFlags EnableGUIRendering { get; set; }

        /// <summary>
        /// Render something.
        /// </summary>
        /// <param name="arg"></param>
        void RenderGUIBeforeChildren(GUIRenderEventArgs arg);

        /// <summary>
        /// Render something.
        /// </summary>
        /// <param name="arg"></param>
        void RenderGUIAfterChildren(GUIRenderEventArgs arg);
    }

    /// <summary>
    /// Render event argument.
    /// </summary>
    public class GUIRenderEventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public ActionParams Param { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GUIRenderEventArgs"/> class.
        /// </summary>
        public GUIRenderEventArgs(ActionParams param)
        {
            this.Param = param;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}", this.Param);
        }
    }
}