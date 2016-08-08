using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL.Demos
{
    class DefaultRendererComponent : RendererComponent
    {
        private RendererBase renderer;

        public DefaultRendererComponent(RendererBase renderer, SceneObject obj = null)
            : base(obj)
        {
            this.renderer = renderer;
        }

        public override void Render(RenderEventArg arg)
        {
            RendererBase renderer = this.renderer;
            if (renderer != null)
            {
                renderer.Render(arg);
            }
        }

        protected override void DisposeUnmanagedResource()
        {
            RendererBase renderer = this.renderer;
            if (renderer != null)
            {
                this.renderer = null;
                renderer.Dispose();
            }
        }
    }
}
