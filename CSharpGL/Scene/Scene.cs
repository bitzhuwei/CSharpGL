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
        public Camera Camera { get; private set; }

        private ChildList<SceneObject> objectList = new ChildList<SceneObject>();
        /// <summary>
        /// objects to be rendered.
        /// </summary>
        [Editor(typeof(IListEditor<SceneObject>), typeof(UITypeEditor))]
        public ChildList<SceneObject> ObjectList { get { return this.objectList; } }

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
        /// <param name="camera">camera of the scene</param>
        /// <param name="objects">objects to be rendered</param>
        public Scene(Camera camera, params SceneObject[] objects)
        {
            if (camera == null)
            { throw new ArgumentNullException(); }

            this.Camera = camera;
            this.ObjectList.AddRange(objects);
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
            this.RenderObjects(this.ObjectList, arg);

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

        private void RenderObjects(ChildList<SceneObject> list, RenderEventArgs arg)
        {
            var array = list.ToArray();
            foreach (var obj in array)
            {
                obj.Render(arg);
                RenderObjects(obj.Children, arg);
            }
        }
    }
}
