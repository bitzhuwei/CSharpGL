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
        private Point lastMousePosition;
        private PickingGeometryType pickingGeometryType = PickingGeometryType.Triangle;

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
            }
            else
            {
                TryPicking(e);
            }

            this.lastMousePosition = e.Location;
        }

        private void TryPicking(MouseEventArgs e)
        {
            List<Tuple<Point, PickedGeometry>> allPickedGeometrys = this.scene.Pick(
              e.Location, pickingGeometryType);
            PickedGeometry geometry = null;
            if (allPickedGeometrys != null && allPickedGeometrys.Count > 0)
            { geometry = allPickedGeometrys[0].Item2; }

            if (geometry != null)
            {
                var renderer = geometry.FromRenderer as RendererBase;
                if (renderer != null)
                {
                    var script = renderer.BindingSceneObject.GetScript<PickingScript>();
                    if (script != null)
                    {
                        script.Bind();
                    }
                }

                this.glCanvas1.Cursor = Cursors.Hand;
            }
            else
            {
                if (this.pickedGeometry != null)
                {
                    var renderer = this.pickedGeometry.FromRenderer as RendererBase;
                    if (renderer != null)
                    {
                        var script = renderer.BindingSceneObject.GetScript<PickingScript>();
                        if (script != null)
                        {
                            script.Unbind();
                        }
                    }
                }
                this.glCanvas1.Cursor = Cursors.Default;
            }

            this.pickedGeometry = geometry;
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

            }

            if (pickedGeometry != null)
            {
                var renderer = this.pickedGeometry.FromRenderer as RendererBase;
                if (renderer != null)
                {
                    var script = renderer.BindingSceneObject.GetScript<PickingScript>();
                    if (script != null)
                    {
                        script.Unbind();
                    }
                }
            }

            this.lastMousePosition = e.Location;
        }

    }
}