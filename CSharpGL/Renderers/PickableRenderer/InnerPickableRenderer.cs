namespace CSharpGL
{
    /// <summary>
    /// Renderer that supports color-coded rendering.
    /// </summary>
    abstract partial class InnerPickableRenderer : Renderer, IColorCodedPicking
    {
        protected string positionNameInIBufferable;
        internal PropertyBufferPtr positionBufferPtr;

        private PolygonModeSwitch polygonModeSwitch = new PolygonModeSwitch(PolygonModes.Filled);

        /// <summary>
        /// Renderer that supports color-coded rendering.
        /// </summary>
        /// <param name="bufferable">model data that can be transfermed into OpenGL Buffer's pointer.</param>
        /// <param name="shaderCodes">All shader codes needed for this renderer.</param>
        /// <param name="propertyNameMap">Mapping relations between 'in' variables in vertex shader in <paramref name="shaderCodes"/> and buffers in <paramref name="bufferable"/>.</param>
        /// <param name="positionNameInIBufferable">Name of buffer that describes model's position.</param>
        ///<param name="switches">OpenGL switches.</param>
        internal InnerPickableRenderer(IBufferable bufferable, ShaderCode[] shaderCodes,
            PropertyNameMap propertyNameMap, string positionNameInIBufferable,
            params GLSwitch[] switches)
            : base(bufferable, shaderCodes, propertyNameMap, switches)
        {
            {
                this.positionNameInIBufferable = positionNameInIBufferable;
            }
            {
                this.switchList.Add(polygonModeSwitch);
            }
            {
                float min, max;
                OpenGL.LineWidthRange(out min, out max);
                this.switchList.Add(new LineWidthSwitch(max));
            }
            {
                float min, max;
                OpenGL.PointSizeRange(out min, out max);
                this.switchList.Add(new PointSizeSwitch(max));
            }
        }
    }
}