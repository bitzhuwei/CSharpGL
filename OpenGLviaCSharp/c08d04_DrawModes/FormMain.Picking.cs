using CSharpGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace c08d04_DrawModes
{
    public partial class FormMain : Form
    {
        //private LegacyTriangleNode triangleTip;

        void winGLCanvas1_MouseMove(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int y = this.winGLCanvas1.Height - e.Y - 1;
            var builder = new StringBuilder();
            {
                var array = new Pixel[1];
                GCHandle pinned = GCHandle.Alloc(array, GCHandleType.Pinned);
                IntPtr header = pinned.AddrOfPinnedObject();
                // same result with: IntPtr header = Marshal.UnsafeAddrOfPinnedArrayElement(array, 0);
                // get coded color.
                GL.Instance.ReadPixels(x, y, 1, 1, GL.GL_RGBA, GL.GL_UNSIGNED_BYTE, header);
                pinned.Free();
                builder.AppendFormat("Color at Mouse: vec4({0})", array[0]);
                builder.AppendLine();
            }
            {
                PickedGeometry pickedGeometry = this.pickingAction.Pick(x, y, GeometryType.Point, this.winGLCanvas1.Width, this.winGLCanvas1.Height);

                if (pickedGeometry != null)
                {
                    builder.AppendFormat("CSharpGL - picked: {0}", pickedGeometry);
                    builder.AppendLine();
                }
                else
                {
                    builder.AppendFormat("Picked: nothing.");
                    builder.AppendLine();
                }

                this.UpdateHightlight(pickedGeometry);
            }

            this.textBox1.Text = builder.ToString();
        }

        private void UpdateHightlight(PickedGeometry pickedGeometry)
        {
            //if (pickedGeometry != null)
            //{
            //    triangleTip.Vertex0 = pickedGeometry.Positions[0];
            //    triangleTip.Vertex1 = pickedGeometry.Positions[1];
            //    triangleTip.Vertex2 = pickedGeometry.Positions[2];
            //    triangleTip.Parent = pickedGeometry.FromObject as SceneNodeBase;
            //}
            //else
            //{
            //    triangleTip.Parent = null;
            //}
        }
    }
}
