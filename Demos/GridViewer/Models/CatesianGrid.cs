using CSharpGL;
using SimLab.GridSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridViewer
{
    public partial class CatesianGrid : IBufferable
    {
        private CatesianGridderSource dataSource;

        public CatesianGrid(CatesianGridderSource dataSource)
        {
            this.dataSource = dataSource;
        }

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
