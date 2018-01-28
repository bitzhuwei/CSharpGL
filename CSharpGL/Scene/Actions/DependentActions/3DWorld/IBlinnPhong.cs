using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;

namespace CSharpGL
{
    /// <summary>
    /// Render something with Blinn-Phong shading model.
    /// </summary>
    [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
    public interface IBlinnPhong
    {
        /// <summary>
        /// 
        /// </summary>
        ThreeFlags EnableRendering { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="ambient"></param>
        void RenderAmbientColor(RendererBaseHelper arg, vec3 ambient);

        /// <summary>
        /// Render something with Blinn-Phong shading model.
        /// </summary>
        /// <param name="arg"></param>
        void RenderBeforeChildren(RenderEventArgs arg);

        /// <summary>
        /// Render something with Blinn-Phong shading model.
        /// </summary>
        /// <param name="arg"></param>
        void RenderAfterChildren(RenderEventArgs arg);
    }

}