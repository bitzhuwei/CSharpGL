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
        ThreeFlags EnableRendering { get; set; }

        /// <summary>
        /// Render something.
        /// </summary>
        /// <param name="arg"></param>
        void RenderBeforeChildren(GUIRenderEventArgs arg);

        /// <summary>
        /// Render something.
        /// </summary>
        /// <param name="arg"></param>
        void RenderAfterChildren(GUIRenderEventArgs arg);
    }

    /// <summary>
    /// Render event argument.
    /// </summary>
    public class GUIRenderEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RenderEventArgs"/> class.
        /// </summary>
        public GUIRenderEventArgs(Scene scene, params ICamera[] cameras)
        {
            this.Scene = scene;

            var cameraStack = new Stack<ICamera>();
            foreach (var item in cameras)
            {
                cameraStack.Push(item);
            }

            this.CameraStack = cameraStack;
            this.CurrentLights = new Stack<List<LightBase>>();

            this.ModelMatrixStack = new Stack<mat4>();
            this.ModelMatrixStack.Push(mat4.identity());
        }

        /// <summary>
        /// The top ccamera is currently in use.
        /// </summary>
        public Stack<ICamera> CameraStack { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public Stack<List<LightBase>> CurrentLights { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        internal Stack<mat4> ModelMatrixStack { get; private set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <returns></returns>
        //public virtual mat4 GetViewMatrix()
        //{
        //    return this.Scene.Camera.GetViewMatrix();
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <returns></returns>
        //public virtual mat4 GetProjectionMatrix()
        //{
        //    return this.Scene.Camera.GetProjectionMatrix();
        //}

        /// <summary>
        /// 
        /// </summary>
        public Scene Scene { get; private set; }
    }
}