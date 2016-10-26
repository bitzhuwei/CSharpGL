using System.ComponentModel;

namespace CSharpGL
{
    /// <summary>
    /// Root view port that should never take part in rendering.
    /// </summary>
    public partial class SceneRootViewPort : ViewPort
    {
        /// <summary>
        /// Root view port that should never take part in rendering.
        /// </summary>
        /// <param name="anchor"></param>
        /// <param name="margin"></param>
        /// <param name="size"></param>
        public SceneRootViewPort(
            System.Windows.Forms.AnchorStyles anchor, System.Windows.Forms.Padding margin,
            System.Drawing.Size size)
            : base(null, anchor, margin, size)
        {
        }

        /// <summary>
        /// render scene in this view port.
        /// </summary>
        /// <param name="scene"></param>
        /// <param name="clientRectangle"></param>
        /// <param name="pickingGeometryType"></param>
        public override void Render(Scene scene, System.Drawing.Rectangle clientRectangle, PickingGeometryType pickingGeometryType)
        {
            this.On();// limit rendering area.

            vec4 color = this.ClearColor.ToVec4();
            OpenGL.glClearColor(color.x, color.y, color.z, color.w);

            OpenGL.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT | OpenGL.GL_STENCIL_BUFFER_BIT);

            this.Off();// cancel limitation.
        }
    }
}