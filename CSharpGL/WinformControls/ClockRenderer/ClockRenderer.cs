using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    class ClockRenderer : RendererBase
    {
        private readonly ClockPinRenderer pinRenderer = new ClockPinRenderer();
        private readonly ClockCircleRenderer circleRenderer = new ClockCircleRenderer();
        private readonly ClockMarkRenderer markRenderer = new ClockMarkRenderer();

        protected override void DoInitialize()
        {
            pinRenderer.Initialize();
            circleRenderer.Initialize();
            markRenderer.Initialize();
        }

        protected override void DoRender(RenderEventArg arg)
        {
            pinRenderer.Render(arg);
            circleRenderer.Render(arg);
            markRenderer.Render(arg);
        }

    }
}
