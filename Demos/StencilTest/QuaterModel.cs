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

        public IEnumerable<VertexBuffer> GetVertexAttributeBuffer(string bufferName)
        {
            throw new Exception("vertex buffer is not needed.");
        }

        public IEnumerable<IDrawCommand> GetDrawCommand()
        {
            if (this.drawCmd == null)
            {
                this.drawCmd = new DrawArraysCmd(DrawMode.Quads, 0, 4);
            }

            yield return this.drawCmd;
        }

        #endregion
    }
}
