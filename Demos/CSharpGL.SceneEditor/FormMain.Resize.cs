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

        void glCanvas1_Resize(object sender, EventArgs e)
        {
            GLCanvas canvas = sender as GLCanvas;

            this.Scene.Camera.Resize(canvas.Width, canvas.Height);
        }

    }
}
