using CSharpGL.Maths;
using CSharpGL.Objects.Cameras;
using CSharpGL.Objects.Shaders;
using CSharpGL.Objects.Texts.FreeTypes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

namespace CSharpGL.Objects.Texts
{
    /// <summary>
    /// 用一个纹理绘制ASCII表上所有可见字符（具有指定的高度和字体）
    /// </summary>
    public class ModernSingleTextureFont : SceneElementBase
    {

        public bool blend;

        static Random random = new Random();

        ScientificCamera camera;

        float rotation = 0.0f;

        uint[] texture = new uint[1];
        private TTFTexture ttfTexture;

        private ShaderProgram shaderProgram;
        const string strin_Position = "in_Position";
        const string strin_TexCoord = "in_TexCoord";
        const string strtransformMatrix = "transformMatrix";
        const string strtex = "tex";
        const string strcolor = "color";

        private PrimitiveModes mode;
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

            this.mode = PrimitiveModes.Quads;
            this.vertexCount = 4 * value.Length;

            //  Create a vertex buffer for the vertex data.
            UnmanagedArray<vec3> in_Position = new UnmanagedArray<vec3>(this.vertexCount);
            UnmanagedArray<vec2> in_TexCoord = new UnmanagedArray<vec2>(this.vertexCount);
            for (int i = 0; i < value.Length; i++)
            {
                char c = value[i];
                CharacterInfo cInfo;
                if (this.ttfTexture.CharInfoDict.TryGetValue(c, out cInfo))
                {
                    float x1 = (float)cInfo.xoffset / (float)this.ttfTexture.BigBitmap.Width;
                    float x2 = (float)(cInfo.xoffset + cInfo.width) / (float)this.ttfTexture.BigBitmap.Width;
                    float y1 = (float)cInfo.yoffset / (float)this.ttfTexture.BigBitmap.Height;
                    float y2 = (float)(cInfo.yoffset + this.ttfTexture.FontHeight) / (float)this.ttfTexture.BigBitmap.Height;

                    in_Position[i * 4 + 0] = new vec3(cInfo.xoffset, 0, 0);
                    in_Position[i * 4 + 1] = new vec3(cInfo.xoffset + cInfo.width, 0, 0);
                    in_Position[i * 4 + 2] = new vec3(cInfo.xoffset + cInfo.width, this.ttfTexture.FontHeight, 0);
                    in_Position[i * 4 + 3] = new vec3(cInfo.xoffset, this.ttfTexture.FontHeight, 0);

                    in_TexCoord[i * 4 + 0] = new vec2(x1, y1);
                    in_TexCoord[i * 4 + 1] = new vec2(x2, y1);
                    in_TexCoord[i * 4 + 2] = new vec2(x2, y2);
                    in_TexCoord[i * 4 + 3] = new vec2(x1, y2);
                }
                else
                { throw new Exception(string.Format("Not support for display the char [{0}]", c)); }
            }

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
        /// 用一个纹理绘制ASCII表上所有可见字符（具有指定的高度和字体）
        /// </summary>
        /// <param name="camera"></param>
        /// <param name="fontFilename"></param>
        /// <param name="fontHeight">此值越大，绘制文字的清晰度越高，但占用的纹理资源就越多。</param>
        public ModernSingleTextureFont(ScientificCamera camera,
            string fontFilename, int fontHeight, char firstChar, char lastChar)
        {
            if (firstChar > lastChar) { throw new ArgumentException("first char should <= last char"); }

            this.camera = camera;

            int[] maxTextureWidth = new int[1];
            //	Get the maximum texture size supported by GL.
            GL.GetInteger(GetTarget.MaxTextureSize, maxTextureWidth);

            this.ttfTexture = TTFTextureHelper.GetTTFTexture(fontFilename, fontHeight, firstChar, lastChar, maxTextureWidth[0]);
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

            CreateTextureObject(bigBitmap);

            // TODO: 测试用，可删除。
            bigBitmap.Save("modernSingleTextureFont.png");
        }

