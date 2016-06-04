using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Demos
{
    /// <summary>
    /// 使用Default字体在一块区域渲染文字。
    /// </summary>
    public partial class GLText : UIRenderer
    {

        private TextModel model;
        private BlendSwitch blendSwitch = new BlendSwitch(BlendingSourceFactor.SourceAlpha, BlendingDestinationFactor.OneMinusSourceAlpha);

        public GLText(
            System.Windows.Forms.AnchorStyles anchor, System.Windows.Forms.Padding margin,
            System.Drawing.Size size, int zNear, int zFar, int maxCharCount = 100)
            : base(null, anchor, margin, size, zNear, zFar)
        {
            this.Name = "GLText";
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(ManifestResourceLoader.LoadTextFile(
@"GLControls.GLText.GLText.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(ManifestResourceLoader.LoadTextFile(
@"GLControls.GLText.GLText.frag"), ShaderType.FragmentShader);
            var map = new PropertyNameMap();
            map.Add("position", "position");
            map.Add("uv", "uv");
            var model = new TextModel(maxCharCount);
            Renderer renderer = new Renderer(model, shaderCodes, map);

            this.model = model;
            this.Renderer = renderer;
        }

        protected override void DoInitialize()
        {
            base.DoInitialize();

            this.Renderer.SetUniform("fontTexture",
                FontResource.Default.GetSamplerValue());
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            //mat4 projection, view, model;
            //this.GetMatrix(out projection, out view, out model);
            //this.SetUniformValue("mvp", projection * view * model);

            blendSwitch.On();

            base.DoRender(arg);

            blendSwitch.Off();
        }

    }
}