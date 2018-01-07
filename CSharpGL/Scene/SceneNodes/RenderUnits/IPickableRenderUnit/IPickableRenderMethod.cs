using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// A smallest unit that can render somthing.
    /// </summary>
    [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
    public class IPickableRenderMethod : RenderMethod
    {
        private const string strIPickableRenderMethod = "IPickableRenderMethod";

        /// <summary>
        /// 
        /// </summary>
        [Category(strIPickableRenderMethod)]
        [Description("Position buffer.")]
        public VertexBuffer[] PositionBuffer { get; private set; }

        /// <summary>
        /// A smallest unit that can render somthing.
        /// </summary>
        /// <param name="program"></param>
        /// <param name="vao"></param>
        /// <param name="positionBuffer"></param>
        /// <param name="states"></param>
        public IPickableRenderMethod(ShaderProgram program, VertexArrayObject[] vao, VertexBuffer[] positionBuffer, params GLState[] states)
            : base(program, vao, states)
        {
            this.PositionBuffer = positionBuffer;
        }
    }
}
