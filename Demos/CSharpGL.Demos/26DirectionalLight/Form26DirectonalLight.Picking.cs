using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CSharpGL.Demos
{
    public partial class Form26DirectionalLight
    {
        private PickedGeometry pickedGeometry;
        private DragParam dragParam;
        private Point lastMousePosition;
        private Point lastMouseDownPosition;
        public PickingGeometryType PickingGeometryType { get; set; }

        private void glCanvas1_MouseDown(object sender, MouseEventArgs e)
        {
            this.lastMousePosition = e.Location;
            this.lastMouseDownPosition = e.Location;

            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                //// operate camera
                //rotator.SetBounds(this.glCanvas1.Width, this.glCanvas1.Height);
                //rotator.MouseDown(e.X, e.Y);
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                // move vertex
                if (pickedGeometry != null)
                {
                    ViewPort viewPort = pickedGeometry.FromViewPort;
                    ICamera camera = viewPort.Camera;
                    var dragParam = new DragParam(
                        camera.GetPerspectiveProjectionMatrix(),
                        camera.GetViewMatrix(),
                        viewPort.Rect.ToViewport(),
                        new Point(e.X, glCanvas1.Height - e.Y - 1));
                    dragParam.pickedVertexIds.AddRange(pickedGeometry.VertexIds);
                    this.dragParam = dragParam;
                }
            }
        }

        private void glCanvas1_MouseMove(object sender, MouseEventArgs e)
        {
            if (lastMousePosition == e.Location) { return; }

            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                //// operate camera
                //rotator.MouseMove(e.X, e.Y);
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
                    PickableRenderer renderer = null;
                    {
                        var tmp = this.pickedGeometry.FromRenderer as HighlightedPickableRenderer;
                        if (tmp != null) { renderer = tmp.PickableRenderer; }
                    }

                    if (renderer == null) { renderer = this.pickedGeometry.FromRenderer as PickableRenderer; }

                    renderer.MovePositions(
                        differenceOnScreen,
                        dragParam.viewMatrix, dragParam.projectionMatrix,
                        dragParam.viewport,
                        dragParam.pickedVertexIds);
                }
            }

            this.lastMousePosition = e.Location;
        }

        private void glCanvas1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                //// operate camera
                //rotator.MouseUp(e.X, e.Y);
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.dragParam = null;
            }

            this.lastMousePosition = e.Location;
        }

    }
}