using CSharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace GridViewer
{
    public partial class UICodedColorBar : UIRenderer
    {
        private CodedColor[] codedColors;

        public sampler1D CodedColorSampler
        {
            get
            {
                var renderer = this.Renderer as CodedColorBarRenderer;
                if (renderer == null) { return null; }

                return renderer.CodedColorSampler;
            }
        }

        public UICodedColorBar(CodedColor[] codedColors,
            AnchorStyles anchor, Padding margin,
            System.Drawing.Size size, int zNear, int zFar)
            : base(anchor, margin, size, zNear, zFar)
        {
            this.Name = this.GetType().Name;
            this.codedColors = codedColors;
            var renderer = new CodedColorBarRenderer(codedColors);
            this.Renderer = renderer;
        }

        protected override void DoRender(RenderEventArg arg)
        {
            const int shrink = 50;// leave some space for first and last value.
            int width = this.Size.Width;
            int height = this.Size.Height;
            mat4 projection = this.GetOrthoProjection();
            mat4 view = glm.lookAt(new vec3(0, 0, 1), new vec3(0, 0, 0), new vec3(0, 1, 0));
            mat4 model = glm.scale(mat4.identity(), new vec3(width / 2 - shrink, height / 2 - 1, 1));
            var renderer = this.Renderer as CodedColorBarRenderer;
            renderer.RectRenderer.SetUniform("mvp", projection * view * model);
            renderer.LineRenderer.SetUniform("mvp", projection * view * model);
            for (int i = 0; i < renderer.ValueRenderers.Length; i++)
            {
                CodedColorValueRenderer valueRenderer = renderer.ValueRenderers[i];
                if (valueRenderer != null)
                {
                    model = glm.translate(mat4.identity(), new vec3(
                        -(width / 2 - shrink) + (width - shrink * 2) / (this.codedColors.Length - 1) * i,
                        -height / 4,
                        0));
                    model = glm.scale(model, new vec3(height, height, height) / 2.3f);
                    valueRenderer.SetUniform("mvp", projection * view * model);
                }
            }

            base.DoRender(arg);
        }

        public void UpdateValues(TracyEnergy.Simba.Data.Keywords.impl.GridBlockProperty property)
        {
            var renderer = this.Renderer as CodedColorBarRenderer;
            for (int i = 0; i < renderer.ValueRenderers.Length; i++)
            {
                CodedColorValueRenderer valueRenderer = renderer.ValueRenderers[i];
                if (valueRenderer != null)
                {
                    valueRenderer.Text = string.Format("{0}", property.Values[i]);
                }
            } 
        }
    }
}
