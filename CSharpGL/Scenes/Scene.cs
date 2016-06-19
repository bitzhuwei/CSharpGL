using System;
using System.Collections.Generic;
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
        private vec4 clearColor = new vec4();
        /// <summary>
        /// background color.
        /// </summary>
        public Color ClearColor
        {
            get
            {
                return Color.FromArgb(
                    (int)(clearColor.w * 255),
                    (int)(clearColor.x * 255),
                    (int)(clearColor.y * 255),
                    (int)(clearColor.z * 255));
            }
            set
            {
                this.clearColor.x = value.R / 255.0f;
                this.clearColor.y = value.G / 255.0f;
                this.clearColor.z = value.B / 255.0f;
                this.clearColor.w = value.A / 255.0f;
            }
        }

        /// <summary>
        /// camera of the scene.
        /// </summary>
        public Camera Camera { get; private set; }

        /// <summary>
        /// objects to be rendered.
        /// </summary>
        public IList<SceneObject> ObjectList { get; private set; }

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
        }

        public void Resize(object sender, EventArgs e)
        {
            Control control = sender as Control;
            this.Camera.Resize(control.Width, control.Height);
        }

    }
}
