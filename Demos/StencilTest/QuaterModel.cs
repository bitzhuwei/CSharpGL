using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace StencilTest
{
    /// <summary>
    /// Displays on quater of canvas.
    /// </summary>
    class QuaterModel : IBufferSource
    {
        private IDrawCommand drawCmd;

        #region IBufferSource 成员

        public VertexBuffer GetVertexAttributeBuffer(string bufferName)
        {
            throw new Exception("vertex buffer is not needed.");
        }

        public IDrawCommand GetDrawCommand()
        {
            if (this.drawCmd == null)
            {
                this.drawCmd = new DrawArraysCmd(DrawMode.Quads, 0, 4);
            }

            return this.drawCmd;
        }

        #endregion
    }
}
