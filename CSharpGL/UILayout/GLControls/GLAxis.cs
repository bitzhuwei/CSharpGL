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
        private ViewportSwitch viewportSwitch;
        private ScissorTestSwitch scissorTestSwitch;

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
@"UILayout.GLControls.GLAxis.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(ManifestResourceLoader.LoadTextFile(
@"UILayout.GLControls.GLAxis.frag"), ShaderType.FragmentShader);
            var map = new PropertyNameMap();
            map.Add("in_Position", "position");
            map.Add("in_Color", "color");
            PickableRenderer renderer = (new Axis()).GetRenderer(shaderCodes, map, "position");
          
            this.Renderer = renderer;
        }

        protected override void DoInitialize()
        {
            base.DoInitialize();

            {
                this.viewportSwitch = new ViewportSwitch();
                this.scissorTestSwitch = new ScissorTestSwitch();

                if (this.Renderer is OneIndexRenderer)
                {
                    GLSwitch primitiveRestartSwitch = new PrimitiveRestartSwitch((this.Renderer as OneIndexRenderer).IndexBufferPtr);
                    this.Renderer.SwitchList.Add(primitiveRestartSwitch);
                }
            }
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            this.viewportSwitch.X = this.Location.X;
            this.viewportSwitch.Y = this.Location.Y;
            this.viewportSwitch.Width = this.Size.Width;
            this.viewportSwitch.Height = this.Size.Height;
            this.scissorTestSwitch.X = this.Location.X;
            this.scissorTestSwitch.Y = this.Location.Y;
            this.scissorTestSwitch.Width = this.Size.Width;
            this.scissorTestSwitch.Height = this.Size.Height;

            this.scissorTestSwitch.On();
            this.viewportSwitch.On();
            OpenGL.Clear(OpenGL.GL_DEPTH_BUFFER_BIT);
            //OpenGL.Clear(OpenGL.GL_COLOR_BUFFER_BIT);

            base.DoRender(arg);

            this.viewportSwitch.Off();
            this.scissorTestSwitch.Off();
        }
    }
}
