using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace DeferredShading
{
    class FullScreenModel : IBufferSource
    {
        private IDrawCommand drawCmd;

        #region IBufferSource 成员

        public VertexBuffer GetVertexAttributeBuffer(string bufferName)
        {
            // no vertex attribute needed.
            throw new ArgumentException();
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
