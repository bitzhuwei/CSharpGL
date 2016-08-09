using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace CSharpGL.SceneEditor
{
    public partial class FormMain
    {

        void glCanvas1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 't' || e.KeyChar == 'T')
            {
                this.timer1.Enabled = !this.timer1.Enabled;
                this.scene.Running = this.timer1.Enabled;
            }
        }

    }
}
