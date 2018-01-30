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
        /// Is shadow volume technique for this object and its children?
        /// </summary>
        TwoFlags EnableShadowVolume { get; set; }

        /// <summary>
        /// Add ambient color effect at last.
        /// </summary>
        /// <param name="arg"></param>
        void RenderAmbientColor(ShadowVolumeAmbientEventArgs arg);

        /// <summary>
        /// Is extruding shadow enabled for this object and its children?
        /// </summary>
        TwoFlags EnableExtrude { get; set; }

        /// <summary>
        /// Extrude shadow volume for stencil operation.
        /// </summary>
        /// <param name="arg"></param>
        void ExtrudeShadow(ShadowVolumeExtrudeEventArgs arg);

        /// <summary>
        /// Is extruding shadow enabled for this object and its children?
        /// </summary>
        TwoFlags EnableRenderUnderLight { get; set; }

        /// <summary>
        /// Render the node under the specified light.
        /// </summary>
        /// <param name="arg"></param>
        void RenderUnderLight(ShadowVolumeUnderLightEventArgs arg);

    }

    /// <summary>
    /// 
    /// </summary>
    public class ShadowVolumeAmbientEventArgs : RenderEventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="camera"></param>
        /// <param name="ambient"></param>
        public ShadowVolumeAmbientEventArgs(ActionParams param, ICamera camera, vec3 ambient)
            : base(param, camera)
        {
            this.Ambient = ambient;
        }

        /// <summary>
        /// 
        /// </summary>
        public vec3 Ambient { get; private set; }

    }

    /// <summary>
    /// 
    /// </summary>
    public class ShadowVolumeExtrudeEventArgs : RenderEventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="camera"></param>
        /// <param name="light"></param>
        public ShadowVolumeExtrudeEventArgs(ActionParams param, ICamera camera, LightBase light)
            : base(param, camera)
        {
            this.Light = light;
        }

        /// <summary>
        /// 
        /// </summary>
        public LightBase Light { get; set; }

    }

    /// <summary>
    /// </summary>
    public class ShadowVolumeUnderLightEventArgs : RenderEventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="camera"></param>
        /// <param name="light"></param>
        public ShadowVolumeUnderLightEventArgs(ActionParams param, ICamera camera, LightBase light)
            : base(param, camera)
        {
            this.Light = light;
        }

        /// <summary>
        /// 
        /// </summary>
        public LightBase Light { get; set; }

    }
}