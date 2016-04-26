using CSharpGL.ModelAdapters;
using CSharpGL.Models;
using GLM;
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

namespace CSharpGL.Demos
{
    public partial class Form02EmitNormalLine : Form
    {

        private void glCanvas1_MouseDown(object sender, MouseEventArgs e)
        {
            this.mousePosition = new Point(e.X, e.Y);

            rotator.SetBounds(this.glCanvas1.Width, this.glCanvas1.Height);
            rotator.MouseDown(e.X, e.Y);
        }

        private void glCanvas1_MouseMove(object sender, MouseEventArgs e)
        {
            this.mousePosition = new Point(e.X, e.Y);

            if (rotator.MouseDownFlag)
            {
                rotator.MouseMove(e.X, e.Y);
                //this.cameraUpdated = true;
            }
            else
            {
                RunPicking(e.X, e.Y);
            }
        }

        private void RunPicking(int x, int y)
        {
            lock (this.synObj)
            {
                {
                    this.glCanvas1_OpenGLDraw(selectedModel, null);
                    Color c = GL.ReadPixel(x, this.glCanvas1.Height - y - 1);
                    c = Color.FromArgb(255, c);
                    this.lblColor.BackColor = c;
                    this.lblReadColor.Text = string.Format(
                        "Color at {0}: {1}",
                        new Point(x, this.glCanvas1.Height - y - 1), c);
                }
                {
                    IColorCodedPicking pickable = this.rendererDict[this.SelectedModel];
                    pickable.MVP = this.camera.GetProjectionMat4() * this.camera.GetViewMat4();
                    PickedGeometry pickedGeometry = ColorCodedPicking.Pick(
                        this.camera, x, y, this.glCanvas1.Width, this.glCanvas1.Height, pickable);
                    if (pickedGeometry != null)
                    {
                        this.bulletinBoard.SetContent(pickedGeometry.ToString(
                            camera.GetProjectionMat4(), camera.GetViewMat4()));
                    }
                    else
                    {
                        this.bulletinBoard.SetContent("picked nothing.");
                    }
                }
            }
        }

        private void glCanvas1_MouseUp(object sender, MouseEventArgs e)
        {
            this.mousePosition = new Point(e.X, e.Y);

            rotator.MouseUp(e.X, e.Y);
        }

    }
}
