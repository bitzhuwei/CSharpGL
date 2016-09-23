using System;

namespace CSharpGL
{
    public partial class SceneObject
    {
        /// <summary>
        /// Occurs before this object and all of its children's rendering.
        /// </summary>
        public event EventHandler BeforeRendering;

        /// <summary>
        ///
        /// </summary>
        /// <param name="arg"></param>
        public void Render(RenderEventArgs arg)
        {
            //RendererComponent renderer = this.RendererComponent;
            RendererBase renderer = this.Renderer;
            if (renderer != null)
            {
                renderer.Render(arg);
            }
        }

        /// <summary>
        /// Occurs after this object and all of its children's rendering.
        /// </summary>
        public event EventHandler AfterRendering;
    }
}