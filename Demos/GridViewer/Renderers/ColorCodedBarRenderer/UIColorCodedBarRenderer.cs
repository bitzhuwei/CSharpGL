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
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(
                @"shaders\CodedColorBarRect.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(
                @"shaders\CodedColorBarRect.frag"), ShaderType.FragmentShader);
            var map = new PropertyNameMap();
            map.Add("in_Position", CodedColorBarRect.strPosition);
            map.Add("in_Coord", CodedColorBarRect.strCoord);
            this.codedColors = codedColors;
            var model = new CodedColorBarRect(codedColors);
            Renderer renderer = new Renderer(model, shaderCodes, map);
            this.Renderer = renderer;

            //this.SwitchList.Add(new ClearColorSwitch());
        }

        protected override void DoInitialize()
        {
            base.DoInitialize();

            {
                Bitmap bitmap = this.codedColors.GetBitmap(1024);
                var sampler = new sampler1D();
                sampler.Initialize(bitmap);
                bitmap.Dispose();
                Renderer renderer = this.Renderer as Renderer;
                renderer.SetUniform("codedColorSampler", new samplerValue(
                     BindTextureTarget.Texture1D, sampler.Id, OpenGL.GL_TEXTURE0));
            }
        }


        protected override void DoRender(RenderEventArgs arg)
        {
            mat4 projection = this.GetOrthoProjection();
            mat4 view = glm.lookAt(new vec3(0, 0, 1), new vec3(0, 0, 0), new vec3(0, 1, 0));
            float length = Math.Max(this.Size.Width, this.Size.Height);
            mat4 model = glm.scale(mat4.identity(), new vec3(length, length, length));
            Renderer renderer = this.Renderer as Renderer;
            renderer.SetUniform("mvp", projection * view * model);

            base.DoRender(arg);
        }
    }
}
