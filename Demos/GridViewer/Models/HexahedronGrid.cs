using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridViewer.Models
{
    class HexahedronGrid : IBufferable
    {
        public PropertyBufferPtr GetProperty(string bufferName, string varNameInShader)
        {
            throw new NotImplementedException();
        }

        public IndexBufferPtr GetIndex()
        {
            throw new NotImplementedException();
        }
    }
}
