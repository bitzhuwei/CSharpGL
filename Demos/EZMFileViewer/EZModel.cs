using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EZMFileViewer
{
    class EZModel : IBufferSource
    {
        private EZMFile ezmFile;
        public EZModel(EZMFile file)
        {
            this.ezmFile = file;
        }

        #region IBufferSource 成员

        public IEnumerable<VertexBuffer> GetVertexAttribute(string bufferName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IDrawCommand> GetDrawCommand()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
