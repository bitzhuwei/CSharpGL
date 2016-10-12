using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;

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
        public ICamera FirstCamera
        {
            get
            {
                return GetCamera(this.rootViewPort);
            }
        }

        private ICamera GetCamera(ViewPort viewport)
        {
            if (viewport.Camera != null) { return viewport.Camera; }

            foreach (var item in viewport.Children)
            {
                ICamera camera = GetCamera(item);
                if (camera != null)
                {
                    return camera;
                }
            }
            return null;
        }

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