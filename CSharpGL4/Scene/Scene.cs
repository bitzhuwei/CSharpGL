using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// camera, canvas, renderers.
    /// rendering, picking.
    /// </summary>
    public partial class Scene
    {
        /// <summary>
        /// 
        /// </summary>
        public ICamera Camera { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IGLCanvas Canvas { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public RendererBase RootElement { get; set; }

        private vec3 clearColor = new vec3(0.0f, 0.0f, 0.0f);
        /// <summary>
        /// 
        /// </summary>
        public Color ClearColor
        {
            get { return clearColor.ToColor(); }
            set { this.clearColor = value.ToVec3(); }
        }

        /// <summary>
        /// camera, canvas, renderers.
        /// rendering, picking. 
        /// </summary>
        /// <param name="camera"></param>
        /// <param name="canvas"></param>
        public Scene(ICamera camera, IGLCanvas canvas)
        {
            this.Camera = camera;
            this.Canvas = canvas;
        }
    }
}