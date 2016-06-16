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
            this.Camera = new Camera(new vec3(5, 5, 5), new vec3(0, 0, 0), new vec3(0, 1, 0),
                 CameraType.Perspecitive, this.glCanvas1.Width, this.glCanvas1.Height);

            this.glCanvas1.Resize += glCanvas1_Resize;
            this.glCanvas1.OpenGLDraw += new System.EventHandler<System.Windows.Forms.PaintEventArgs>(this.glCanvas1_OpenGLDraw);
        }


    }
}
