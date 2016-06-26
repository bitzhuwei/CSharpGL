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
    public partial class UIColorCodedBarRenderer : UIRenderer
    {
        private CodedColor[] codedColors;

        public UIColorCodedBarRenderer(CodedColor[] codedColors,
            AnchorStyles anchor, Padding margin,
            System.Drawing.Size size, int zNear, int zFar)
            : base(anchor, margin, size, zNear, zFar)
        {
            this.Name = this.GetType().Name;
            this.codedColors = codedColors;
            //var model = new CodedColorBarRect(codedColors);
            //Renderer renderer = new Renderer(model, shaderCodes, map);
            var renderer = new ColorCodedBarRenderer(codedColors);
            this.Renderer = renderer;

            //this.SwitchList.Add(new ClearColorSwitch());
        }

        protected override void DoRender(RenderEventArg arg)
        {
            mat4 projection = this.GetOrthoProjection();
            mat4 view = glm.lookAt(new vec3(0, 0, 1), new vec3(0, 0, 0), new vec3(0, 1, 0));
            float length = Math.Max(this.Size.Width, this.Size.Height);
            mat4 model = glm.scale(mat4.identity(), new vec3(this.Size.Width, this.Size.Height, length) * 0.45f);
            var renderer = this.Renderer as ColorCodedBarRenderer;
            renderer.RectRenderer.SetUniform("mvp", projection * view * model);
            renderer.LineRenderer.SetUniform("mvp", projection * view * model);

            base.DoRender(arg);
        }
    }
}
