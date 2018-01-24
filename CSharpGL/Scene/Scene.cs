using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// camera, canvas, nodes.
    /// rendering, picking.
    /// </summary>
    public partial class Scene
    {
        /// <summary>
        /// 
        /// </summary>
        public ICamera Camera { get; set; }

        ///// <summary>
        ///// 
        ///// </summary>
        //public IGLCanvas Canvas { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public SceneNodeBase RootElement { get; set; }

        private List<LightBase> lights = new List<LightBase>();
        /// <summary>
        /// All lights in the scene.
        /// </summary>
        public List<LightBase> Lights { get { return this.lights; } }

        /// <summary>
        /// 
        /// </summary>
        public GLControl RootControl { get; set; }

        private vec4 clearColor = Color.SkyBlue.ToVec4();
        /// <summary>
        /// 
        /// </summary>
        public vec4 ClearColor
        {
            get { return clearColor; }
            set { this.clearColor = value; }
        }

        /// <summary>
        /// Ambient color.
        /// </summary>
        public vec3 AmbientColor { get; set; }

        /// <summary>
        /// camera, canvas, nodes.
        /// rendering, picking. 
        /// </summary>
        /// <param name="camera"></param>
        public Scene(ICamera camera)
        {
            this.Camera = camera;
            this.AmbientColor = new vec3(0.1f, 0.1f, 0.7f);
        }
    }
}