using CSharpGL.Maths;
using CSharpGL.Objects;
using CSharpGL.Objects.Shaders;
using CSharpGL.Texts;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Winforms.Demo
{
    class WholeFontTextureElement : SceneElementBase, IDisposable
    {
        internal bool blend = true;

        //public uint[] texture = new uint[1];
        public Texture2D texture;
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

        private void InitVAO()
        {
            this.mode = PrimitiveModes.Quads;
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
            //System.Drawing.Bitmap bigBitmap = this.ttfTexture.BigBitmap;

            //CreateTextureObject(bigBitmap);
            CreateTextureObject(this.ttfTexture);

            //// TODO: 测试用，可删除。
            //bigBitmap.Save("WholeFontTextureElement.png");
        }

        private void CreateTextureObject(FontTexture fontTexture)
        {
            this.texture = new Texture2D();
            this.texture.Initialize(fontTexture.BigBitmap);
        }

        //private void CreateTextureObject(FontTexture ttfTexture)
        //{
        //    //	Get the maximum texture size supported by OpenGL.
        //    int[] textureMaxSize = { 0 };
        //    GL.GetInteger(GetTarget.MaxTextureSize, textureMaxSize);

        //    //	Find the target width and height sizes, which is just the highest
        //    //	posible power of two that'll fit into the image.
        //    int textureWidth;
        //    int textureHeight;
        //    ttfTexture.GetTextureWidthHeight(textureMaxSize[0], out textureWidth, out textureHeight);

        //    System.Drawing.Bitmap bigBitmap = ttfTexture.BigBitmap;
        //    System.Drawing.Bitmap newImage = bigBitmap;

        //    //  If need to scale, do so now.
        //    if (bigBitmap.Width != textureWidth || bigBitmap.Height != textureHeight)
        //    {
        //        //  Resize the image.
        //        newImage = (System.Drawing.Bitmap)bigBitmap.GetThumbnailImage(textureWidth, textureHeight, null, IntPtr.Zero);
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
        //    if (newImage != bigBitmap)
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

        protected override void DoRender(RenderEventArgs e)
        {
            GL.BindVertexArray(vao[0]);
            GL.DrawArrays(this.mode, 0, this.vertexCount);
            GL.BindVertexArray(0);
        }


        #region IDisposable Members

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        } // end sub

        /// <summary>
        /// Destruct instance of the class.
        /// </summary>
        ~WholeFontTextureElement()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// Backing field to track whether Dispose has been called.
        /// </summary>
        private bool disposedValue = false;

        /// <summary>
        /// Dispose managed and unmanaged resources of this instance.
        /// </summary>
        /// <param name="disposing">If disposing equals true, managed and unmanaged resources can be disposed. If disposing equals false, only unmanaged resources can be disposed. </param>
        protected virtual void Dispose(bool disposing)
        {

            if (this.disposedValue == false)
            {
                if (disposing)
                {
                    // TODO: Dispose managed resources.
                } // end if

                // TODO: Dispose unmanaged resources.
                this.ttfTexture.Dispose();

            } // end if

            this.disposedValue = true;
        } // end sub

        #endregion

    }
}
