using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpGL.EarthMoonSystem
{
    public partial class FormMain
    {

        void Application_Idle(object sender, EventArgs e)
        {
            this.lblInfo.Text = string.Format("Elapsed: {0}, Earth: {1}",
                new TimeSpan((long)(DateTime.Now.Subtract(startTime).Ticks * this.TimeSpeed)),
                this.earth);
        }

        void glCanvas1_Resize(object sender, EventArgs e)
        {
            Camera camera = this.camera;
            Control control = sender as Control;
            if (camera != null)
            {
                camera.Resize(control.Width, control.Height);
            }
        }

    }
}
