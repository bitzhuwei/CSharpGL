using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public partial class LabelRenderer : Renderer
    {
        private TextModel textModel;

        public vec3 WorldPosition { get; set; }

        public LabelRenderer(int maxCharCount)
            : base(new TextModel(maxCharCount), LabelRenderer.staticShaderCodes, LabelRenderer.staticMap)
        {
            this.textModel = this.bufferable as TextModel;
        }

    }
}
