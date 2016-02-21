using GLM;
using CSharpGL.Objects;
using CSharpGL.Objects.Shaders;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpGL.GlyphTextures;
using CSharpGL.GlyphTextures.FromTTF;

namespace CSharpGL.Winforms.Demo
{
    class WholeFontTextureElement : RendererBase
    {
        public mat4 modelMatrix;
        public mat4 viewMatrix;
        public mat4 projectionMatrix;

        internal bool blend = true;

        //public uint[] texture = new uint[1];
        public Texture2D texture;
        private FontTexture ttfTexture;

        public ShaderProgram shaderProgram;
        const string strin_Position = "in_Position";
        const string strin_TexCoord = "in_TexCoord";
        public const string strtex = "tex";
        public const string strcolor = "color";

        private DrawMode mode;
        private uint[] vao = new uint[1];
        private uint[] vbo = new uint[2];
        private int vertexCount;

        private void InitVAO()
        {
            this.mode = DrawMode.Quads;
            this.vertexCount = 4;

            //  Create a vertex buffer for the vertex data.
            UnmanagedArray<vec3> in_Position = new UnmanagedArray<vec3>(this.vertexCount);
            UnmanagedArray<vec2> in_TexCoord = new UnmanagedArray<vec2>(this.vertexCount);
            Bitmap bigBitmap = this.ttfTexture.BigBitmap;

            float factor = (float)this.ttfTexture.BigBitmap.Width / (float)this.ttfTexture.BigBitmap.Height;
            float x1 = -factor;
            float x2 = factor;
            float y1 = -1;
            float y2 = 1;

            in_Position[0] = new vec3(x1, y1, 0);
            in_Position[1] = new vec3(x2, y1, 0);
            in_Position[2] = new vec3(x2, y2, 0);
            in_Position[3] = new vec3(x1, y2, 0);

            in_TexCoord[0] = new vec2(0, 0);
            in_TexCoord[1] = new vec2(1, 0);
            in_TexCoord[2] = new vec2(1, 1);
            in_TexCoord[3] = new vec2(0, 1);

            if (vao[0] != 0)
            { GL.DeleteBuffers(1, vao); }
            if (vbo[0] != 0)
            { GL.DeleteBuffers(vbo.Length, vbo); }

            GL.GenVertexArrays(1, vao);
            GL.BindVertexArray(vao[0]);

            GL.GenBuffers(2, vbo);

            uint in_PositionLocation = shaderProgram.GetAttributeLocation(strin_Position);
            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo[0]);
            GL.BufferData(BufferTarget.ArrayBuffer, in_Position, BufferUsage.StaticDraw);
            GL.VertexAttribPointer(in_PositionLocation, 3, GL.GL_FLOAT, false, 0, IntPtr.Zero);
            GL.EnableVertexAttribArray(in_PositionLocation);

            uint in_TexCoordLocation = shaderProgram.GetAttributeLocation(strin_TexCoord);
            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo[1]);
            GL.BufferData(BufferTarget.ArrayBuffer, in_TexCoord, BufferUsage.StaticDraw);
            GL.VertexAttribPointer(in_TexCoordLocation, 2, GL.GL_FLOAT, false, 0, IntPtr.Zero);
            GL.EnableVertexAttribArray(in_TexCoordLocation);

            GL.BindVertexArray(0);

            in_Position.Dispose();
            in_TexCoord.Dispose();
        }

        /// <summary>
        /// 用一个纹理绘制指定范围内的可见字符
        /// </summary>
        /// <param name="fontFilename">字体文件名</param>
        /// <param name="fontHeight">此值越大，绘制文字的清晰度越高，但占用的纹理资源就越多。</param>
        /// <param name="firstChar">要显示的第一个字符</param>
        /// <param name="lastChar">要显示的最后一个字符</param>
        public WholeFontTextureElement(string textureFilename, string xmlFilename)
        {
            this.ttfTexture = FontTextureHelper.GetTTFTexture(textureFilename, xmlFilename);
        }

        protected override void DoInitialize()
        {
            InitTexture();

            InitShaderProgram();

            InitVAO();
        }

        private void InitTexture()
        {
            CreateTextureObject(this.ttfTexture);

            //bigBitmap.Save("WholeFontTextureElement.png");
        }

        private void CreateTextureObject(FontTexture fontTexture)
        {
            this.texture = new Texture2D();
            this.texture.Initialize(fontTexture.BigBitmap);
        }

        private void InitShaderProgram()
        {
            var vertexShaderSource = ManifestResourceLoader.LoadTextFile(@"WholeFontTextureElement.vert");
            var fragmentShaderSource = ManifestResourceLoader.LoadTextFile(@"WholeFontTextureElement.frag");
            var shaderProgram = new ShaderProgram();
            shaderProgram.Create(vertexShaderSource, fragmentShaderSource, null);

            this.shaderProgram = shaderProgram;
        }

        protected override void DoRender(RenderEventArgs e)
        {
            CSharpGL.Objects.Texture2D texture = this.texture;
            texture.Bind();

            if (this.blend)
            {
                GL.Enable(GL.GL_BLEND);
                GL.BlendFunc(GL.GL_SRC_ALPHA, GL.GL_ONE_MINUS_SRC_ALPHA);
            }

            ShaderProgram shaderProgram = this.shaderProgram;
            shaderProgram.Bind();
            GL.ActiveTexture(GL.GL_TEXTURE0);
            GL.Enable(GL.GL_TEXTURE_2D);
            texture.Bind();
            shaderProgram.SetUniform(strtex, 0);
            shaderProgram.SetUniform(WholeFontTextureElement.strcolor, 1.0f, 1.0f, 1.0f, 1.0f);
            shaderProgram.SetUniformMatrix4("MVP", (projectionMatrix * viewMatrix * modelMatrix).to_array());

            GL.BindVertexArray(vao[0]);
            GL.DrawArrays(this.mode, 0, this.vertexCount);
            GL.BindVertexArray(0);

            texture.Unbind();
            shaderProgram.Unbind();

            GL.BindTexture(GL.GL_TEXTURE_2D, 0);

            if (this.blend)
            {
                GL.Disable(GL.GL_BLEND);
            }
        }

        protected override void DisposeUnmanagedResources()
        {
            this.ttfTexture.Dispose();

        }

    }
}