        private void CreateTextureObject(System.Drawing.Bitmap image)
        {
            //	Get the maximum texture size supported by OpenGL.
            int[] textureMaxSize = { 0 };
            GL.GetInteger(GetTarget.MaxTextureSize, textureMaxSize);

            //	Find the target width and height sizes, which is just the highest
            //	posible power of two that'll fit into the image.
            int textureWidth = textureMaxSize[0];
            int textureHeight = textureMaxSize[0];

            for (int size = 1; size <= textureMaxSize[0]; size *= 2)
            {
                if (image.Width < size)
                {
                    textureWidth = size / 2;
                    break;
                }
                if (image.Width == size)
                    textureWidth = size;

            }

            for (int size = 1; size <= textureMaxSize[0]; size *= 2)
            {
                if (image.Height < size)
                {
                    textureHeight = size / 2;
                    break;
                }
                if (image.Height == size)
                    textureHeight = size;
            }

            System.Drawing.Bitmap newImage = image;

            //  If need to scale, do so now.
            if (image.Width != textureWidth || image.Height != textureHeight)
            {
                //  Resize the image.
                newImage = (System.Drawing.Bitmap)image.GetThumbnailImage(textureWidth, textureHeight, null, IntPtr.Zero);
            }

            //  Lock the image bits (so that we can pass them to OGL).
            BitmapData bitmapData = newImage.LockBits(new Rectangle(0, 0, newImage.Width, newImage.Height),
                ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            //GL.ActiveTexture(GL.GL_TEXTURE0);
            GL.GenTextures(1, texture);
            GL.BindTexture(GL.GL_TEXTURE_2D, texture[0]);

            GL.TexImage2D(GL.GL_TEXTURE_2D, 0, (int)GL.GL_RGBA,
                newImage.Width, newImage.Height, 0, GL.GL_BGRA, GL.GL_UNSIGNED_BYTE,
                bitmapData.Scan0);

            //  Unlock the image.
            newImage.UnlockBits(bitmapData);

            //  Dispose of the image file.
            if (newImage != image)
            {
                newImage.Dispose();
            }

            /* We require 1 byte alignment when uploading texture data */
            //GL.PixelStorei(GL.GL_UNPACK_ALIGNMENT, 1);

            /* Clamping to edges is important to prevent artifacts when scaling */
            GL.TexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_WRAP_S, (int)GL.GL_CLAMP_TO_EDGE);
            GL.TexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_WRAP_T, (int)GL.GL_CLAMP_TO_EDGE);

            /* Linear filtering usually looks best for text */
            GL.TexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MIN_FILTER, (int)GL.GL_LINEAR);
            GL.TexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MAG_FILTER, (int)GL.GL_LINEAR);

        }


        private void InitShaderProgram()
        {
            var vertexShaderSource = ManifestResourceLoader.LoadTextFile(@"Texts.freetype.vert");
            var fragmentShaderSource = ManifestResourceLoader.LoadTextFile(@"Texts.freetype.frag");
            var shaderProgram = new ShaderProgram();
            shaderProgram.Create(vertexShaderSource, fragmentShaderSource, null);

            shaderProgram.AssertValid();

            this.shaderProgram = shaderProgram;
        }

        protected override void DoRender(RenderModes renderMode)
        {
            GL.BindTexture(GL.GL_TEXTURE_2D, this.texture[0]);

            if (this.blend)
            {
                GL.Enable(GL.GL_BLEND);
                GL.BlendFunc(GL.GL_SRC_ALPHA, GL.GL_ONE_MINUS_SRC_ALPHA);
            }

            ShaderProgram shader = this.shaderProgram;

            shader.Bind();

            shaderProgram.SetUniform(strtex, texture[0]);

            mat4 projectionMatrix = this.camera.GetProjectionMat4();
            mat4 viewMatrix = this.camera.GetViewMat4();
            mat4 matrix = projectionMatrix * viewMatrix;
            shader.SetUniformMatrix4(strtransformMatrix, matrix.to_array());

            const float scale = 3.5f;
            rotation += 0.1f;
            mat4 transformMatrix = glm.translate(mat4.identity(), new vec3(0, -2, 0));
            transformMatrix = glm.rotate(transformMatrix, rotation, new vec3(0, 1, 0));
            transformMatrix = glm.scale(transformMatrix, new vec3(scale, scale, scale));
            //shader.SetUniformMatrix4("transformMatrix", transformMatrix.to_array());

            shader.SetUniform(strcolor, 1.0f, 1.0f, 1.0f, 1.0f);
            //GL.Uniform1(this.texLocation, this.texture[0]);
            //GL.Uniform4(this.colorLocation, 1.0f, 1.0f, 1.0f, 1.0f);
            //GL.Uniform4(this.colorLocation, (float)random.NextDouble(), (float)random.NextDouble(), (float)random.NextDouble(), (float)random.NextDouble());

            GL.BindVertexArray(vao[0]);
            GL.DrawArrays(this.mode, 0, this.vertexCount);
            GL.BindVertexArray(0);

            shader.Unbind();

            if (this.blend)
            {
                GL.Disable(GL.GL_BLEND);
            }

            GL.BindTexture(GL.GL_TEXTURE_2D, 0);
        }


    }

}
