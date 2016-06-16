using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;

namespace CSharpGL
{
    /// <summary>
    /// Description of Component.
    /// </summary>
    [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
    public partial class Scene
    {
        public Color ClearColor { get; set; }

        public Camera Camera { get; private set; }

        public SceneObjectList ObjectList { get; private set; }

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
