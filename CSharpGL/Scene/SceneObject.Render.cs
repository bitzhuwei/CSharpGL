namespace CSharpGL
{
    public partial class SceneObject
    {
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
    }
}