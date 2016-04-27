using GLM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public partial class PickableModernRenderer
    {

        protected override void DisposeUnmanagedResources()
        {
            // dispose picking resources
            if (this.vertexArrayObject4Picking != null)
            {
                this.vertexArrayObject4Picking.Dispose();
                this.vertexArrayObject4Picking = null;
            }
            if (this.positionBufferPtr != null)
            {
                this.positionBufferPtr = null;// will be disposed in propertyBufferPtrs
            }
            if (this.pickingShaderProgram != null)
            {
                this.pickingShaderProgram.Delete();
                this.pickingShaderProgram = null;
            }

            base.DisposeUnmanagedResources();
        }

    }
}
