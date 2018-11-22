using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CSharpGL
{
    class GLButtonRenderer
    {
        public static readonly Dictionary<Thread, GLButtonRenderer> threadRendererDict = new Dictionary<Thread, GLButtonRenderer>();

        public static GLButtonRenderer Instance
        {
            get
            {
                GLButtonRenderer renderer;
                if (!threadRendererDict.TryGetValue(Thread.CurrentThread, out renderer))
                {
                    renderer = new GLButtonRenderer();
                    threadRendererDict.Add(Thread.CurrentThread, renderer);
                }

                return renderer;
            }
        }

        public GLButtonRenderer()
        {
            var model = new CtrlButtonModel();
            var vs = new VertexShader(vert);
            var fs = new FragmentShader(frag);
            var codes = new ShaderArray(vs, fs);
            var map = new AttributeMap();
            map.Add(inPosition, CtrlButtonModel.strPosition);
            map.Add(inColor, CtrlButtonModel.strColor);
            var methodBuilder = new RenderMethodBuilder(codes, map, new PolygonModeSwitch(PolygonMode.Fill), new LineWidthSwitch(2));
            this.renderMethod = methodBuilder.ToRenderMethod(model);
        }

        public void Render(CtrlButton glButton)
        {
            int absLeft = glButton.absLeft;
            int absBottom = glButton.absBottom;
            int width = glButton.width;
            int height = glButton.height;
            GL.Instance.Enable(GL.GL_SCISSOR_TEST);
            GL.Instance.Scissor(absLeft, absBottom, width, height);
            GL.Instance.Viewport(absLeft, absBottom, width, height);

            if (glButton.RenderBackground)
            {
                vec4 color = glButton.BackgroundColor;
                GL.Instance.ClearColor(color.x, color.y, color.z, color.w);
                GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT);
            }

            this.renderMethod.Render();
        }

        private const string inPosition = "inPosition";
        private const string inColor = "inColor";

        private const string vert =
            @"#version 330 core

in vec2 " + inPosition + @";
in vec3 " + inColor + @";

out vec3 passColor;

void main(void) {
	gl_Position = vec4(inPosition, 0.0, 1.0);
    passColor = inColor;
}
";
        private const string frag =
            @"#version 330 core

in vec3 passColor;

out vec4 outColor;

void main(void) {
    outColor = vec4(passColor, 1.0);
}
";
        private RenderMethod renderMethod;
    }
}
