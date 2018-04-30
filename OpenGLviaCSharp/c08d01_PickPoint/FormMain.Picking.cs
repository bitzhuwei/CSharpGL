using CSharpGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace c08d01_PickPoint
{
    public partial class FormMain : Form
    {
        private PointsNode pickedNode;

        void winGLCanvas1_MouseMove(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int y = this.winGLCanvas1.Height - e.Y - 1;
            PickedGeometry pickedGeometry = this.pickingAction.Pick(x, y, PickingGeometryTypes.Point, this.winGLCanvas1.Width, this.winGLCanvas1.Height);

            if (pickedGeometry != null)
            {
                this.pickingBoard.SetText(string.Format("CSharpGL - picked: {0}", pickedGeometry));
                var node = pickedGeometry.FromObject as PointsNode;
                if (node != null)
                {
                    node.HighlightIndex = (int)pickedGeometry.StageVertexId;
                    this.pickedNode = node;
                }
            }
            else
            {
                this.pickingBoard.SetText("Picked: nothing.");
                if (this.pickedNode != null)
                {
                    this.pickedNode.HighlightIndex = -1;
                }
            }

        }

    }
}
