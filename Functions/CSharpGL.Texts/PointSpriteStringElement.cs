using GLM;
using CSharpGL.Objects.Shaders;
using CSharpGL.Texts;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects.SceneElements
{
    /// <summary>
    /// 用shader+VAO+组装的texture显示一个指定的字符串
    /// <para>代表一个三维空间内的内容不可变的字符串</para>
    /// </summary>
    public class PointSpriteStringElement : RendererBase
    {
        /// <summary>
        /// 如果一行字符串太长，会在达到此值时开启下一行。
        /// </summary>
        private int maxRowWidth = 255;

        ///// <summary>
        ///// 如果一行字符串太长，会在达到此值时开启下一行。
        ///// </summary>
        //public int MaxRowWidth
        //{
        //    get { return maxRowWidth; }
        //    set
        //    {
        //        if (0 < value && value < 257)
        //        {
        //            maxRowWidth = value;
        //        }
        //        else
        //        {
        //            throw new ArgumentOutOfRangeException("max row width must between 0 and 257(not include 0 or 257)");
        //        }
        //    }
        //}
        //static PointSpriteStringElement()
        //{
        //    int[] sizeRange = new int[2];
        //    GL.GetInteger(GetTarget.PointSizeRange, sizeRange);
        //    maxPointSize = sizeRange[1];
        //}

        private vec3 position;

        // result data
        private PrimitiveModes primitiveMode;
        private uint[] texture = new uint[1];
        uint[] vao = new uint[1];
        public ShaderProgram shaderProgram;
        //public const string strMVP = "MVP";
        public const string strpointSize = "pointSize";
        public const string strtextColor = "textColor";
        public const string strtex = "tex";
        private uint attributeIndexPosition;

        private string content;
        ///// <summary>
        ///// 要显示的字符串。
        ///// </summary>
        //public string Content
        //{
        //    get { return content; }
        //    set
        //    {
        //        if (content != value)
        //        {
        //            content = value;
        //            InitTexture(this.content, this.FontSize, this.resouce);
        //        }
        //    }
        //}

        private int fontSize;
        ///// <summary>
        ///// 字符大小。
        ///// </summary>
        //public int FontSize
        //{
        //    get { return fontSize; }
        //    set
        //    {
        //        if (fontSize != value)
        //        {
        //            fontSize = value;
        //            InitTexture(this.content, this.fontSize, this.resouce);
        //        }
        //    }
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        //public float PointSize { get { return textureWidth / 10.0f; } private set { } }

        private int textureWidth;

        private vec3 textColor;
        ///// <summary>
        ///// 获取或设置此字符串的颜色。
        ///// </summary>
        //public GLColor Color
        //{
        //    get { return new GLColor(textColor.x, textColor.y, textColor.z, 1); }
        //    set { this.textColor = new vec3(value.R, value.G, value.B); }
        //}

        private FontResource resource;
        ///// <summary>
        ///// 获取或设置此字符串的字体资源。
        ///// </summary>
        //public FontResource Resource
        //{
        //    get { return this.resouce; }
        //    set
        //    {
        //        if (value != this.resouce)
        //        {
        //            this.resouce = value;
        //            InitTexture(this.content, this.FontSize, this.resouce);
        //        }
        //    }
        //}

        //public void UpdateProperties(string content, GLColor color, int fontSize, FontResource fontResource)
        //{

        //}

        /// <summary>
        /// 用shader+VAO+组装的texture显示字符串
        /// </summary>
        /// <param name="content">要显示的字符串</param>
        /// <param name="position">字符串的中心位置</param>
        /// <param name="color">文字颜色，默认为黑色</param>
        /// <param name="fontSize">字体大小，默认为32</param>
        /// <param name="fontResource">字体资源。默认的字体资源只支持ASCII码。</param>
        public PointSpriteStringElement(
            string content, vec3 position,
            GLColor color = null, int fontSize = 32, int maxRowWidth = 256, FontResource fontResource = null)
        {
            if (fontSize > 256) { throw new ArgumentException(); }

            this.content = content;
            this.position = position;

            if (color == null)
            {
                textColor = new vec3(0, 0, 0);
            }
            else
            {
                textColor = new vec3(color.R, color.G, color.B);
            }

            this.fontSize = fontSize;

            if (0 < maxRowWidth && maxRowWidth < 257)
            {
                this.maxRowWidth = maxRowWidth;
            }
            else
            {
                throw new ArgumentOutOfRangeException("max row width must between 0 and 257(not include 0 or 257)");
            }

            if (fontResource == null)
            {
                this.resource = FontResource.Default;
            }
            else
            {
                this.resource = fontResource;
            }
        }

        protected override void DoInitialize()
        {
            InitTexture(this.content, this.fontSize, this.maxRowWidth, this.resource);

            InitShaderProgram();

            InitVAO();
        }

        /// <summary>
        /// TODO: 这里生成的中间贴图太大，有优化的空间
        /// </summary>
        /// <param name="content"></param>
        private void InitTexture(string content, int fontSize, int maxRowWidth, FontResource fontResource)
        {
            Bitmap contentBitmap = fontResource.GenerateBitmapForString(content, fontSize, maxRowWidth);

            // get texture's size 
            int targetTextureWidth;
            {
                this.textureWidth = contentBitmap.Width;
                targetTextureWidth = contentBitmap.Width;
            }

            // scale contentBitmap to right size
            System.Drawing.Bitmap targetImage = contentBitmap;
            if (contentBitmap.Width != targetTextureWidth || contentBitmap.Height != targetTextureWidth)
            {
                //  Resize the image.
                targetImage = (System.Drawing.Bitmap)contentBitmap.GetThumbnailImage(
                    targetTextureWidth, targetTextureWidth, null, IntPtr.Zero);
            }

            // generate texture
            {
                //  Lock the image bits (so that we can pass them to OGL).
                BitmapData bitmapData = targetImage.LockBits(
                    new Rectangle(0, 0, targetImage.Width, targetImage.Height),
                    ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
                //GL.ActiveTexture(GL.GL_TEXTURE0);
                GL.GenTextures(1, texture);
                GL.BindTexture(GL.GL_TEXTURE_2D, texture[0]);
                GL.TexImage2D(GL.GL_TEXTURE_2D, 0, (int)GL.GL_RGBA,
                    targetImage.Width, targetImage.Height, 0, GL.GL_BGRA, GL.GL_UNSIGNED_BYTE,
                    bitmapData.Scan0);
                //  Unlock the image.
                targetImage.UnlockBits(bitmapData);
                /* We require 1 byte alignment when uploading texture data */
                //GL.PixelStorei(GL.GL_UNPACK_ALIGNMENT, 1);
                /* Clamping to edges is important to prevent artifacts when scaling */
                GL.TexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_WRAP_S, (int)GL.GL_CLAMP_TO_EDGE);
                GL.TexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_WRAP_T, (int)GL.GL_CLAMP_TO_EDGE);
                /* Linear filtering usually looks best for text */
                GL.TexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MIN_FILTER, (int)GL.GL_LINEAR);
                GL.TexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MAG_FILTER, (int)GL.GL_LINEAR);
            }

            // release images
            {
                //targetImage.Save("PointSpriteFontElement-TargetImage.png");
                if (targetImage != contentBitmap)
                {
                    targetImage.Dispose();
                }

                contentBitmap.Dispose();
            }
        }

        private void InitVAO()
        {
            primitiveMode = PrimitiveModes.Points;

            GL.GenVertexArrays(1, vao);
            GL.BindVertexArray(vao[0]);

            //  Create a vertex buffer for the vertex data.
            {
                UnmanagedArray<vec3> in_Position = new UnmanagedArray<vec3>(1);
                in_Position[0] = this.position;

                uint[] ids = new uint[1];
                GL.GenBuffers(1, ids);
                GL.BindBuffer(BufferTarget.ArrayBuffer, ids[0]);
                GL.BufferData(BufferTarget.ArrayBuffer, in_Position, BufferUsage.StaticDraw);
                GL.VertexAttribPointer(attributeIndexPosition, 3, GL.GL_FLOAT, false, 0, IntPtr.Zero);
                GL.EnableVertexAttribArray(attributeIndexPosition);
            }

            //  Unbind the vertex array, we've finished specifying data for it.
            GL.BindVertexArray(0);
        }

        private void InitShaderProgram()
        {
            //  Create the shader program.
            var vertexShaderSource = ManifestResourceLoader.LoadTextFile(@"PointSpriteStringElement.vert");
            var fragmentShaderSource = ManifestResourceLoader.LoadTextFile(@"PointSpriteStringElement.frag");
            var shaderProgram = new ShaderProgram();
            shaderProgram.Create(vertexShaderSource, fragmentShaderSource, null);

            this.attributeIndexPosition = shaderProgram.GetAttributeLocation("in_Position");

            this.shaderProgram = shaderProgram;
        }

        public mat4 mvp;

        protected override void DoRender(RenderEventArgs e)
        {
            {
                GL.Enable(GL.GL_VERTEX_PROGRAM_POINT_SIZE);
                GL.Enable(GL.GL_POINT_SPRITE_ARB);
                //GL.TexEnv(GL.GL_POINT_SPRITE_ARB, GL.GL_COORD_REPLACE_ARB, GL.GL_TRUE);//TODO: test TexEnvi()
                GL.TexEnvf(GL.GL_POINT_SPRITE_ARB, GL.GL_COORD_REPLACE_ARB, GL.GL_TRUE);
                GL.Enable(GL.GL_POINT_SMOOTH);
                GL.Hint(GL.GL_POINT_SMOOTH_HINT, GL.GL_NICEST);
                GL.Enable(GL.GL_BLEND);
                GL.BlendEquation(GL.GL_FUNC_ADD_EXT);
                GL.BlendFuncSeparate(GL.GL_SRC_ALPHA, GL.GL_ONE_MINUS_SRC_ALPHA, GL.GL_ONE, GL.GL_ONE);

                GL.BindTexture(GL.GL_TEXTURE_2D, this.texture[0]);

                shaderProgram.Bind();
                shaderProgram.SetUniformMatrix4("MVP", mvp.to_array());

                //int[] poinSizes = new int[2];
                //GL.GetInteger(GetTarget.PointSizeRange, poinSizes);
                //if (this.textureWidth > poinSizes[1])
                //{
                //    GL.PointParameter(GL.GL_POINT_SIZE_MAX_ARB, this.textureWidth);
                //    GL.GetInteger(GetTarget.PointSizeRange, poinSizes);
                //    Console.WriteLine("asf");
                //}
                shaderProgram.SetUniform(PointSpriteStringElement.strpointSize, this.textureWidth + 0.0f);
                shaderProgram.SetUniform(PointSpriteStringElement.strtex, this.texture[0]);
                shaderProgram.SetUniform(PointSpriteStringElement.strtextColor, this.textColor.x, this.textColor.y, this.textColor.z);
            }

            // 用VAO+EBO进行渲染。
            //  Bind the out vertex array.
            GL.BindVertexArray(vao[0]);

            GL.DrawArrays((uint)this.primitiveMode, 0, 1);

            //  Unbind our vertex array and shader.
            GL.BindVertexArray(0);

            {
                shaderProgram.Unbind();

                GL.BindTexture(GL.GL_TEXTURE_2D, 0);

                GL.Disable(GL.GL_BLEND);
                GL.Disable(GL.GL_VERTEX_PROGRAM_POINT_SIZE);
                GL.Disable(GL.GL_POINT_SPRITE_ARB);
                GL.Disable(GL.GL_POINT_SMOOTH);
            }
        }


        protected override void DisposeUnmanagedResources()
        {
            IntPtr ptr = Win32.wglGetCurrentContext();
            if (ptr != IntPtr.Zero)
            {
                GL.DeleteTextures(this.texture.Length, this.texture);
            }

        }

    }

}
