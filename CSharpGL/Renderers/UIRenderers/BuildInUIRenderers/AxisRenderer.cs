namespace CSharpGL
{
    /// <summary>
    /// Renders an 3D axis.
    /// </summary>
    internal class AxisRenderer : PickableRenderer
    {
        public static AxisRenderer Create(int partCount = 24, float radius = 1.0f)
        {
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(ManifestResourceLoader.LoadTextFile(
@"Resources.Axis.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(ManifestResourceLoader.LoadTextFile(
@"Resources.Axis.frag"), ShaderType.FragmentShader);
            var map = new PropertyNameMap();
            map.Add("in_Position", Axis.strPosition);
            map.Add("in_Color", Axis.strColor);
            var model = new Axis(partCount, radius);
            var renderer = new AxisRenderer(model, shaderCodes, map, "position");
            return renderer;
        }

        private AxisRenderer(IBufferable bufferable, ShaderCode[] shaderCodes,
            PropertyNameMap propertyNameMap, string positionNameInIBufferable, params GLSwitch[] switches)
            : base(bufferable, shaderCodes, propertyNameMap, positionNameInIBufferable, switches)
        { }
    }
}