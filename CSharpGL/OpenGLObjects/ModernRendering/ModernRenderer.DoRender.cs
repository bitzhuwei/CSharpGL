using GLM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public partial class ModernRenderer : RendererBase
    {

        protected override void DoRender(RenderEventArgs e)
        {
            if (e.RenderMode == RenderModes.ColorCodedPicking)
            {
                PickingRender(e);
            }
            else if (e.RenderMode == RenderModes.Render)
            {
                RenderRender(e);
            }

        }

    }
}
