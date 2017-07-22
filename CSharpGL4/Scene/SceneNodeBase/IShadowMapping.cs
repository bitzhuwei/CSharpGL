using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;

namespace CSharpGL
{
    /// <summary>
    /// Supports shadow mapping.
    /// </summary>
    [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
    public interface IShadowMapping
    {
        /// <summary>
        /// Is casting shadow for this object enabled?
        /// </summary>
        bool EnableShadowMapping { get; set; }

        /// <summary>
        /// Cast shadow to specified texture in framebuffer, or Prepare for its children to cast shadow.
        /// </summary>
        /// <param name="arg"></param>
        void CastShadow(ShdowMappingEventArgs arg);
    }

    /// <summary>
    /// Render event argument.
    /// </summary>
    public class ShdowMappingEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RenderEventArgs"/> class.
        /// </summary>
        public ShdowMappingEventArgs(params ICamera[] cameras)
        {
            var cameraStack = new Stack<ICamera>();
            foreach (var item in cameras)
            {
                cameraStack.Push(item);
            }

            this.CameraStack = cameraStack;

            this.ModelMatrixStack = new Stack<mat4>();
            this.ModelMatrixStack.Push(mat4.identity());

            this.LightStack = new Stack<LightBase>();
        }

        /// <summary>
        /// The top ccamera is currently in use.
        /// </summary>
        public Stack<ICamera> CameraStack { get; private set; }

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
        internal Stack<LightBase> LightStack { get; private set; }
    }
}