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
        /// Occurs before this object and all of its children's rendering.
        /// </summary>
        internal void DoBeforeRendering()
        {
            EventHandler handler = this.BeforeRendering;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }

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

        /// <summary>
        /// Occurs after this object and all of its children's rendering.
        /// </summary>
        internal void DoAfterRendering()
        {
            EventHandler handler = this.AfterRendering;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }
    }
}