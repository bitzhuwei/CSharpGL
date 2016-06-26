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

        /// <summary>
        /// objects to be rendered.
        /// </summary>
        public SceneObjectList ObjectList { get; private set; }

        /// <summary>
        /// hosts all UI renderers.
        /// </summary>
        public UIRoot UIRoot { get; private set; }

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
            var list = new SceneObjectList();
            list.AddRange(objects);
            this.ObjectList = list;
            this.UIRoot = new UIRoot();
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
        }

        public void Render(RenderModes renderMode, Rectangle clientRectangle)
        {
            var arg = new RenderEventArg(renderMode, clientRectangle, this.Camera);
            var list = this.ObjectList.ToArray();
            foreach (var item in list)
            {
                item.Render(arg);
            }
            this.UIRoot.Render(arg);
        }
    }
}
