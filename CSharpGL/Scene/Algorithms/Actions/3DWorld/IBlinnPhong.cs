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
        void RenderAmbientColor(BlinnPhongAmbientEventArgs arg);

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

    /// <summary>
    /// </summary>
    public class BlinnPhongAmbientEventArgs : RenderEventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="camera"></param>
        /// <param name="ambient"></param>
        public BlinnPhongAmbientEventArgs(ActionParams param, ICamera camera, vec3 ambient)
            : base(param, camera)
        {
            this.Ambient = ambient;
        }

        /// <summary>
        /// 
        /// </summary>
        public vec3 Ambient { get; private set; }

    }

}