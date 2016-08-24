using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    class ClockRenderer : RendererBase
    {
        private readonly ClockCircleRenderer circleRenderer = new ClockCircleRenderer();
        private readonly ClockMarkRenderer markRenderer = new ClockMarkRenderer();
        private readonly ClockPinRenderer pinRenderer = new ClockPinRenderer();

        protected override void DoInitialize()
        {
            circleRenderer.Initialize();
            markRenderer.Initialize();
            pinRenderer.Initialize();
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            circleRenderer.Render(arg);
            markRenderer.Render(arg);
            pinRenderer.Render(arg);
        }

    }
}
