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
        /// Manages a scene to be rendered and updated.
        /// </summary>
        /// <param name="camera">camera of the scene</param>
        /// <param name="objects">objects to be rendered</param>
        public Scene(Camera camera, params SceneObject[] objects)
        {
            if (camera == null)
            { throw new ArgumentNullException(); }

            this.Camera = camera;
            this.ObjectList = new SceneObjectList();
            this.ObjectList.AddRange(objects);
        }

        public void Resize(object sender, EventArgs e)
        {
            Control control = sender as Control;
            this.Camera.Resize(control.Width, control.Height);
        }
    }
}
