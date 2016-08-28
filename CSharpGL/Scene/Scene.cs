using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Linq;

namespace CSharpGL
{
    /// <summary>
    /// Manages a scene to be rendered and updated.
    /// </summary>
    [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
    public partial class Scene
    {
        /// <summary>
        /// background color.
        /// </summary>
        public Color ClearColor { get; set; }

        /// <summary>
        /// camera of the scene.
        /// </summary>
        public ICamera Camera { get; private set; }

        /// <summary>
        /// Canvas that this scene binds to.
        /// </summary>
        public ICanvas Canvas { get; set; }

        private SceneRootObject rootObject;
        /// <summary>
        /// Root object of all objects to be rendered in the scene.
        /// </summary>
        public SceneRootObject RootObject { get { return rootObject; } }

        private UIRoot uiRoot = new UIRoot();
        /// <summary>
        /// hosts all UI renderers.
        /// </summary>
        public UIRoot UIRoot { get { return this.uiRoot; } }

        private UIRoot cursorRoot = new UIRoot();
        /// <summary>
        /// OpenGL UI for cursor.
        /// </summary>
        public UICursor Cursor { get; set; }

        /// <summary>
        /// Manages a scene to be rendered and updated.
        /// </summary>
        /// <param name="camera">Camera of the scene</param>
        /// <param name="canvas">Canvas that this scene binds to.</param>
        /// <param name="objects">Objects to be rendered</param>
        public Scene(Camera camera, ICanvas canvas, params SceneObject[] objects)
        {
            if (camera == null)
            { throw new ArgumentNullException(); }

            if (canvas == null)
            { throw new ArgumentNullException(); }

            this.Camera = camera;
            this.Canvas = canvas;
            var rootObject = new SceneRootObject(this);
            rootObject.Children.AddRange(objects);
            this.rootObject = rootObject;
            this.Cursor = UICursor.CreateDefault();
            this.cursorRoot.Children.Add(this.Cursor);
        }

        /// <summary>
        /// Please bind this method to Control.Resize event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Resize(object sender, EventArgs e)
        {
            Control control = sender as Control;
            if (control == null) { throw new ArgumentException(); }

            this.Camera.Resize(control.Width, control.Height);


            this.uiRoot.Size = control.Size;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="renderMode"></param>
        /// <param name="clientRectangle"></param>
        /// <param name="mousePosition">mouse position in window coordinate system.</param>
        public void Render(RenderModes renderMode, Rectangle clientRectangle, Point mousePosition)
        {
            var arg = new RenderEventArgs(renderMode, clientRectangle, this.Camera);

            // render objects.
            {
                SceneRootObject rootObject = this.RootObject;
                this.RenderObject(rootObject, arg);
            }

            // render regular UI.
            this.UIRoot.Render(arg);

            // render cursor.
            UICursor cursor = this.Cursor;
            if (cursor.Enabled)
            {
                cursor.UpdatePosition(mousePosition);
                this.cursorRoot.Render(arg);
            }
        }

        private void RenderObject(SceneObject sceneObject, RenderEventArgs arg)
        {
            sceneObject.Render(arg);
            SceneObject[] array = sceneObject.Children.ToArray();
            foreach (var child in array)
            {
                RenderObject(child, arg);
            }
        }

    }
}
