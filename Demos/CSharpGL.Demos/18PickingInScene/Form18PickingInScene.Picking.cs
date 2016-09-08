using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CSharpGL.Demos
{
    public partial class Form18PickingInScene
    {
        private PickedGeometry pickedGeometry;
        private DragParam dragParam;
        private Point lastMousePosition;

        private void glCanvas1_MouseDown(object sender, MouseEventArgs e)
        {
            this.lastMousePosition = e.Location;

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
                    var dragParam = new DragParam(
                        this.scene.Camera.GetProjectionMatrix(),
                        this.scene.Camera.GetViewMatrix(),
                        new Point(e.X, glCanvas1.Height - e.Y - 1));
                    dragParam.pickedIndexes.AddRange(pickedGeometry.Indexes);
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
                    (this.pickedGeometry.From as PickableRenderer).MovePositions(
                        differenceOnScreen,
                        dragParam.viewMatrix, dragParam.projectionMatrix,
                        dragParam.viewport,
                        dragParam.pickedIndexes);
                }
            }
            else
            {
                PickedGeometry pickedGeometry = RunPicking(
                    new RenderEventArgs(
                        RenderModes.ColorCodedPicking,
                        this.glCanvas1.ClientRectangle,
                        this.scene.Camera, this.PickingGeometryType),
                    e.X, e.Y);

                if (pickedGeometry != null)
                {
                    this.glCanvas1.Cursor = Cursors.Hand;
                }
                else
                {
                    this.glCanvas1.Cursor = Cursors.Default;
                }
                this.pickedGeometry = pickedGeometry;
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
                // move vertex
                this.dragParam = null;
            }

            this.lastMousePosition = e.Location;
        }

        private PickedGeometry RunPicking(RenderEventArgs arg, int x, int y)
        {
            lock (this.synObj)
            {
                var list = new List<PickableRenderer>();
                foreach (var item in this.scene.RootObject)
                {
                    var renderer = item.Renderer as PickableRenderer;
                    if (renderer != null)
                    {
                        list.Add(renderer);
                    }
                }
                PickedGeometry result = ColorCodedPicking.Pick(
                        new RenderEventArgs(RenderModes.ColorCodedPicking, this.glCanvas1.ClientRectangle, this.scene.Camera, GeometryType.Point),
                        x, y, list.ToArray());
                return result;
            }
        }

        private object synObj = new object();

        public GeometryType PickingGeometryType { get; set; }
    }
}