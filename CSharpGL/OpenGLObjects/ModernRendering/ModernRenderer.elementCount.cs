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

        public void DecreaseVertexCount()
        {
            {
                var indexBufferPtr = this.indexBufferPtr as OneIndexBufferPtr;
                if (indexBufferPtr != null)
                {
                    if (indexBufferPtr.ElementCount > 0)
                    {
                        indexBufferPtr.ElementCount--;
                    }
                    return;
                }
            }
            {
                var indexBufferPtr = this.indexBufferPtr as ZeroIndexBufferPtr;
                if (indexBufferPtr != null)
                {
                    if (indexBufferPtr.VertexCount > 0)
                    {
                        indexBufferPtr.VertexCount--;
                    }
                    return;
                }
            }
        }

        public void IncreaseVertexCount()
        {
            {
                var indexBufferPtr = this.indexBufferPtr as OneIndexBufferPtr;
                if (indexBufferPtr != null)
                {
                    if (indexBufferPtr.ElementCount < this.elementCount)
                    {
                        indexBufferPtr.ElementCount++;
                    }
                    return;
                }
            }
            {
                var indexBufferPtr = this.indexBufferPtr as ZeroIndexBufferPtr;
                if (indexBufferPtr != null)
                {
                    if (indexBufferPtr.VertexCount < this.elementCount)
                    {
                        indexBufferPtr.VertexCount++;
                    }
                    return;
                }
            }
        }

    }
}
