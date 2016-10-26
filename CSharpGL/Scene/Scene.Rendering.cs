using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace CSharpGL
{
    public partial class Scene
    {
        private object synObj = new object();

        /// <summary>
        /// Render this scene.
        /// </summary>
        /// <param name="pickingGeometryType">Specify type of primitive you want to pick or nothing to pick.</param>
        public void Render(
            PickingGeometryType pickingGeometryType = PickingGeometryType.None)
        {
            lock (this.synObj)
            {
                // update view port's location and size.
                this.rootViewPort.Layout();
                // render root view port.
                vec4 color = this.rootViewPort.ClearColor.ToVec4();
                OpenGL.glClearColor(color.x, color.y, color.z, color.w);
                OpenGL.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT | OpenGL.GL_STENCIL_BUFFER_BIT);
                // render scene in every view port.
                this.RenderViewPort(this.rootViewPort, this.Canvas.ClientRectangle, pickingGeometryType);
            }
        }

        /// <summary>
        /// render scene in every view port.
        /// </summary>
        /// <param name="viewPort"></param>
        /// <param name="clientRectangle"></param>
        /// <param name="pickingGeometryType"></param>
        private void RenderViewPort(ViewPort viewPort, Rectangle clientRectangle, PickingGeometryType pickingGeometryType)
        {
            if (viewPort.Enabled)
            {
                // render in this view port.
                if (viewPort.Visiable)
                {
                    // render scene in this view port.
                    viewPort.Render(this, clientRectangle, pickingGeometryType);
                }

                // render children viewport.
                foreach (ViewPort item in viewPort.Children)
                {
                    this.RenderViewPort(item, clientRectangle, pickingGeometryType);
                }
            }
        }
    }
}