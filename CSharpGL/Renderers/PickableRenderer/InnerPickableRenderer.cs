using System;
using System.ComponentModel;

namespace CSharpGL
{
    /// <summary>
    /// Renderer that supports color-coded rendering.
    /// </summary>
    abstract partial class InnerPickableRenderer : Renderer, IPickable
    {
        /// <summary>
        ///
        /// </summary>
        public string PositionNameInIBufferable { get; private set; }

        /// <summary>
        /// Position buffer pointer.
        /// </summary>
        [Browsable(false)]
        internal VertexBuffer PositionBuffer
        {
            get
            {
                VertexBuffer[] pointers = this.vertexAttributeBuffers;
                if (pointers == null || pointers.Length < 0)
                {
                    throw new Exception("Vertex attribute buffers are not readly!");
                }

                return pointers[0];
            }
        }

        private PolygonModeState polygonModeState = new PolygonModeState(PolygonMode.Fill);

        /// <summary>
        /// Renderer that supports color-coded rendering.
        /// </summary>
        /// <param name="model">model data that can be transfermed into OpenGL Buffer's pointer.</param>
        /// <param name="shaderCodes">All shader codes needed for this renderer.</param>
        /// <param name="attributeMap">Mapping relations between 'in' variables in vertex shader in <paramref name="shaderCodes"/> and buffers in <paramref name="model"/>.</param>
        /// <param name="positionNameInIBufferable">Name of buffer that describes model's position.</param>
        ///<param name="switches">OpenGL switches.</param>
        internal InnerPickableRenderer(IBufferable model, ShaderCode[] shaderCodes,
            AttributeMap attributeMap, string positionNameInIBufferable,
            params GLState[] switches)
            : base(model, shaderCodes, attributeMap, switches)
        {
            this.PositionNameInIBufferable = positionNameInIBufferable;
            this.stateList.Add(polygonModeState);
            {
                float min, max;
                OpenGL.LineWidthRange(out min, out max);
                this.stateList.Add(new LineWidthState(max));
            }
            {
                float min, max;
                OpenGL.PointSizeRange(out min, out max);
                this.stateList.Add(new PointSizeState(max));
            }
        }
    }
}