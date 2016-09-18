namespace CSharpGL.Demos
{
    /// <summary>
    /// This demo uses shade from [webgl-noise](https://github.com/ashima/webgl-noise)
    /// sunColor.grd是photoshop使用的渐变色定义。
    /// </summary>
    [DemoRenderer]
    partial class ShaderToyRenderer : Renderer
    {
        public ShaderToyRenderer()
            : base(staticBufferable, staticShaderCodes, staticPropertyNameMap) { }
    }
}