using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public abstract class ActionBase
    {
        public RendererBase RootElement { get; set; }

        public ICamera Camera { get; set; }

        public abstract void Render();

        public ActionBase(RendererBase rootElement, ICamera camera)
        {
            this.RootElement = rootElement;
            this.Camera = camera;
        }

    }
}
