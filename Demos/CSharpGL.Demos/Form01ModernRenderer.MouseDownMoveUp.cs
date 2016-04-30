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
    public partial class Form01ModernRenderer
    {

        private void glCanvas1_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void glCanvas1_KeyUp(object sender, KeyEventArgs e)
        {
        }

        PickedGeometry pickedGeometry;
        private DragParam dragParam;
        private Point mousePosition;

        private void glCanvas1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                // operate camera
                rotator.SetBounds(this.glCanvas1.Width, this.glCanvas1.Height);
                rotator.MouseDown(e.X, e.Y);
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                // move vertex
                PickedGeometry pickedGeometry = RunPicking(new RenderEventArgs(
                    RenderModes.ColorCodedPicking,
                    this.camera), e.X, e.Y);
                if (pickedGeometry != null)
                {
                    this.rendererDict[this.selectedModel].Highlighter.SetHighlightIndexes(
                        this.PickingMode == SelectionMode.DrawMode ?
                            this.rendererDict[this.selectedModel].PickableRenderer.Mode : DrawMode.Points,
                        pickedGeometry.Indexes);
                    var dragParam = new DragParam(
                        camera.GetProjectionMat4(),
                        camera.GetViewMat4(),
                        new Point(e.X, glCanvas1.Height - e.Y - 1),
                        pickedGeometry.Indexes);
                    this.dragParam = dragParam;
                }

                this.pickedGeometry = pickedGeometry;
            }
        }

        private void glCanvas1_MouseMove(object sender, MouseEventArgs e)
        {
            this.mousePosition = new Point(e.X, e.Y);

            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                // operate camera
                rotator.MouseMove(e.X, e.Y);
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                // move vertex
                DragParam dragParam = this.dragParam;
                if (dragParam != null)
                {
                    var current = new Point(e.X, glCanvas1.Height - e.Y - 1);
                    Point differenceOnScreen = new Point(
                        current.X - dragParam.lastMousePositionOnScreen.X,
                        current.Y - dragParam.lastMousePositionOnScreen.Y);
                    dragParam.lastMousePositionOnScreen = current;
                    this.rendererDict[this.selectedModel].PickableRenderer.MovePositions(
                        differenceOnScreen,
                        dragParam.viewMatrix, dragParam.projectionMatrix,
                        dragParam.viewport,
                        dragParam.pickedIndexes);
                }
            }
            else
            {
                PickedGeometry pickedGeometry = RunPicking(new RenderEventArgs(
                    RenderModes.ColorCodedPicking,
                    this.camera), e.X, e.Y);
                if (pickedGeometry != null)
                {
                    this.rendererDict[this.selectedModel].Highlighter.SetHighlightIndexes(
                        this.PickingMode == SelectionMode.DrawMode ?
                            this.rendererDict[this.selectedModel].PickableRenderer.Mode : DrawMode.Points,
                        pickedGeometry.Indexes.ToArray());
                }
                else
                {
                    this.rendererDict[this.selectedModel].Highlighter.ClearHighlightIndexes();
                }

                this.pickedGeometry = pickedGeometry;
            }
        }

        private void glCanvas1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                // operate camera
                rotator.MouseUp(e.X, e.Y);
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                // move vertex
                this.dragParam = null;
                this.rendererDict[this.selectedModel].Highlighter.ClearHighlightIndexes();
            }
        }

        private PickedGeometry RunPicking(RenderEventArgs e, int x, int y)
        {
            lock (this.synObj)
            {
                {
                    this.RenderersDraw();
                    Color c = GL.ReadPixel(x, this.glCanvas1.Height - y - 1);
                    c = Color.FromArgb(255, c);
                    this.lblColor.BackColor = c;
                    this.lblReadColor.Text = string.Format(
                        "{0} @ {1}", c,
                        new Point(x, this.glCanvas1.Height - y - 1));
                }
                {
                    IColorCodedPicking pickable = this.rendererDict[this.SelectedModel].PickableRenderer;
                    pickable.MVP = this.camera.GetProjectionMat4() * this.camera.GetViewMat4();
                    PickedGeometry pickedGeometry = ColorCodedPicking.Pick(
                        e, x, y, this.glCanvas1.Width, this.glCanvas1.Height,
                        pickable);
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

        public SelectionMode PickingMode { get; set; }
    }
}
