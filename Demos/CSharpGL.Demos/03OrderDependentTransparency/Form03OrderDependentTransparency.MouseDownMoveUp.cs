using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace CSharpGL.Demos
{
    public partial class Form03OrderDependentTransparency : Form
    {

        private Point lastMousePosition;

        internal void glCanvas1_MouseDown(object sender, MouseEventArgs e)
        {
            this.lastMousePosition = e.Location;

            if (sender == this.glCanvas1)
            {
                form02.glCanvas1_MouseDown(sender, e);
            }
            else
            {
                // operate camera
                rotator.canvas_MouseDown(sender, e);
            }
        }

        internal void glCanvas1_MouseMove(object sender, MouseEventArgs e)
        {
            if (lastMousePosition == e.Location) { return; }

            this.lastMousePosition = e.Location;

            if (sender == this.glCanvas1)
            {
                form02.glCanvas1_MouseMove(sender, e);
            }
            else
            {
                // operate camera
                rotator.canvas_MouseMove(sender, e);
            }
        }

        internal void glCanvas1_MouseUp(object sender, MouseEventArgs e)
        {
            this.lastMousePosition = e.Location;

            if (sender == this.glCanvas1)
            {
                form02.glCanvas1_MouseUp(sender, e);
            }
            else
            {
                // operate camera
                rotator.canvas_MouseUp(sender, e);
            }
        }

    }
}
