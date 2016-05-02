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
        private Point lastMousePosition;

        private void glCanvas1_MouseDown(object sender, MouseEventArgs e)
        {
            this.lastMousePosition = new Point(e.X, e.Y);

            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                // operate camera
                rotator.SetBounds(this.glCanvas1.Width, this.glCanvas1.Height);
                rotator.MouseDown(e.X, e.Y);
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                // move vertex
                UpdateColorInformationAtMouse(e.X, e.Y);

                PickedGeometry pickedGeometry = RunPicking(
                    new RenderEventArgs(
                        RenderModes.ColorCodedPicking,
                        this.glCanvas1.ClientRectangle,
                        this.camera, this.PickingGeometryType),
                    e.X, e.Y);
                if (pickedGeometry != null)
                {
                    this.rendererDict[this.selectedModel].Highlighter.SetHighlightIndexes(
                        this.PickingGeometryType.ToDrawMode(),
                        pickedGeometry.Indexes);
                    var dragParam = new DragParam(
                        camera.GetProjectionMat4(),
                        camera.GetViewMat4(),
                        new Point(e.X, glCanvas1.Height - e.Y - 1));
                    if (this.rendererDict[this.selectedModel].PickableRenderer.Mode == DrawMode.QuadStrip)
                    { dragParam.pickedIndexes.AddRange(pickedGeometry.Indexes.Swap4QuadStrip()); }
                    else
                    { dragParam.pickedIndexes.AddRange(pickedGeometry.Indexes); }
                    this.dragParam = dragParam;
                }

                this.pickedGeometry = pickedGeometry;
            }
        }

        private void glCanvas1_MouseMove(object sender, MouseEventArgs e)
        {
            if (lastMousePosition.X == e.X && lastMousePosition.Y == e.Y) { return; }

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
                UpdateColorInformationAtMouse(e.X, e.Y);

                PickedGeometry pickedGeometry = RunPicking(
                    new RenderEventArgs(
                        RenderModes.ColorCodedPicking,
                        this.glCanvas1.ClientRectangle,
                        this.camera, this.PickingGeometryType),
                    e.X, e.Y);
                if (pickedGeometry != null)
                {
                    uint[] indexes = null;
                    if (this.rendererDict[this.selectedModel].PickableRenderer.Mode == DrawMode.QuadStrip)
                    { indexes = pickedGeometry.Indexes.Swap4QuadStrip().ToArray(); }
                    else
                    { indexes = pickedGeometry.Indexes; }
                    this.rendererDict[this.selectedModel].Highlighter.SetHighlightIndexes(
                        this.PickingGeometryType.ToDrawMode(),
                        indexes);
                }
                else
                {
                    this.rendererDict[this.selectedModel].Highlighter.ClearHighlightIndexes();
                }

                this.pickedGeometry = pickedGeometry;
            }

            this.lastMousePosition = new Point(e.X, e.Y);
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

            UpdateColorInformationAtMouse(e.X, e.Y);

            this.lastMousePosition = new Point(e.X, e.Y);
        }

        private void UpdateColorInformationAtMouse(int x, int y)
        {
            this.RenderersDraw(this.renderMode, true, false);
            Color c = GL.ReadPixel(x, this.glCanvas1.Height - y - 1);
            c = Color.FromArgb(255, c);
            this.lblColor.BackColor = c;
            this.lblReadColor.Text = string.Format(
                "{0} @ {1}", c,
                new Point(x, this.glCanvas1.Height - y - 1));
        }

        private PickedGeometry RunPicking(RenderEventArgs arg, int x, int y)
        {
            lock (this.synObj)
            {
                // prepare pickable elements
                PickableModernRenderer pickable = this.rendererDict[this.SelectedModel].PickableRenderer;
                pickable.MVP = this.camera.GetProjectionMat4() * this.camera.GetViewMat4();

                PickedGeometry pickedGeometry = ColorCodedPicking.Pick(
                    arg, x, y, 
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

        public GeometryType PickingGeometryType { get; set; }
    }
}
