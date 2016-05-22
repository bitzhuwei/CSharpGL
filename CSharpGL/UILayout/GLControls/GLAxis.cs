using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public class GLAxis : UIRenderer
    {
        //private PickableRenderer renderer;

        public GLAxis(
            System.Windows.Forms.AnchorStyles anchor, System.Windows.Forms.Padding margin,
            System.Drawing.Size size, int zNear, int zFar)
            : base(null, anchor, margin, size, zNear, zFar)
        {
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(ManifestResourceLoader.LoadTextFile(
@"UILayout.GLControls.GLAxis.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(ManifestResourceLoader.LoadTextFile(
@"UILayout.GLControls.GLAxis.frag"), ShaderType.FragmentShader);
            var map = new PropertyNameMap();
            map.Add("in_Position", "position");
            map.Add("in_Color", "color");
            PickableRenderer renderer = (new Axis()).GetRenderer(shaderCodes, map, "position");
            renderer.Name = "GLAxis";
            {
                if (renderer is OneIndexRenderer)
                {
                    GLSwitch glSwitch = new PrimitiveRestartSwitch((renderer as OneIndexRenderer).IndexBufferPtr);
                    renderer.SwitchList.Add(glSwitch);
                }
            }
            this.renderer = renderer;
        }

    }
}
