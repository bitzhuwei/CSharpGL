
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public partial class PickableRenderer
    {

        protected override void DoRender(RenderEventArgs arg)
        {
            if (arg.RenderMode == RenderModes.ColorCodedPicking)
            {
                this.innerPickableRenderer.Render(arg);
            }
            else// if (arg.RenderMode == RenderModes.Render)
            {
                base.DoRender(arg);
            }

        }

    }
}
