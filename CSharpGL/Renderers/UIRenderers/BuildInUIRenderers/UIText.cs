using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// 使用Default字体在一块区域渲染文字。
    /// UIText is a simple label similar to System.Windows.Forms.Label.
    /// </summary>
    public partial class UIText : UIRenderer
    {

        private TextModel model;

        private FontResource fontResource;

        private string content = string.Empty;
        public string Text
        {
            get { return content; }
            set { this.model.SetText(value, this.fontResource); this.content = value; }
        }

        private BlendSwitch blendSwitch = new BlendSwitch(BlendingSourceFactor.SourceAlpha, BlendingDestinationFactor.One);
        public BlendSwitch BlendSwitch
        {
            get { return blendSwitch; }
        }

        public UIText(
            System.Windows.Forms.AnchorStyles anchor, System.Windows.Forms.Padding margin,
            System.Drawing.Size size, int zNear, int zFar, FontResource fontResource = null, int maxCharCount = 100)
            : base(anchor, margin, size, zNear, zFar)
        {
            if (fontResource == null)
            { this.fontResource = FontResource.Default; }
            else
            { this.fontResource = fontResource; }

            this.Name = this.GetType().Name;
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(ManifestResourceLoader.LoadTextFile(
@"Resources.UIText.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(ManifestResourceLoader.LoadTextFile(
@"Resources.UIText.frag"), ShaderType.FragmentShader);
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

            Renderer renderer = this.Renderer as Renderer;
            renderer.SetUniform("fontTexture", this.fontResource.GetSamplerValue());
        }

        protected override void DoRender(RenderEventArg arg)
        {
            mat4 projection = this.GetOrthoProjection();
            //vec3 position = (this.camera.Position - this.camera.Target).normalize();
            mat4 view = glm.lookAt(new vec3(0, 0, 1), new vec3(0, 0, 0), new vec3(0, 1, 0));
            //float length = Math.Max(glText.Size.Width, glText.Size.Height) / 2;
            float length = this.Size.Height / 2;
            mat4 model = glm.scale(mat4.identity(), new vec3(length, length, length));
            //model = mat4.identity();
            Renderer renderer = this.Renderer as Renderer;
            renderer.SetUniform("mvp", projection * view * model);

            blendSwitch.On();

            base.DoRender(arg);

            blendSwitch.Off();
        }

    }
}