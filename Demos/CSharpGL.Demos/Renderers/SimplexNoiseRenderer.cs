namespace CSharpGL.Demos
{
    [DemoRenderer]
    partial class SimplexNoiseRenderer : Renderer
    {
        public SimplexNoiseRenderer()
            : base(staticBufferable, staticShaderCodes, staticPropertyNameMap) { }
    }
}