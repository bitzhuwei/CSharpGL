using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// </summary>
    class BoundedClockRenderer : RendererBase
    {
        private float angle;
        public LegacyBoundingBoxRenderer BoxRenderer { get; set; }
        public ClockRenderer ClockRenderer { get; set; }

        public BoundedClockRenderer()
        {
            //this.BoxRenderer = new LegacyBoundingBoxRenderer(new vec3(1, 1, 1), new vec3(-1, -1, -1), Color.Aqua);
            const float factor = 0.3f;
            this.BoxRenderer = new LegacyBoundingBoxRenderer(factor * new vec3(1, 1, 1), factor * new vec3(-1, -1, -1), Color.Aqua);
            this.ClockRenderer = new ClockRenderer();
        }

        protected override void DoInitialize()
        {
            this.BoxRenderer.Initialize();
            this.ClockRenderer.Initialize();
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            this.ClockRenderer.Render(arg);

            OpenGL.LoadIdentity();
            OpenGL.Rotatef(angle, 0, 1, 0);
            this.BoxRenderer.Render(arg);
            angle += 3.0f;
        }
    }
}
