using CSharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace GridViewer
{
    public partial class FormMain
    {

        private void sceneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new FormProperyGrid(this.scientificCanvas.Scene)).Show();
        }

    }
}
