using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;

namespace CSharpGL
{
    /// <summary>
    /// Supports shadow volume.
    /// </summary>
    [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
    public interface ISupportShadowVolume
    {
        /// <summary>
        /// Is extruding shadow enabled for this object and its children?
        /// </summary>
        TwoFlags EnableShadowVolume { get; set; }

        /// <summary>
        /// Render node so that depth buffer is filled with valid data.
        /// </summary>
        /// <param name="arg"></param>
        void RenderToDepthBuffer(RenderEventArgs arg);

        /// <summary>
        /// Extrude shadow volume for stencil operation.
        /// </summary>
        /// <param name="arg"></param>
        void ExtrudeShadow(ShadowVolumeEventArgs arg);

        /// <summary>
        /// Add ambient color effect at last.
        /// </summary>
        /// <param name="arg"></param>
        void RenderAmbientColor(RenderEventArgs arg);
    }

    /// <summary>
    /// Render event argument.
    /// </summary>
    public class ShadowVolumeEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RenderEventArgs"/> class.
        /// </summary>
        public ShadowVolumeEventArgs()
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