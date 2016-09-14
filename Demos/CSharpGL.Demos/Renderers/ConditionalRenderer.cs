using System.Drawing;
using System.IO;

namespace CSharpGL.Demos
{
    /// <summary>
    /// demostrates how to perform conditional rendering.
    /// </summary>
    internal class ConditionalRenderer : RendererBase
    {

        public static ConditionalRenderer Create()
        {
            throw new System.NotFiniteNumberException();
        }

        private ConditionalRenderer()
        { }

        protected override void DoInitialize()
        {
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            mat4 projection = arg.Camera.GetProjectionMatrix();
            mat4 view = arg.Camera.GetViewMatrix();
        }
    }
}