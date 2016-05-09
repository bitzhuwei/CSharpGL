using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public abstract partial class Renderer
    {
        protected override void DisposeUnmanagedResources()
        {
            if (this.vertexArrayObject != null)
            {
                this.vertexArrayObject.Dispose();
                //this.vertexArrayObject = null;
            }
            if (this.propertyBufferPtrs != null)
            {
                foreach (var item in this.propertyBufferPtrs) { item.Dispose(); }
                this.propertyBufferPtrs = null;
            }
            if (this.GetIndexBufferPtr() != null)
            {
                this.GetIndexBufferPtr().Dispose();
            }
            if (this.shaderProgram != null)
            {
                this.shaderProgram.Delete();
                this.shaderProgram = null;
            }
        }
    }
}
