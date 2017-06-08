using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    class readme
    {
        public void Design00_HowToUseCSharpGL()
        {
            IGLCanvas canvas = GetCanvas();
            IGLRenderContext renderContext = canvas.RenderContext;
            renderContext.MakeCurrent();

            RenderScene();
        }

        private void RenderScene()
        {
            GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

            throw new NotImplementedException();
        }

        private IGLCanvas GetCanvas()
        {
            throw new NotImplementedException();
        }
    }
}
