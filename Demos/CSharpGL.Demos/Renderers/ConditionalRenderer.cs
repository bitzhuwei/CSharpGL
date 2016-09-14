using System.Collections.Generic;

namespace CSharpGL.Demos
{
    /// <summary>
    /// demostrates how to perform conditional rendering.
    /// </summary>
    internal class ConditionalRenderer : RendererBase
    {
        private const int xside = 5, yside = 5, zside = 5;

        private List<Tuple<BoundingBoxRenderer, RendererBase>> coupleList = new List<Tuple<BoundingBoxRenderer, RendererBase>>();

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