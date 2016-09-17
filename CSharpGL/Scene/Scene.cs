using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;

namespace CSharpGL
{
    /// <summary>
    /// Manages a scene to be rendered and updated.
    /// </summary>
    [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
    public partial class Scene
    {
        private UIRoot cursorRoot = new UIRoot();
        private UIRoot uiRoot = new UIRoot();
        private SceneRootObject rootObject;

        /// <summary>
        /// Manages a scene to be rendered and updated.
        /// </summary>
        /// <param name="camera">Camera of the scene</param>
        /// <param name="canvas">Canvas that this scene binds to.</param>
        /// <param name="objects">Objects to be rendered</param>
        public Scene(Camera camera, ICanvas canvas, params SceneObject[] objects)
        {
            if (camera == null) { throw new ArgumentNullException(); }

            if (canvas == null) { throw new ArgumentNullException(); }

            this.Camera = camera;
            this.Canvas = canvas;
            var rootObject = new SceneRootObject(this);
            rootObject.Children.AddRange(objects);
            this.rootObject = rootObject;
            var cursor = UICursor.CreateDefault();
            cursor.Enabled = false;
            this.cursorRoot.Children.Add(cursor);
            this.Cursor = cursor;
        }

        /// <summary>
        /// camera of the scene.
        /// </summary>
        public ICamera Camera { get; private set; }

        /// <summary>
        /// Canvas that this scene binds to.
        /// </summary>
        public ICanvas Canvas { get; set; }

        /// <summary>
        /// background color.
        /// </summary>
        public Color ClearColor { get; set; }

        /// <summary>
        /// OpenGL UI for cursor.
        /// </summary>
        public UICursor Cursor { get; set; }

        /// <summary>
        /// Root object of all objects to be rendered in the scene.
        /// </summary>
        public SceneRootObject RootObject { get { return rootObject; } }

        /// <summary>
        /// hosts all UI renderers.
        /// </summary>
        public UIRoot UIRoot { get { return this.uiRoot; } }

        /// <summary>
        /// Please bind this method to Control.Resize event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Resize(object sender, EventArgs e)
        {
            var control = sender as Control;
            if (control == null) { throw new ArgumentException(); }

            this.Camera.Resize(control.Width, control.Height);

            this.uiRoot.Size = control.Size;
            this.cursorRoot.Size = control.Size;
        }
    }
}