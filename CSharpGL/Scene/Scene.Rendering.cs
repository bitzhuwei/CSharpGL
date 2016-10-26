using System.Drawing;

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