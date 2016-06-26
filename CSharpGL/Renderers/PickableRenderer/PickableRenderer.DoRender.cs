
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    public partial class PickableRenderer
    {

        protected override void DoRender(RenderEventArg arg)
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
