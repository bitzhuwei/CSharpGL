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
        /// Is shadow mapping enabled for this object and its children?
        /// </summary>
        TwoFlags EnableShadowMapping { get; set; }

        /// <summary>
        /// Is casting shadow for enabled this object and its children?
        /// </summary>
        TwoFlags EnableCastShadow { get; set; }

        /// <summary>
        /// Cast shadow to specified texture in framebuffer, or Prepare for its children to cast shadow.
        /// </summary>
        /// <param name="arg"></param>
        void CastShadow(ShadowMappingCastShadowEventArgs arg);

        /// <summary>
        /// Is extruding shadow enabled for this object and its children?
        /// </summary>
        TwoFlags EnableRenderUnderLight { get; set; }

        /// <summary>
        /// Render the node under the specified light.
        /// </summary>
        /// <param name="arg"></param>
        void RenderUnderLight(ShadowMappingUnderLightEventArgs arg);

    }

    /// <summary>
    /// Render event argument.
    /// </summary>
    public class ShadowMappingCastShadowEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShadowMappingCastShadowEventArgs"/> class.
        /// </summary>
        public ShadowMappingCastShadowEventArgs(LightBase light)
        {
            this.Light = light;
        }

        /// <summary>
        /// 
        /// </summary>
        public LightBase Light { get; set; }
    }

    /// <summary>
    /// Render event argument.
    /// </summary>
    public class ShadowMappingUnderLightEventArgs : RenderEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShadowMappingUnderLightEventArgs"/> class.
        /// </summary>
        public ShadowMappingUnderLightEventArgs(ActionParams param, ICamera camera, Texture shadowMap, LightBase light)
            : base(param, camera)
        {
            this.ShadowMap = shadowMap;
            this.Light = light;
        }

        /// <summary>
        /// 
        /// </summary>
        public Texture ShadowMap { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public LightBase Light { get; set; }

    }
}