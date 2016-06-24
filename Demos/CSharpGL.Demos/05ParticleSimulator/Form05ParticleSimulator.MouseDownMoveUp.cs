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
    public partial class Form05ParticleSimulator : Form
    {

        int lastmousePositionX;
        int lastmousePositionY;

        //internal void glCanvas1_MouseDown(object sender, MouseEventArgs e)
        //{
        //    lastmousePositionX = e.X;
        //    lastmousePositionY = e.Y;

        //    // operate camera
        //    rotator.SetBounds(this.glCanvas1.Width, this.glCanvas1.Height);
        //    rotator.MouseDown(lastmousePositionX, lastmousePositionY);
        //}

        internal void glCanvas1_MouseMove(object sender, MouseEventArgs e)
        {
            if (lastmousePositionX == e.X && lastmousePositionY == e.Y) { return; }

            //// operate camera
            //rotator.MouseMove(e.X, e.Y);

            lastmousePositionX = e.X;
            lastmousePositionY = e.Y;
        }

        //internal void glCanvas1_MouseUp(object sender, MouseEventArgs e)
        //{
        //    // operate camera
        //    rotator.MouseUp(e.X, e.Y);

        //    lastmousePositionX = e.X;
        //    lastmousePositionY = e.Y;
        //}

    }
}
