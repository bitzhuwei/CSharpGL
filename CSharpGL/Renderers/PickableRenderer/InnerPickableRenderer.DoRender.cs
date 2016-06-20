
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    partial class InnerPickableRenderer
    {

        protected override void DoRender(RenderEventArgs arg)
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
