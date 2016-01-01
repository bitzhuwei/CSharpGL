using GLM;
using CSharpGL.Objects.Cameras;
using CSharpGL.Objects.Shaders;
using CSharpGL.Texts;
using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace CSharpGL.Objects.SceneElements
{
    /// <summary>
    /// 用一个纹理绘制所有指定范围内的可见字符（具有指定的高度和字体）
    /// </summary>
    public class FontElement : SceneElementBase, IMVP
    {

        public bool blend = true;

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

        private string text = string.Empty;

        /// <summary>
        /// 要绘制的文字，暂时只支持ASCII码范围内的字符
        /// </summary>
        /// <returns></returns>
        public string GetText()
        {
            return this.text;
        }

        /// <summary>
        /// 要绘制的文字
        /// </summary>
        /// <param name="value"></param>
        public void SetText(string value)
        {
            if (this.text != value)
            {
                this.text = value;
                InitVAO(value);
            }
        }

        private void InitVAO(string value)
        {
            if (value == null) { value = string.Empty; }

            this.mode = DrawMode.Quads;
            this.vertexCount = 4 * value.Length;

            //  Create a vertex buffer for the vertex data.
            UnmanagedArray<vec3> in_Position = new UnmanagedArray<vec3>(this.vertexCount);
            UnmanagedArray<vec2> in_TexCoord = new UnmanagedArray<vec2>(this.vertexCount);
            Bitmap bigBitmap = this.ttfTexture.BigBitmap;
            // step 1: set width for each glyph
            vec3[] tmpPositions = new vec3[this.vertexCount];
            float totalLength = 0;
            for (int i = 0; i < value.Length; i++)
            {
                char c = value[i];
                CharacterInfo cInfo;
                if (this.ttfTexture.CharInfoDict.TryGetValue(c, out cInfo))
                {
                    float glyphWidth = (float)cInfo.width / (float)this.ttfTexture.FontHeight;
                    if (i == 0)
                    {
                        tmpPositions[i * 4 + 0] = new vec3(0, 0, 0);
                        tmpPositions[i * 4 + 1] = new vec3(glyphWidth, 0, 0);
                        tmpPositions[i * 4 + 2] = new vec3(glyphWidth, 1, 0);
                        tmpPositions[i * 4 + 3] = new vec3(0, 1, 0);
                    }
                    else
                    {
                        tmpPositions[i * 4 + 0] = tmpPositions[i * 4 + 0 - 4 + 1];
                        tmpPositions[i * 4 + 1] = tmpPositions[i * 4 + 0] + new vec3(glyphWidth, 0, 0);
                        tmpPositions[i * 4 + 3] = tmpPositions[i * 4 + 3 - 4 - 1];
                        tmpPositions[i * 4 + 2] = tmpPositions[i * 4 + 3] + new vec3(glyphWidth, 0, 0);
                    }
                    totalLength += glyphWidth;
                }
                //else
                //{ throw new Exception(string.Format("Not support for display the char [{0}]", c)); }
            }
            for (int i = 0; i < value.Length; i++)
            {
                char c = value[i];
                CharacterInfo cInfo;
                float x1 = 0;
                float x2 = 1;
                float y1 = 0;
                float y2 = 1;
                if (this.ttfTexture.CharInfoDict.TryGetValue(c, out cInfo))
                {
                    x1 = (float)cInfo.xoffset / (float)bigBitmap.Width;
                    x2 = (float)(cInfo.xoffset + cInfo.width) / (float)bigBitmap.Width;
                    y1 = (float)cInfo.yoffset / (float)bigBitmap.Height;
                    y2 = (float)(cInfo.yoffset + this.ttfTexture.FontHeight) / (float)bigBitmap.Height;
                }
                //else
                //{ throw new Exception(string.Format("Not support for display the char [{0}]", c)); }
                in_Position[i * 4 + 0] = tmpPositions[i * 4 + 0] - new vec3(totalLength / 2, 0, 0);
                in_Position[i * 4 + 1] = tmpPositions[i * 4 + 1] - new vec3(totalLength / 2, 0, 0);
                in_Position[i * 4 + 2] = tmpPositions[i * 4 + 2] - new vec3(totalLength / 2, 0, 0);
                in_Position[i * 4 + 3] = tmpPositions[i * 4 + 3] - new vec3(totalLength / 2, 0, 0);

                //in_TexCoord[i * 4 + 0] = new vec2(x1, y1);
                //in_TexCoord[i * 4 + 1] = new vec2(x2, y1);
                //in_TexCoord[i * 4 + 2] = new vec2(x2, y2);
                //in_TexCoord[i * 4 + 3] = new vec2(x1, y2);
                in_TexCoord[i * 4 + 0] = new vec2(x1, y2);
                in_TexCoord[i * 4 + 1] = new vec2(x2, y2);
                in_TexCoord[i * 4 + 2] = new vec2(x2, y1);
                in_TexCoord[i * 4 + 3] = new vec2(x1, y1);
            }

            if (vao[0] != 0)
            { GL.DeleteVertexArrays(vao.Length, vao); }
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
        public FontElement(string fontFilename, int fontHeight, char firstChar, char lastChar)
        {
            if (firstChar > lastChar) { throw new ArgumentException("first char should <= last char"); }

            int[] maxTextureWidth = new int[1];
            //	Get the maximum texture size supported by GL.
            GL.GetInteger(GetTarget.MaxTextureSize, maxTextureWidth);

            this.ttfTexture = FontTextureHelper.GetTTFTexture(fontFilename, fontHeight, maxTextureWidth[0], firstChar, lastChar);
        }

        protected override void DoInitialize()
        {
            InitTexture();

            InitShaderProgram();

            InitVAO(this.ttfTexture.FirstChar.ToString());
            //InitVAO("1234567890qwertyuiop[]asdfghjkl;'zxcvbnm,./-=!@#$%^&*()_+{}:\"<>?");
            //InitVAO("&");
        }

        private void InitTexture()
        {
            System.Drawing.Bitmap bigBitmap = this.ttfTexture.BigBitmap;

            CreateTextureObject(this.ttfTexture);

            //bigBitmap.Save("modernSingleTextureFont.png");
        }

        private void CreateTextureObject(FontTexture ttfTexture)
        {
            this.texture = new Texture2D();
            this.texture.Initialize(ttfTexture.BigBitmap);
        }

        private void InitShaderProgram()
        {
            var vertexShaderSource = ManifestResourceLoader.LoadTextFile(@"SceneElements.FontElement.vert");
            var fragmentShaderSource = ManifestResourceLoader.LoadTextFile(@"SceneElements.FontElement.frag");
            var shaderProgram = new ShaderProgram();
            shaderProgram.Create(vertexShaderSource, fragmentShaderSource, null);

            this.shaderProgram = shaderProgram;
        }

        protected override void DoRender(RenderEventArgs e)
        {

            GL.BindVertexArray(vao[0]);
            GL.DrawArrays(this.mode, 0, this.vertexCount);
            GL.BindVertexArray(0);

        }

        protected override void CleanUnmanagedRes()
        {
            this.ttfTexture.Dispose();

            base.CleanUnmanagedRes();
        }


        void IMVP.SetShaderProgram(mat4 mvp)
        {
            IMVPHelper.SetMVP(this, mvp);
        }

        void IMVP.ResetShaderProgram()
        {
            IMVPHelper.ResetMVP(this);
        }

        ShaderProgram IMVP.GetShaderProgram()
        {
            return this.shaderProgram;
        }
    }

}
