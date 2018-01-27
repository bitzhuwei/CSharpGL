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
    public interface ISupportShadowMapping
    {
        /// <summary>
        /// Is casting shadow for enabled this object?
        /// </summary>
        bool EnableShadowMapping { get; set; }

        /// <summary>
        /// Cast shadow to specified texture in framebuffer, or Prepare for its children to cast shadow.
        /// </summary>
        /// <param name="arg"></param>
        void CastShadow(ShadowMappingEventArgs arg);
    }

    /// <summary>
    /// Render event argument.
    /// </summary>
    public class ShadowMappingEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RenderEventArgs"/> class.
        /// </summary>
        public ShadowMappingEventArgs()
        {
            this.ModelMatrixStack = new Stack<mat4>();
            this.ModelMatrixStack.Push(mat4.identity());

            //this.LightStack = new Stack<LightBase>();
        }

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
        ////}
        ///// <summary>
        ///// 
        ///// </summary>
        //internal Stack<LightBase> LightStack { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public LightBase CurrentLight { get; set; }
    }
}