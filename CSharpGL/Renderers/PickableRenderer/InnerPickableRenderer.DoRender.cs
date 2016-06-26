
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    partial class InnerPickableRenderer
    {

        protected override void DoRender(RenderEventArg arg)
        {
            if (arg.RenderMode == RenderModes.ColorCodedPicking)
            {
                ColorCodedRender(arg);
            }
            else if (arg.RenderMode == RenderModes.Render)
            {
                base.DoRender(arg);
            }

        }

    }
}
