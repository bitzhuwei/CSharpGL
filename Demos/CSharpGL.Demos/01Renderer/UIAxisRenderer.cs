using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Demos
{
    /// <summary>
    /// 不要用这个，因为DrawText会带来意想不到的“惊喜”
    /// </summary>
    class UIAxisRenderer : DummyUIRenderer
    {

        /// <summary>
        /// 支持UI布局的渲染器
        /// </summary>
        /// <param name="modernRenderer">要渲染的对象</param>
        /// <param name="Anchor">绑定到窗口的哪些边？</param>
        /// <param name="Margin">到绑定边的距离</param>
        /// <param name="Size">UI大小</param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        public UIAxisRenderer(
            System.Windows.Forms.AnchorStyles Anchor,
            System.Windows.Forms.Padding Margin,
            System.Drawing.Size Size,
            int zNear = -1000,
            int zFar = 1000
            )
            : base(null, Anchor, Margin, Size, zNear, zFar)
        {
            ShaderCode[] shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"01Renderer\Simple.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(@"01Renderer\Simple.frag"), ShaderType.FragmentShader);
            var propertyNameMap = new PropertyNameMap();
            propertyNameMap.Add("in_Position", "position");
            propertyNameMap.Add("in_Color", "color");

            PickableRenderer pickableRenderer = PickableRendererFactory.GetRenderer(
                new Axis(), shaderCodes, propertyNameMap, "position");
            pickableRenderer.Name = string.Format("Pickable: [{0}]", "Axis");
            pickableRenderer.Initialize();
            {
                GLSwitch lineWidthSwitch = new LineWidthSwitch(10);
                pickableRenderer.SwitchList.Add(lineWidthSwitch);
                GLSwitch pointSizeSwitch = new PointSizeSwitch(10);
                pickableRenderer.SwitchList.Add(pointSizeSwitch);
                GLSwitch polygonModeSwitch = new PolygonModeSwitch(PolygonModes.Filled);
                pickableRenderer.SwitchList.Add(polygonModeSwitch);
                if (pickableRenderer is OneIndexRenderer)
                {
                    GLSwitch primitiveRestartSwitch = new PrimitiveRestartSwitch((pickableRenderer as OneIndexRenderer).IndexBufferPtr);
                    pickableRenderer.SwitchList.Add(primitiveRestartSwitch);
                }
            }
            this.renderer = pickableRenderer;

            this.textList.Add(new Tuple<vec3, string, Font, Color>(new vec3(offset, 0, 0), "X", new Font("Courier New", fontSize), Color.Red));
            this.textList.Add(new Tuple<vec3, string, Font, Color>(new vec3(0, offset, 0), "Y", new Font("Courier New", fontSize), Color.Green));
            this.textList.Add(new Tuple<vec3, string, Font, Color>(new vec3(0, 0, offset), "Z", new Font("Courier New", fontSize), Color.Blue));
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            mat4 projection, view, model;
            this.GetMatrix(out projection, out view, out model, arg.Camera);
            foreach (var item in this.textList)
            {
                vec3 screenPos = glm.project(item.Item1, view * model, projection, arg.CanvasRect.ToViewport());
                GL.DrawText((int)(screenPos.x - fontSize / 3), (int)(screenPos.y - fontSize / 3), item.Item4, item.Item3.Name, item.Item3.Size, item.Item2);
            }
            base.DoRender(arg);
        }

        List<Tuple<vec3, string, Font, Color>> textList = new List<Tuple<vec3, string, Font, Color>>();

        const float fontSize = 20.0f;
        const float offset = 1.20f;
    }
}
