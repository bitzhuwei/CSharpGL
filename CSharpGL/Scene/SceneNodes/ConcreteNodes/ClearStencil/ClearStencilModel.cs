using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace CSharpGL
{
    /// <summary>
    /// Displays on quater of canvas.
    /// </summary>
    class ClearStencilModel : IBufferSource
    {
        private IDrawCommand drawCmd;

        #region IBufferSource 成员

        public IEnumerable<VertexBuffer> GetVertexAttribute(string bufferName)
        {
            throw new Exception("vertex buffer is not needed.");
        }

        public IEnumerable<IDrawCommand> GetDrawCommand()
        {
            if (this.drawCmd == null)
            {
                this.drawCmd = new DrawArraysCmd(DrawMode.Quads, 4);
            }

            yield return this.drawCmd;
        }

        #endregion
    }
}
