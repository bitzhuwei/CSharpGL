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
    public partial class TextRenderer : Renderer, ILayout
    {

        static ShaderCode[] staticShaderCodes;
        static PropertyNameMap map;
        private TextBoxModel model;
        static TextRenderer()
        {
            staticShaderCodes = new ShaderCode[2];
            staticShaderCodes[0] = new ShaderCode(File.ReadAllText(@"TextRenderer\Text.vert"), ShaderType.VertexShader);
            staticShaderCodes[1] = new ShaderCode(File.ReadAllText(@"TextRenderer\Text.frag"), ShaderType.FragmentShader);
            map = new PropertyNameMap();
            map.Add("position", "position");
            map.Add("uv", "uv");
        }

        public TextRenderer(
            System.Windows.Forms.AnchorStyles Anchor,
            System.Windows.Forms.Padding Margin,
            System.Drawing.Size Size,
            int zNear = -1000,
            int zFar = 1000,
            int macCharCount = 100)
            : base(new TextBoxModel(macCharCount), staticShaderCodes, map)
        {
            this.Anchor = Anchor;
            this.Margin = Margin;
            this.Size = Size;
            this.zNear = zNear;
            this.zFar = zFar;

            this.model = this.bufferable as TextBoxModel;
        }


        protected override void DoInitialize()
        {
            base.DoInitialize();

            this.SetUniform("fontTexture",
                new samplerValue(
                    BindTextureTarget.Texture2D,
                    FontResource.Default.FontTextureId,
                    OpenGL.GL_TEXTURE0));
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            //mat4 projection, view, model;
            //this.GetMatrix(out projection, out view, out model);
            //this.SetUniformValue("mvp", projection * view * model);

            base.DoRender(arg);
        }

        public ILayout Container { get; set; }

        public ICollection<ILayout> Controls { get; internal set; }

        public System.Windows.Forms.AnchorStyles Anchor { get; set; }

        public System.Windows.Forms.Padding Margin { get; set; }

        public Point Location { get; set; }

        public Size Size { get; set; }

        public int zNear { get; set; }

        public int zFar { get; set; }
    }
}