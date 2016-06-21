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
            if (bufferName == strPosition)
            {
                if (this.propertyBufferPtr == null)
                {
                    this.propertyBufferPtr = this.GetPositionBufferPtr(varNameInShader);
                }
                return this.propertyBufferPtr;
            }
            else if (bufferName == strColor)
            {
                if (this.colorBufferPtr == null)
                {
                    this.colorBufferPtr = this.GetColorBufferPtr(varNameInShader);
                }
                return this.colorBufferPtr;
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public IndexBufferPtr GetIndex()
        {
            if (this.indexBufferPtr == null)
            {
                this.indexBufferPtr = this.GetIndexBufferPtr();
            }

            return this.indexBufferPtr;
        }

    }
}
