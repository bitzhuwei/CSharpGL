﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CSharpGL;

namespace StencilTest
{
    public partial class Form1HowStencilWorks
    {

        void winGLCanvas1_MouseMove(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int y = this.winGLCanvas1.Height - e.Y - 1;
            var pickedGeometry = this.pickingAction.Pick(x, y, true, true, false);

            var lastNode = this.lastPickedNode as OutlineCubeNode;

            this.lastPickedNode = null;// we will pick again.

            OutlineCubeNode currentNode = null;
            if (pickedGeometry != null)
            {
                currentNode = pickedGeometry.FromRenderer as OutlineCubeNode;
            }

            if (lastNode != currentNode)
            {
                if (lastNode != null) { lastNode.DisplayOutline = false; }

                if (currentNode != null) { currentNode.DisplayOutline = true; }
            }

            this.lastPickedNode = currentNode;
            this.lblState.Text = string.Format("picked: {0}", this.lastPickedNode);
        }

        IPickable lastPickedNode;
    }
}
