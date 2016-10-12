using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public partial class Scene
    {

        private const string strScene = "Scene";

        /// <summary>
        /// camera of the scene.
        /// </summary>
        [Category(strScene)]
        [Description("camera of the scene.")]
        [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
        public ICamera Camera { get; private set; }

        /// <summary>
        /// Canvas that this scene binds to.
        /// </summary>
        [Category(strScene)]
        [Description("Canvas that this scene binds to.")]
        [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
        public ICanvas Canvas { get; private set; }

        /// <summary>
        /// background color.
        /// </summary>
        [Category(strScene)]
        [Description("background color.")]
        public Color ClearColor { get; set; }

        ///// <summary>
        ///// OpenGL UI for cursor.
        ///// </summary>
        //public UICursor Cursor { get; set; }

        /// <summary>
        /// Root object of all objects to be rendered in the scene.
        /// </summary>
        [Category(strScene)]
        [Description("Root object of all objects to be rendered in the scene.")]
        [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
        public SceneRootObject RootObject { get { return this.rootObject; } }

        /// <summary>
        /// Root object of all viewports to be rendered in the scene.
        /// </summary>
        [Category(strScene)]
        [Description("Root object of all viewports to be rendered in the scene.")]
        [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
        public SceneRootViewPort RootViewPort { get { return this.rootViewPort; } }

        /// <summary>
        /// hosts all UI renderers.
        /// </summary>
        [Category(strScene)]
        [Description("hosts all UI renderers.")]
        [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
        public SceneRootUI RootUI { get { return this.rootUI; } }

    }
}
