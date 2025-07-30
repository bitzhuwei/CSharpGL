using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace TessellatedTriangle {
    class TrianglePatchModel : IBufferSource {
        private IDrawCommand drawCommand;

        #region IBufferSource 成员

        public IEnumerable<VertexBuffer> GetVertexAttribute(string bufferName) {
            {
                throw new ArgumentException("bufferName");
            }
        }

        public IEnumerable<IDrawCommand> GetDrawCommand() {
            if (this.drawCommand == null) {
                this.drawCommand = new DrawArraysCmd(CSharpGL.DrawMode.Patches, 3);
            }

            yield return this.drawCommand;
        }

        #endregion
    }
}
