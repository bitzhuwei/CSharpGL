using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    class Class1
    {
        public void Design00_HowToUseCSharpGL()
        {
            IGLCanvas canvas = GetCanvas();
            GLRenderContext renderContext = canvas.RenderContext;
            renderContext.MakeCurrent();

        }

        private IGLCanvas GetCanvas()
        {
            throw new NotImplementedException();
        }
    }
}
