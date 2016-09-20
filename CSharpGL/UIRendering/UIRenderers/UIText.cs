namespace CSharpGL
{
    /// <summary>
    /// 使用Default字体在一块区域渲染文字。
    /// UIText is a simple label similar to System.Windows.Forms.Label.
    /// </summary>
    public partial class UIText : UIRenderer
    {
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

            this.textModel = model;
            this.Renderer = renderer;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0} [{1}]", base.ToString(), this.text);
        }
    }
}