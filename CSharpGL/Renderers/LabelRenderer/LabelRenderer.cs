using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// Renders a label(a single line of text) that always faces camera in 3D space.
    /// </summary>
    public partial class LabelRenderer : Renderer
    {
        private FontResource fontResource;
        private TextModel model;

        public vec3 WorldPosition { get; set; }
        /// <summary>
        /// Label height(in pixels)
        /// </summary>
        public int LabelHeight { get; private set; }

        private string content = string.Empty;
        public string Text
        {
            get { return content; }
            set { this.model.SetText(value, this.fontResource); this.content = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="maxCharCount">Max char count to display for this label.
        /// Careful to set this value because greater <paramref name="maxCharCount"/> means more space ocupied in GPU nemory.</param>
        /// <param name="labelHeight">Label height(in pixels)</param>
        /// <param name="fontResource">Use which font to render text?</param>
        public LabelRenderer(int maxCharCount = 64, int labelHeight = 32, FontResource fontResource = null)
            : base(null, null, null, new BlendSwitch(BlendingSourceFactor.SourceAlpha, BlendingDestinationFactor.One))
        {
            if (fontResource == null)
            { this.fontResource = FontResource.Default; }
            else
            { this.fontResource = fontResource; }

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
