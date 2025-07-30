using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;

namespace CSharpGL {
    /// <summary>
    /// A smallest unit that can render somthing.
    /// </summary>

    public class IPickableRenderMethod : RenderMethod {

        /// <summary>
        /// Position buffer
        /// </summary>
        public VertexBuffer[] PositionBuffers { get; private set; }

        /// <summary>
        /// A smallest unit that can render somthing.
        /// </summary>
        /// <param name="program"></param>
        /// <param name="vao"></param>
        /// <param name="positionBuffers"></param>
        /// <param name="switches"></param>
        public IPickableRenderMethod(GLProgram program, VertexArrayObject[] vao, VertexBuffer[] positionBuffers, params GLSwitch[] switches)
            : base(program, vao, switches) {
            this.PositionBuffers = positionBuffers;
        }
    }
}
