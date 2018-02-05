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
        public VertexBuffer[] PositionBuffers { get; private set; }

        /// <summary>
        /// A smallest unit that can render somthing.
        /// </summary>
        /// <param name="program"></param>
        /// <param name="vao"></param>
        /// <param name="positionBuffers"></param>
        /// <param name="switches"></param>
        public IPickableRenderMethod(ShaderProgram program, VertexArrayObject[] vao, VertexBuffer[] positionBuffers, params GLSwitch[] switches)
            : base(program, vao, switches)
        {
            this.PositionBuffers = positionBuffers;
        }
    }
}
