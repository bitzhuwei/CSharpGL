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
    public partial class Form01Simple
    {

        DragParam dragParam;

        private FormBulletinBoard mouseDownBoard;
        private FormBulletinBoard mouseMoveBoard;

        private void glCanvas1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                // operate camera
                rotator.SetBounds(this.glCanvas1.Width, this.glCanvas1.Height);
                rotator.MouseDown(e.X, e.Y);
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                // move vertex
                PickedGeometry pickedGeometry = RunPicking(e.X, e.Y);
                if (pickedGeometry != null)
                {
                    var dragParam = new DragParam(pickedGeometry,
                        camera.GetProjectionMat4(),
                        camera.GetViewMat4(),
                        new Point(e.X, glCanvas1.Height -  e.Y - 1));
                    this.dragParam = dragParam;

                    this.mouseDownBoard.SetContent(string.Format("MouseDown{0}{1}",
                        Environment.NewLine, dragParam));
                }
            }
        }

        private void glCanvas1_MouseMove(object sender, MouseEventArgs e)
        {
            this.mouseMovePosition = new Point(e.X, e.Y);

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                // operate camera
                rotator.MouseMove(e.X, e.Y);
                //this.cameraUpdated = true;
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                // move vertex
                DragParam dragParam = this.dragParam;
                if (this.dragParam != null)
                {
                    var current = new Point(e.X, glCanvas1.Height - e.Y - 1);
                    Point differenceOnScreen = new Point(
                        current.X - dragParam.lastMousePositionOnScreen.X,
                        current.Y - dragParam.lastMousePositionOnScreen.Y);
                    dragParam.lastMousePositionOnScreen = current;
                    this.rendererDict[this.selectedModel].MovePositions(
                        differenceOnScreen,
                        dragParam.viewMatrix, dragParam.projectionMatrix,
                        dragParam.viewport,
                        dragParam.pickedGeometry.Indexes);

                    this.mouseMoveBoard.SetContent(string.Format("MouseMove{0}{1}",
                        Environment.NewLine, dragParam));
                }
                else
                { this.mouseDownBoard.SetContent("Mouse Move: No action."); }
            }
            else
            {
                RunPicking(e.X, e.Y);
            }
        }

        private void glCanvas1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                // operate camera
                rotator.MouseUp(e.X, e.Y);
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                // move vertex
                //this.pickedGeometry = null;
                this.dragParam = null;

                this.mouseDownBoard.SetContent("Mouse Up: No action.");
            }
        }

        uint format = GL.GL_DEPTH_COMPONENT32;//GL.GL_DEPTH_COMPONENT24; // GL.GL_DEPTH_COMPONENT16;// GL.GL_DEPTH_COMPONENT;
        private Point mouseMovePosition;
        private PickedGeometry RunPicking(int x, int y)
        {
            lock (this.synObj)
            {
                {
                    float depth = 0;
                    using (var array = new UnmanagedArray<float>(1))
                    {
                        GL.ReadPixels(x, glCanvas1.Height - y - 1, 1, 1, GL.GL_DEPTH_COMPONENT, GL.GL_FLOAT, array.Header);
                        depth = array[0];
                    }
                    this.glCanvas1_OpenGLDraw(selectedModel, null);
                    Color c = GL.ReadPixel(x, this.glCanvas1.Height - y - 1);
                    c = Color.FromArgb(255, c);
                    this.lblReadColor.BackColor = c;
                    this.lblReadColor.Text = string.Format(
                        "Color at mouse [{0}]: [{1}], depth:[{2}]",
                        new Point(x, this.glCanvas1.Height - y - 1), c, depth);
                }
                {
                    IColorCodedPicking pickable = this.rendererDict[this.SelectedModel];
                    pickable.MVP = this.camera.GetProjectionMat4() * this.camera.GetViewMat4();
                    PickedGeometry pickedGeometry = ColorCodedPicking.Pick(
                        this.camera, x, y, this.glCanvas1.Width, this.glCanvas1.Height, pickable);
                    if (pickedGeometry != null)
                    {
                        this.RunPickingBoard.SetContent(pickedGeometry.ToString(
                            camera.GetProjectionMat4(), camera.GetViewMat4()));
                    }
                    else
                    {
                        this.RunPickingBoard.SetContent("picked nothing.");
                    }

                    return pickedGeometry;
                }
            }
        }

        class DragParam
        {

            public PickedGeometry pickedGeometry;
            public mat4 projectionMatrix;
            public mat4 viewMatrix;
            public Point lastMousePositionOnScreen;
            public vec4 viewport;

            public DragParam(PickedGeometry pickedGeometry, mat4 projectionMatrix, mat4 viewMatrix, Point lastMousePositionOnScreen)
            {
                this.pickedGeometry = pickedGeometry;
                this.projectionMatrix = projectionMatrix;
                this.viewMatrix = viewMatrix;
                this.lastMousePositionOnScreen = lastMousePositionOnScreen;
                var viewport = new int[4]; GL.GetInteger(GetTarget.Viewport, viewport);
                this.viewport = new vec4(viewport[0], viewport[1], viewport[2], viewport[3]);
            }

            public override string ToString()
            {
                return string.Format("Last Mouse Position On Screen: [{0}]", this.lastMousePositionOnScreen);
            }
        }
    }
}
