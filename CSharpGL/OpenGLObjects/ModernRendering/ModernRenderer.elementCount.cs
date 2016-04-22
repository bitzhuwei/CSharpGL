using GLM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public partial class ModernRenderer 
    {
        private int elementCount;

        private void InitializeElementCount()
        {
            {
                var indexBufferPtr = this.indexBufferPtr as OneIndexBufferPtr;
                if (indexBufferPtr != null)
                {
                    this.elementCount = indexBufferPtr.ElementCount;
                    return;
                }
            }
            {
                var indexBufferPtr = this.indexBufferPtr as ZeroIndexBufferPtr;
                if (indexBufferPtr != null)
                {
                    this.elementCount = indexBufferPtr.VertexCount;
                    return;
                }
            }
        }

    }
}
