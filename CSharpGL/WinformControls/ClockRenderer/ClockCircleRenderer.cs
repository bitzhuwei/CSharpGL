using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    class ClockCircleRenderer : RendererBase
    {
        private readonly List<vec3> circlePosition = new List<vec3>();
        private readonly List<vec3> circleColor = new List<vec3>();
        private readonly LineWidthSwitch circleLineWidthSwitch = new LineWidthSwitch(8);
    
        protected override void DoInitialize()
        {
            int circleParts = 60;
            for (int i = 0; i < circleParts; i++)
            {
                var position = new vec3(
                    (float)Math.Cos((double)i / (double)circleParts * Math.PI * 2),
                    (float)Math.Sin((double)i / (double)circleParts * Math.PI * 2),
                    0);
                circlePosition.Add(position);
                circleColor.Add(new vec3(1, 1, 1));
            }
        }

        protected override void DoRender(RenderEventArg arg)
        {
            OpenGL.LoadIdentity();
            circleLineWidthSwitch.On();
            OpenGL.Begin(DrawMode.LineLoop);
            for (int i = 0; i < circlePosition.Count; i++)
            {
                vec3 color = circleColor[i];
                OpenGL.Color3f(color.x, color.y, color.z);
                vec3 position = circlePosition[i];
                OpenGL.Vertex3f(position.x, position.y, position.z);
            }
            OpenGL.End();
            circleLineWidthSwitch.Off();
        }

    }
}
