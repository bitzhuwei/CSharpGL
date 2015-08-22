using CSharpGL.Maths;
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
    public class PointSpriteStringElement : SceneElementBase, IMVP, IDisposable
    {
        /// <summary>
        /// 如果一行字符串太长，会在达到此值时开启下一行。
        /// </summary>
        private int maxRowWidth = 255;

        /// <summary>
        /// 如果一行字符串太长，会在达到此值时开启下一行。
        /// </summary>
        public int MaxRowWidth
        {
            get { return maxRowWidth; }
            set { maxRowWidth = value; }
        }
        //static PointSpriteStringElement()
        //{
        //    int[] sizeRange = new int[2];
        //    GL.GetInteger(GetTarget.PointSizeRange, sizeRange);
        //    maxPointSize = sizeRange[1];
        //}

        private vec3 position;

        // result data
        private PrimitiveModes primitiveMode;
        public uint[] texture = new uint[1];
        uint[] vao = new uint[1];
        public ShaderProgram shaderProgram;
        private mat4 currentMVP;
        public const string strMVP = "MVP";
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
            string content, vec3 position, GLColor color = null, int fontSize = 32, int maxRowWidth = 255, FontResource fontResource = null)
        {
            if (fontSize >= maxRowWidth) { throw new ArgumentException(); }

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
            this.maxRowWidth = maxRowWidth;

            if (fontResource == null)
            {
                this.resource = FontResource.Instance;
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
            // step 1: get totalLength
            int totalLength = 0;
            {
                int glyphsLength = 0;
                for (int i = 0; i < content.Length; i++)
                {
                    char c = content[i];
                    CharacterInfo cInfo;
                    if (fontResource.CharInfoDict.TryGetValue(c, out cInfo))
                    {
                        int glyphWidth = cInfo.width;
                        glyphsLength += glyphWidth;
                    }
                    //else
                    //{ throw new Exception(string.Format("Not support for display the char [{0}]", c)); }
                }

                //glyphsLength = (glyphsLength * this.fontSize / FontResource.Instance.FontHeight);
                int interval = fontResource.FontHeight / 10; if (interval < 1) { interval = 1; }
                totalLength = glyphsLength + interval * (content.Length - 1);
            }

            // step 2: setup contentBitmap
            Bitmap contentBitmap = null;
            {
                int interval = fontResource.FontHeight / 10; if (interval < 1) { interval = 1; }
                //int totalLength = glyphsLength + interval * (content.Length - 1);
                int currentTextureWidth = 0;
                int currentWidthPos = 0;
                int currentHeightPos = 0;
                if (totalLength * fontSize > maxRowWidth * fontResource.FontHeight)// 超过1行能显示的内容
                {
                    currentTextureWidth = maxRowWidth * fontResource.FontHeight / fontSize;

                    int lineCount = (totalLength - 1) / currentTextureWidth + 1;
                    // 确保整篇文字的高度在贴图中间。
                    currentHeightPos = (currentTextureWidth - fontResource.FontHeight * lineCount) / 2;
                    //- FontResource.Instance.FontHeight / 2;
                }
                else//只在一行内即可显示所有字符
                {
                    if (totalLength >= fontResource.FontHeight)
                    {
                        currentTextureWidth = totalLength;

                        // 确保整篇文字的高度在贴图中间。
                        currentHeightPos = (currentTextureWidth - fontResource.FontHeight) / 2;
                        //- FontResource.Instance.FontHeight / 2;
                    }
                    else
                    {
                        currentTextureWidth = fontResource.FontHeight;

                        currentWidthPos = (currentTextureWidth - totalLength) / 2;
                        //glyphsLength = fontResource.FontHeight;
                    }
                }

                //this.textureWidth = textureWidth * this.fontSize / FontResource.Instance.FontHeight;
                //currentWidthPosition = currentWidthPosition * this.fontSize / FontResource.Instance.FontHeight;
                //currentHeightPosition = currentHeightPosition * this.fontSize / FontResource.Instance.FontHeight;

                contentBitmap = new Bitmap(currentTextureWidth, currentTextureWidth);
                Graphics gContentBitmap = Graphics.FromImage(contentBitmap);
                Bitmap bigBitmap = fontResource.FontBitmap;
                for (int i = 0; i < content.Length; i++)
                {
                    char c = content[i];
                    CharacterInfo cInfo;
                    if (FontResource.Instance.CharInfoDict.TryGetValue(c, out cInfo))
                    {
                        if (currentWidthPos + cInfo.width > contentBitmap.Width)
                        {
                            currentWidthPos = 0;
                            currentHeightPos += fontResource.FontHeight;
                        }

                        gContentBitmap.DrawImage(bigBitmap,
                            new Rectangle(currentWidthPos, currentHeightPos, cInfo.width, fontResource.FontHeight),
                            new Rectangle(cInfo.xoffset, cInfo.yoffset, cInfo.width, fontResource.FontHeight),
                            GraphicsUnit.Pixel);

                        currentWidthPos += cInfo.width + interval;
                    }
                }
                gContentBitmap.Dispose();
                //contentBitmap.Save("PointSpriteFontElement-contentBitmap.png");
            }

            // step 4: get texture's size 
            int targetTextureWidth;
            {

                //	Get the maximum texture size supported by OpenGL.
                int[] textureMaxSize = { 0 };
                GL.GetInteger(GetTarget.MaxTextureSize, textureMaxSize);

                //	Find the target width and height sizes, which is just the highest
                //	posible power of two that'll fit into the image.

                targetTextureWidth = textureMaxSize[0];
                //System.Drawing.Bitmap bitmap = contentBitmap;
                int scaledWidth = 8 * contentBitmap.Width * fontSize / fontResource.FontHeight;

                for (int size = 1; size <= textureMaxSize[0]; size *= 2)
                {
                    if (scaledWidth < size)
                    {
                        targetTextureWidth = size / 2;
                        break;
                    }
                    if (scaledWidth == size)
                        targetTextureWidth = size;
                }

                this.textureWidth = targetTextureWidth;
            }

            // step 5: scale contentBitmap to right size
            System.Drawing.Bitmap targetImage = contentBitmap;
            if (contentBitmap.Width != targetTextureWidth || contentBitmap.Height != targetTextureWidth)
            {
                //  Resize the image.
                targetImage = (System.Drawing.Bitmap)contentBitmap.GetThumbnailImage(
                    targetTextureWidth, targetTextureWidth, null, IntPtr.Zero);
            }

            // step 6: generate texture
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

            // step 7: release images
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
            var vertexShaderSource = ManifestResourceLoader.LoadTextFile(@"SceneElements.PointSpriteStringElement.vert");
            var fragmentShaderSource = ManifestResourceLoader.LoadTextFile(@"SceneElements.PointSpriteStringElement.frag");
            var shaderProgram = new ShaderProgram();
            shaderProgram.Create(vertexShaderSource, fragmentShaderSource, null);
            this.attributeIndexPosition = shaderProgram.GetAttributeLocation("in_Position");
            shaderProgram.AssertValid();
            this.shaderProgram = shaderProgram;
        }

        protected override void DoRender(RenderModes renderMode)
        {
            // 用VAO+EBO进行渲染。
            //  Bind the out vertex array.
            GL.BindVertexArray(vao[0]);

            GL.DrawArrays((uint)this.primitiveMode, 0, 1);

            //  Unbind our vertex array and shader.
            GL.BindVertexArray(0);
        }

        ~PointSpriteStringElement()
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
                // Managed cleanup code here, while managed refs still valid
            }
            // Unmanaged cleanup code here
            //GL.DeleteTextures(1, this.texture);
            try
            {
                //int count = this.texture.Length;
                //GL.DeleteTextures(count, this.texture);
            }
            catch (Exception ex)
            {

            }

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

        void IMVP.UpdateMVP(mat4 mvp)
        {
            this.currentMVP = mvp;

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

            ShaderProgram shaderProgram = this.shaderProgram;
            shaderProgram.Bind();

            shaderProgram.SetUniformMatrix4(strMVP, mvp.to_array());
            //shaderProgram.SetUniform(PointSpriteStringElement.strpointSize, this.PointSize);
            shaderProgram.SetUniform(PointSpriteStringElement.strpointSize, textureWidth / 10.0f);
            shaderProgram.SetUniform(PointSpriteStringElement.strtex, this.texture[0]);
            shaderProgram.SetUniform(PointSpriteStringElement.strtextColor, this.textColor.x, this.textColor.y, this.textColor.z);
            //shaderProgram.SetUniform(PointSpriteStringElement.strtextColor, (float)random.NextDouble(), (float)random.NextDouble(), (float)random.NextDouble());
        }


        void IMVP.UnbindShaderProgram()
        {
            ShaderProgram shaderProgram = this.shaderProgram;
            shaderProgram.Unbind();

            GL.BindTexture(GL.GL_TEXTURE_2D, 0);

            GL.Disable(GL.GL_BLEND);
            GL.Disable(GL.GL_VERTEX_PROGRAM_POINT_SIZE);
            GL.Disable(GL.GL_POINT_SPRITE_ARB);
            GL.Disable(GL.GL_POINT_SMOOTH);
        }

    }

}
