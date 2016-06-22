using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    public partial class PickableRenderer
    {

        protected override void DisposeUnmanagedResources()
        {
            // dispose picking resources
            InnerPickableRenderer renderer = this.innerPickableRenderer;
            renderer.Dispose();

            base.DisposeUnmanagedResources();
        }

    }
}
