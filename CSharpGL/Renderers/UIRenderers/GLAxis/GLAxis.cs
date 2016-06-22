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

        protected override void DoRender(RenderEventArgs arg)
        {
            ICamera camera = arg.Camera;
            mat4 projection = this.GetOrthoProjection();
            vec3 position = (camera.Position - camera.Target).normalize();
            mat4 view = glm.lookAt(position, new vec3(0, 0, 0), camera.UpVector);
            float length = Math.Max(this.Size.Width, this.Size.Height) / 2;
            mat4 model = glm.scale(mat4.identity(),
                new vec3(length, length, length));
            this.Renderer.SetUniform("projectionMatrix", projection);
            this.Renderer.SetUniform("viewMatrix", view);
            this.Renderer.SetUniform("modelMatrix", model);

            base.DoRender(arg);
        }
    }
}
