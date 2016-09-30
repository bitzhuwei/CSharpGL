using System.Drawing;

namespace CSharpGL.Demos
{
    internal class RendererTransporter
    {
        public RendererBase Renderer { get; set; }

        public string Tip { get; set; }

        public Color ClearColor { get; set; }

        public RendererTransporter(RendererBase renderer, string tip, Color clearColor)
        {
            this.Renderer = renderer;
            this.Tip = tip;
            this.ClearColor = clearColor;
        }

        public void Setup(Scene scene)
        {
            scene.ClearColor = this.ClearColor;
        }
    }
}