using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public partial class PickableRenderer
    {
        protected override void DoInitialize()
        {
            base.DoInitialize();

            this.innerPickableRenderer.Initialize();
        }
    }
}
