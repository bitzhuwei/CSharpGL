namespace CSharpGL.Demos
{
    [DemoRenderer]
    partial class ShaderToyRenderer : Renderer
    {
        public ShaderToyRenderer()
            : base(staticBufferable, staticShaderCodes, staticPropertyNameMap) { }
    }
}