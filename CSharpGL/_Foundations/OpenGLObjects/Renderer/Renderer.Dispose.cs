using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    public partial class Renderer
    {
        /// <summary>
        /// 
        /// </summary>
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
            if (this.Program != null)
            {
                this.Program.Delete();
            }
        }
    }
}
