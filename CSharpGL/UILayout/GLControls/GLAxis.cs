using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public class GLAxis : GLControl, IRenderable
    {
        public GLAxis(
            System.Windows.Forms.AnchorStyles anchor, System.Windows.Forms.Padding margin,
            System.Drawing.Size size, int zNear, int zFar)
            : base(anchor, margin, size, zNear, zFar)
        {
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(ManifestResourceLoader.LoadTextFile(
@"UILayout\GLControls.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(ManifestResourceLoader.LoadTextFile(
@"UILayout\GLControls.frag"), ShaderType.FragmentShader);
            var map = new PropertyNameMap();
            map.Add("in_Position", "position");
            map.Add("in_Color", "color");
            this.Renderer = (new Axis()).GetRenderer(shaderCodes, map, "position");
            this.Renderer.Name = "GLAxis";
            this.Renderer.Initialize();
            {
                if (this.Renderer is OneIndexRenderer)
                {
                    GLSwitch glSwitch = new PrimitiveRestartSwitch((this.Renderer as OneIndexRenderer).IndexBufferPtr);
                    this.Renderer.SwitchList.Add(glSwitch);
                }
            }
        }

        public void Render(RenderEventArgs arg)
        {
            this.Renderer.Render(arg);
        }
    }
}
