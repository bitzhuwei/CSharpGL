using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace CSharpGL.Demos
{
    public partial class Form18PickingInScene
    {

        void glCanvas1_MouseMove(object sender, MouseEventArgs e)
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
                    new RenderEventArgs(RenderModes.ColorCodedPicking, (sender as Control).ClientRectangle, this.scene.Camera, GeometryType.Point),
                    e.X, e.Y, list.ToArray());
            if (result != null)
            {
                foreach (var item in this.scene.RootObject)
                {
                    if (item.Renderer == result.From)
                    {
                        var script = item.GetScript<UpdatingBoxScript>();
                        script.UpdateBoundingBox();
                    }
                }
            }
        }
    }
}