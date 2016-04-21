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

        protected override void DisposeUnmanagedResources()
        {
            if (this.vertexArrayObject != null)
            {
                this.vertexArrayObject.Dispose();
                this.vertexArrayObject = null;
            }
            if (this.propertyBufferPtrs != null)
            {
                foreach (var item in this.propertyBufferPtrs) { item.Dispose(); }
                this.propertyBufferPtrs = null;
            }
            if (this.indexBufferPtr != null)
            {
                this.indexBufferPtr.Dispose();
                this.indexBufferPtr = null;
            }
            if (this.shaderProgram != null)
            {
                this.shaderProgram.Delete();
                this.shaderProgram = null;
            }
            // dispose picking resources
            if (this.vertexArrayObject4Picking != null)
            {
                this.vertexArrayObject4Picking.Dispose();
                this.vertexArrayObject4Picking = null;
            }
            if (this.positionBufferPtr != null)
            {
                this.positionBufferPtr = null;// already disposed in propertyBufferPtrs
            }
            if (this.pickingShaderProgram != null)
            {
                this.pickingShaderProgram.Delete();
                this.pickingShaderProgram = null;
            }

        }

    }
}
