using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    /// <summary>
    /// opengl UI for Axis
    /// </summary>
    public class GLAxis : UIRenderer
    {

        /// <summary>
        /// opengl UI for Axis
        /// </summary>
        /// <param name="anchor"></param>
        /// <param name="margin"></param>
        /// <param name="size"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        public GLAxis(
            System.Windows.Forms.AnchorStyles anchor, System.Windows.Forms.Padding margin,
            System.Drawing.Size size, int zNear, int zFar)
            : base(null, anchor, margin, size, zNear, zFar)
        {
            this.Name = "GLAxis";
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(ManifestResourceLoader.LoadTextFile(
@"Resources.GLAxis.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(ManifestResourceLoader.LoadTextFile(
@"Resources.GLAxis.frag"), ShaderType.FragmentShader);
            var map = new PropertyNameMap();
            map.Add("in_Position", "position");
            map.Add("in_Color", "color");
            //PickableRenderer renderer = (new Axis()).GetRenderer(shaderCodes, map, "position");
            PickableRenderer renderer = new PickableRenderer(new Axis(), shaderCodes, map, "position");

            this.Renderer = renderer;
        }

        protected override void DoInitialize()
        {
            base.DoInitialize();

            var renderer = this.Renderer as OneIndexRenderer;
            if (renderer != null)
            {
                GLSwitch primitiveRestartSwitch = new PrimitiveRestartSwitch(renderer.IndexBufferPtr);
                renderer.SwitchList.Add(primitiveRestartSwitch);
            }
        }

    }
}
