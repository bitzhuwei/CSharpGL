using System;

namespace CSharpGL
{
    /// <summary>
    /// Renders a label(a single line of text) that always faces camera in 3D space.
    /// </summary>
    public partial class LabelRenderer : Renderer
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="maxCharCount">Max char count to display for this label.
        /// Careful to set this value because greater <paramref name="maxCharCount"/> means more space ocupied in GPU nemory.</param>
        /// <param name="labelHeight">Label height(in pixels)</param>
        /// <param name="fontTexture">Use which font to render text?</param>
        public LabelRenderer(int maxCharCount = 64, int labelHeight = 32, IFontTexture fontTexture = null)
            : base(null, null, null, new BlendSwitch(BlendingSourceFactor.SourceAlpha, BlendingDestinationFactor.One))
        {
            GLSwitch blendSwitch = this.SwitchList.Find(x => x is BlendSwitch);
            if (blendSwitch == null) { throw new Exception(); }
            this.blendSwitch = blendSwitch;

            if (fontTexture == null)
            { this.fontTexture = FontTexture.Default; }// FontResource.Default; }
            else
            { this.fontTexture = fontTexture; }

            this.LabelHeight = labelHeight;

            var model = new TextModel(maxCharCount);
            this.bufferable = model;
            this.model = model;

            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(ManifestResourceLoader.LoadTextFile(
                @"Resources\Label.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(ManifestResourceLoader.LoadTextFile(
                @"Resources\Label.frag"), ShaderType.FragmentShader);
            this.shaderCodes = shaderCodes;

            var map = new PropertyNameMap();
            map.Add("in_Position", TextModel.strPosition);
            map.Add("in_UV", TextModel.strUV);
            this.propertyNameMap = map;
        }
    }
}