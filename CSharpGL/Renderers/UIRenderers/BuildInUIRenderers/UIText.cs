using System.Drawing;

namespace CSharpGL
{
    /// <summary>
    /// 使用Default字体在一块区域渲染文字。
    /// UIText is a simple label similar to System.Windows.Forms.Label.
    /// </summary>
    public partial class UIText : UIRenderer
    {
        private TextModel model;

        private IFontTexture fontTexture;

        private string content = string.Empty;

        /// <summary>
        ///
        /// </summary>
        public string Text
        {
            get { return content; }
            set
            {
                if (this.model != null) { this.model.SetText(value, this.fontTexture); }
                this.content = value;
            }
        }

        private BlendSwitch blendSwitch = new BlendSwitch(BlendingSourceFactor.SourceAlpha, BlendingDestinationFactor.OneMinusSourceAlpha);

        /// <summary>
        ///
        /// </summary>
        public BlendSwitch BlendSwitch
        {
            get { return blendSwitch; }
        }

        private UpdatingRecord textColorRecord = new UpdatingRecord();
        private vec3 textColor = new vec3(1, 1, 1);

        /// <summary>
        /// Text's color.
        /// </summary>
        public Color TextColor
        {
            get { return textColor.ToColor(); }
            set
            {
                vec3 color = value.ToVec3();
                textColorRecord.Set(ref this.textColor, color);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="anchor"></param>
        /// <param name="margin"></param>
        /// <param name="size"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        /// <param name="fontTexture"></param>
        /// <param name="maxCharCount"></param>
        public UIText(
            System.Windows.Forms.AnchorStyles anchor, System.Windows.Forms.Padding margin,
            System.Drawing.Size size, int zNear, int zFar, IFontTexture fontTexture = null, int maxCharCount = 100)
            : base(anchor, margin, size, zNear, zFar)
        {
            if (fontTexture == null)
            { this.fontTexture = FontTexture.Default; }// FontResource.Default; }
            else
            { this.fontTexture = fontTexture; }

            this.Name = this.GetType().Name;
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(ManifestResourceLoader.LoadTextFile(
@"Resources.TextModel.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(ManifestResourceLoader.LoadTextFile(
@"Resources.TextModel.frag"), ShaderType.FragmentShader);
            var map = new PropertyNameMap();
            map.Add("position", TextModel.strPosition);
            map.Add("uv", TextModel.strUV);
            var model = new TextModel(maxCharCount);
            var renderer = new Renderer(model, shaderCodes, map);

            this.model = model;
            this.Renderer = renderer;
        }

        /// <summary>
        ///
        /// </summary>
        protected override void DoInitialize()
        {
            base.DoInitialize();

            var renderer = this.Renderer as Renderer;
            renderer.SetUniform("fontTexture", this.fontTexture.TextureObj.ToSamplerValue());
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="arg"></param>
        protected override void DoRender(RenderEventArgs arg)
        {
            // RULE: 用于渲染UI元素的模型，其范围最好是在(-0.5, -0.5, -0.5)到(-0.5, -0.5, -0.5)之间，即保持其边长为1，且位于坐标系中心。这样，就可以用mat4 model = glm.scale(mat4.identity(), new vec3(this.Size.Width, this.Size.Height, 1));来设定其缩放比例了。简单方便。
            mat4 projection = this.GetOrthoProjection();
            //vec3 position = (this.camera.Position - this.camera.Target).normalize();
            mat4 view = glm.lookAt(new vec3(0, 0, 1), new vec3(0, 0, 0), new vec3(0, 1, 0));
            //float length = Math.Max(glText.Size.Width, glText.Size.Height) / 2;
            float length = this.Size.Height;// / 2;
            mat4 model = glm.scale(mat4.identity(), new vec3(length, length, length));
            //model = mat4.identity();
            var renderer = this.Renderer as Renderer;
            renderer.SetUniform("mvp", projection * view * model);
            if (this.textColorRecord.IsMarked())
            {
                renderer.SetUniform("textColor", this.textColor);
                this.textColorRecord.CancelMark();
            }

            blendSwitch.On();

            base.DoRender(arg);

            blendSwitch.Off();
        }
    }
}