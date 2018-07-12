using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.IO;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// camera, canvas, nodes.
    /// rendering, picking.
    /// </summary>
    [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
    public partial class Scene
    {
        /// <summary>
        /// 
        /// </summary>
        [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
        public ICamera Camera { get; set; }

        ///// <summary>
        ///// 
        ///// </summary>
        //public IGLCanvas Canvas { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
        public SceneNodeBase RootNode { get; set; }

        private List<LightBase> lights = new List<LightBase>();
        /// <summary>
        /// All lights in the scene.
        /// </summary>
        [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
        public List<LightBase> Lights { get { return this.lights; } }

        /// <summary>
        /// 
        /// </summary>
        [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
        public GLControl RootControl { get; set; }

        private vec4 clearColor = Color.SkyBlue.ToVec4();
        /// <summary>
        /// 
        /// </summary>
        [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
        public vec4 ClearColor
        {
            get { return clearColor; }
            set { this.clearColor = value; }
        }

        /// <summary>
        /// Ambient color.
        /// </summary>
        [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
        public vec3 AmbientColor { get; set; }

        /// <summary>
        /// camera, canvas, nodes.
        /// rendering, picking. 
        /// </summary>
        /// <param name="camera"></param>
        public Scene(ICamera camera)
        {
            this.Camera = camera;
            this.AmbientColor = new vec3(1, 1, 1) * 0.2f;
        }
    }
}