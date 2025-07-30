using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.IO;
using System.Linq;
using System.Text;

namespace CSharpGL {
    /// <summary>
    /// camera, canvas, nodes.
    /// rendering, picking.
    /// </summary>

    public partial class Scene {
        /// <summary>
        /// 
        /// </summary>

        public ICamera camera;

        ///// <summary>
        ///// 
        ///// </summary>
        //public IGLCanvas Canvas { get; set; }

        /// <summary>
        /// 
        /// </summary>

        public SceneNodeBase? RootNode;

        /// <summary>
        /// All lights in the scene.
        /// </summary>

        public readonly List<LightBase> lights = new();

        /// <summary>
        /// 
        /// </summary>

        public GLControl? RootControl;

        public vec4 clearColor = Color.SkyBlue.ToVec4();

        /// <summary>
        /// Ambient color.
        /// </summary>

        public vec3 ambientColor;

        /// <summary>
        /// camera, canvas, nodes.
        /// rendering, picking. 
        /// </summary>
        /// <param name="camera"></param>
        public Scene(ICamera camera) {
            this.camera = camera;
            this.ambientColor = new vec3(1, 1, 1) * 0.2f;
        }
    }
}