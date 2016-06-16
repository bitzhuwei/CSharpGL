using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpGL.SceneEditor
{
    public partial class FormMain
    {

        void FormMain_Load(object sender, EventArgs e)
        {
            InitializeNodeContextMenuStrip();

            InitializeScene();

            InitializeEvents();
        }

        private void InitializeEvents()
        {
            this.glCanvas1.Resize += this.Scene.Resize;
            this.glCanvas1.OpenGLDraw += new System.EventHandler<System.Windows.Forms.PaintEventArgs>(this.glCanvas1_OpenGLDraw);
        }

        private void InitializeScene()
        {
            var camera = new Camera(new vec3(1, 2, 3), new vec3(0, 0, 0), new vec3(0, 1, 0),
               CameraType.Perspecitive, this.glCanvas1.Width, this.glCanvas1.Height);
            this.Scene = new Scene(camera);
        }

        private void InitializeNodeContextMenuStrip()
        {
            string[] names = Enum.GetNames(typeof(BuildInSceneObject));
            foreach (var item in names)
            {
                this.addSceneObjectToolStripMenuItem.DropDownItems.Add(item, null,
                    this.addSceneObjectToolStripMenuItem_Click);
            }
        }


    }
}
