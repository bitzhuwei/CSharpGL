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
    /// </summary>
    public class ShadowVolumeEventArgs
    {
        /// <summary>
        /// </summary>
        public ShadowVolumeEventArgs(LightBase light)
        {
            this.Light = light;
        }

        /// <summary>
        /// 
        /// </summary>
        public LightBase Light { get; set; }
    }
}