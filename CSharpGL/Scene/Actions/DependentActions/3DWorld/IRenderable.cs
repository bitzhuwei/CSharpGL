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
    public interface IRenderable
    {
        /// <summary>
        /// 
        /// </summary>
        ThreeFlags EnableRendering { get; set; }

        /// <summary>
        /// Render something.
        /// </summary>
        /// <param name="arg"></param>
        void RenderBeforeChildren(RenderEventArgs arg);

        /// <summary>
        /// Render something.
        /// </summary>
        /// <param name="arg"></param>
        void RenderAfterChildren(RenderEventArgs arg);
    }

    /// <summary>
    /// Render event argument.
    /// </summary>
    public class RenderEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RenderEventArgs"/> class.
        /// </summary>
        /// <param name="rootNode"></param>
        /// <param name="param"></param>
        /// <param name="camera"></param>
        public RenderEventArgs(SceneNodeBase rootNode, ActionParams param, ICamera camera)
        {
            this.RootNode = rootNode;
            this.Param = param;
            this.Camera = camera;

            this.ModelMatrixStack = new Stack<mat4>();
            this.ModelMatrixStack.Push(mat4.identity());
        }

        /// <summary>
        /// The top ccamera is currently in use.
        /// </summary>
        public ICamera Camera { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        internal Stack<mat4> ModelMatrixStack { get; private set; }

        ///// <summary>
        ///// 
        ///// </summary>
        //public Scene Scene { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public SceneNodeBase RootNode { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public ActionParams Param { get; private set; }

    }
}