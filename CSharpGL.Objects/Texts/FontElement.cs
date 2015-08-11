using CSharpGL.Maths;
using CSharpGL.Objects.Cameras;
using CSharpGL.Objects.Shaders;
using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace CSharpGL.Objects.Texts
{
    /// <summary>
    /// 用一个纹理绘制所有指定范围内的可见字符（具有指定的高度和字体）
    /// </summary>
    public class FontElement : SceneElementBase, IDisposable
    {

        public bool blend;

        public uint[] texture = new uint[1];
        private FontTexture ttfTexture;

        public ShaderProgram shaderProgram;
        const string strin_Position = "in_Position";
        const string strin_TexCoord = "in_TexCoord";
        public const string strprojectionMatrix = "projectionMatrix";
        public const string strviewMatrix = "viewMatrix";
        public const string strmodelMatrix = "modelMatrix";
        public const string strtex = "tex";
        public const string strcolor = "color";

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
            Bitmap bigBitmap = this.ttfTexture.BigBitmap;

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
                in_Position[i * 4 + 0] = new vec3(i, 0, 0);
                in_Position[i * 4 + 1] = new vec3(i + 1, 0, 0);
                in_Position[i * 4 + 2] = new vec3(i + 1, 1, 0);
                in_Position[i * 4 + 3] = new vec3(i, 1, 0);

                in_TexCoord[i * 4 + 0] = new vec2(x1, y1);
                in_TexCoord[i * 4 + 1] = new vec2(x2, y1);
                in_TexCoord[i * 4 + 2] = new vec2(x2, y2);
                in_TexCoord[i * 4 + 3] = new vec2(x1, y2);
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

            //CreateTextureObject(bigBitmap);
            CreateTextureObject(this.ttfTexture);

            // TODO: 测试用，可删除。
            bigBitmap.Save("modernSingleTextureFont.png");
        }

        private void CreateTextureObject(FontTexture ttfTexture)
        {
            //	Get the maximum texture size supported by OpenGL.
            int[] textureMaxSize = { 0 };
            GL.GetInteger(GetTarget.MaxTextureSize, textureMaxSize);

            //	Find the target width and height sizes, which is just the highest
            //	posible power of two that'll fit into the image.
            int textureWidth;
            int textureHeight;
            ttfTexture.GetTextureWidthHeight(textureMaxSize[0], out textureWidth, out textureHeight);

            System.Drawing.Bitmap bigBitmap = ttfTexture.BigBitmap;
            System.Drawing.Bitmap newImage = bigBitmap;

            //  If need to scale, do so now.
            if (bigBitmap.Width != textureWidth || bigBitmap.Height != textureHeight)
            {
                //  Resize the image.
                newImage = (System.Drawing.Bitmap)bigBitmap.GetThumbnailImage(textureWidth, textureHeight, null, IntPtr.Zero);
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
            if (newImage != bigBitmap)
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

        //private void CreateTextureObject(System.Drawing.Bitmap image)
        //{
        //    //	Get the maximum texture size supported by OpenGL.
        //    int[] textureMaxSize = { 0 };
        //    GL.GetInteger(GetTarget.MaxTextureSize, textureMaxSize);

        //    //	Find the target width and height sizes, which is just the highest
        //    //	posible power of two that'll fit into the image.
        //    int textureWidth = textureMaxSize[0];
        //    int textureHeight = textureMaxSize[0];

        //    for (int size = 1; size <= textureMaxSize[0]; size *= 2)
        //    {
        //        if (image.Width < size)
        //        {
        //            textureWidth = size / 2;
        //            break;
        //        }
        //        if (image.Width == size)
        //            textureWidth = size;

        //    }

        //    for (int size = 1; size <= textureMaxSize[0]; size *= 2)
        //    {
        //        if (image.Height < size)
        //        {
        //            textureHeight = size / 2;
        //            break;
        //        }
        //        if (image.Height == size)
        //            textureHeight = size;
        //    }

        //    System.Drawing.Bitmap newImage = image;

        //    //  If need to scale, do so now.
        //    if (image.Width != textureWidth || image.Height != textureHeight)
        //    {
        //        //  Resize the image.
        //        newImage = (System.Drawing.Bitmap)image.GetThumbnailImage(textureWidth, textureHeight, null, IntPtr.Zero);
        //    }

        //    //  Lock the image bits (so that we can pass them to OGL).
        //    BitmapData bitmapData = newImage.LockBits(new Rectangle(0, 0, newImage.Width, newImage.Height),
        //        ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

        //    //GL.ActiveTexture(GL.GL_TEXTURE0);
        //    GL.GenTextures(1, texture);
        //    GL.BindTexture(GL.GL_TEXTURE_2D, texture[0]);

        //    GL.TexImage2D(GL.GL_TEXTURE_2D, 0, (int)GL.GL_RGBA,
        //        newImage.Width, newImage.Height, 0, GL.GL_BGRA, GL.GL_UNSIGNED_BYTE,
        //        bitmapData.Scan0);

        //    //  Unlock the image.
        //    newImage.UnlockBits(bitmapData);

        //    //  Dispose of the image file.
        //    if (newImage != image)
        //    {
        //        newImage.Dispose();
        //    }

        //    /* We require 1 byte alignment when uploading texture data */
        //    //GL.PixelStorei(GL.GL_UNPACK_ALIGNMENT, 1);

        //    /* Clamping to edges is important to prevent artifacts when scaling */
        //    GL.TexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_WRAP_S, (int)GL.GL_CLAMP_TO_EDGE);
        //    GL.TexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_WRAP_T, (int)GL.GL_CLAMP_TO_EDGE);

        //    /* Linear filtering usually looks best for text */
        //    GL.TexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MIN_FILTER, (int)GL.GL_LINEAR);
        //    GL.TexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MAG_FILTER, (int)GL.GL_LINEAR);

        //}


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

            GL.BindVertexArray(vao[0]);
            GL.DrawArrays(this.mode, 0, this.vertexCount);
            GL.BindVertexArray(0);

        }


        ~FontElement()
        {
            this.Dispose();
        }

        #region IDisposable Members

        /// <summary>
        /// Internal variable which checks if Dispose has already been called
        /// </summary>
        protected Boolean disposed;

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected void Dispose(Boolean disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                //Managed cleanup code here, while managed refs still valid
            }
            //Unmanaged cleanup code here
            this.ttfTexture.Dispose();

            disposed = true;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            // Call the private Dispose(bool) helper and indicate
            // that we are explicitly disposing
            this.Dispose(true);

            // Tell the garbage collector that the object doesn't require any
            // cleanup when collected since Dispose was called explicitly.
            GC.SuppressFinalize(this);
        }

        #endregion

    }

}
