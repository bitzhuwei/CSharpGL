using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public partial class Renderer
    {
        protected override void DisposeUnmanagedResources()
        {
            if (this.vertexArrayObject != null)
            {
                this.vertexArrayObject.Dispose();
            }
            if (this.propertyBufferPtrs != null)
            {
                foreach (var item in this.propertyBufferPtrs) { item.Dispose(); }
            }
            if (this.indexBufferPtr != null)
            {
                this.indexBufferPtr.Dispose();
            }
            if (this.shaderProgram != null)
            {
                this.shaderProgram.Delete();
            }
        }
    }
}
