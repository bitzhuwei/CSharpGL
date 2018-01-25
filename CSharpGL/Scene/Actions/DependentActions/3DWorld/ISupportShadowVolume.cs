﻿using System.Collections.Generic;
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
        /// Render the node under the specified light.
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="light"></param>
        void RenderUnderLight(RenderEventArgs arg, LightBase light);

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
        public ShadowVolumeEventArgs(ICamera camera, LightBase light)
        {
            this.Camera = camera;
            this.Light = light;
        }

        /// <summary>
        /// 
        /// </summary>
        public LightBase Light { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ICamera Camera { get; set; }
    }
}