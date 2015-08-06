using CSharpGL.Maths;
using CSharpGL.Objects.Cameras;
using CSharpGL.Objects.Shaders;
using CSharpGL.Objects.Texts.FreeTypes;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

namespace CSharpGL.Objects.Texts
{
    /// <summary>
    /// 用一个纹理绘制ASCII表上所有可见字符（具有指定的高度和字体）
    /// </summary>
    public class ModernSingleTextureFont : VAOElement
    {

        public bool blend;

        static Random random = new Random();

        ScientificCamera camera;

        float rotation = 0.0f;
        private string fontFilename;
        private int fontHeight;

        uint[] texture = new uint[1];
        private int textureWidth;
        private int textureHeight;
        //CharacterLocation[] characterInfos = new CharacterLocation[maxChar];
        CharacterInfo[] charactersInfoInTexture = new CharacterInfo[maxChar];

        //  Constants that specify the attribute indexes.
        //internal uint in_PositionLocation;
        //internal uint in_TexCoordLocation;
        //internal int transformMatrixLocation;
        //internal int colorLocation;
        //internal int texLocation;
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

        //const int maxChar = char.MaxValue;
        const int maxChar = 128;

        private string text = string.Empty;

        /// <summary>
        /// 要绘制的文字，暂时只支持ASCII码范围内的字符
        /// </summary>
        public string Text
        {
            get { return text; }
            set
            {
                if (value != text)
                {
                    text = value;

                    InitVAO(value);
                }
            }
        }

        private void InitVAO(string value)
        {
            if (value == null) { value = string.Empty; }

            this.mode = PrimitiveModes.Quads;
            this.vertexCount = 4 * value.Length;

            UnmanagedArray<vec3> in_Position = new UnmanagedArray<vec3>(this.vertexCount);
            for (int i = 0; i < value.Length; i++)
            {
                char c = value[i];
                //CharacterLocation location = characterInfos[c];
                in_Position[i * 4 + 0] = new vec3(i + 0, 0, 0);
                in_Position[i * 4 + 1] = new vec3(i + 1, 0, 0);
                in_Position[i * 4 + 2] = new vec3(i + 1, 1, 0);
                in_Position[i * 4 + 3] = new vec3(i + 0, 1, 0);
            }

            //  Create a vertex buffer for the vertex data.
            UnmanagedArray<vec2> in_TexCoord = new UnmanagedArray<vec2>(this.vertexCount);
            for (int i = 0; i < value.Length; i++)
            {
                char c = value[i];
                CharacterInfo cInfo = this.charactersInfoInTexture[c];
                in_TexCoord[i * 4 + 0] = new vec2(
                    (float)(cInfo.xoffset) / (float)this.textureWidth, (float)(cInfo.yoffset) / (float)this.textureHeight);
                in_TexCoord[i * 4 + 1] = new vec2(
                    (float)(cInfo.xoffset + cInfo.width) / (float)this.textureWidth, (float)(cInfo.yoffset) / (float)this.textureHeight);
                in_TexCoord[i * 4 + 2] = new vec2(
                    (float)(cInfo.xoffset + cInfo.width) / (float)this.textureWidth, (float)(cInfo.yoffset + cInfo.height) / (float)this.textureHeight);
                in_TexCoord[i * 4 + 3] = new vec2(
                    (float)(cInfo.xoffset) / (float)this.textureWidth, (float)(cInfo.yoffset + cInfo.height) / (float)this.textureHeight);
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


        public ModernSingleTextureFont(ScientificCamera camera, string fontFilename, int fontHeight)
        {
            this.camera = camera;
            this.fontFilename = fontFilename;
            this.fontHeight = fontHeight;
        }



        protected override void DoInitialize()
        {
            InitTexture();

            InitShaderProgram();

            InitVAO("0=2-3+1");
        }

        private void InitTexture()
        {
            // 初始化FreeType库：创建FreeType库指针
            FreeTypeLibrary library = new FreeTypeLibrary();

            // 初始化字体库
            FreeTypeFace face = new FreeTypeFace(library, this.fontFilename);

            int[] maxTextureWidth = new int[1];
            //	Get the maximum texture size supported by GL.
            GL.GetInteger(GetTarget.MaxTextureSize, maxTextureWidth);
            maxTextureWidth[0] = 300;

            GetTextureBlueprint(face, this.fontHeight, maxTextureWidth[0], out this.textureWidth, out this.textureHeight);

            System.Drawing.Bitmap bigBitmap = GetBigBitmap(face, maxTextureWidth[0], this.textureWidth, this.textureHeight);

            CreateTextureObject(bigBitmap);

            bigBitmap.Save("modernSingleTextureFont.png");
            bigBitmap.Dispose();

            face.Dispose();
            library.Dispose();
        }

        private void CreateTextureObject(System.Drawing.Bitmap image)
        {
            //	Get the maximum texture size supported by OpenGL.
            int[] textureMaxSize = { 0 };
            GL.GetInteger(GetTarget.MaxTextureSize, textureMaxSize);

            //	Find the target width and height sizes, which is just the highest
            //	posible power of two that'll fit into the image.
            this.textureWidth = textureMaxSize[0];
            this.textureHeight = textureMaxSize[0];

            for (int size = 1; size <= textureMaxSize[0]; size *= 2)
            {
                if (image.Width < size)
                {
                    this.textureWidth = size / 2;
                    break;
                }
                if (image.Width == size)
                    this.textureWidth = size;

            }

            for (int size = 1; size <= textureMaxSize[0]; size *= 2)
            {
                if (image.Height < size)
                {
                    this.textureHeight = size / 2;
                    break;
                }
                if (image.Height == size)
                    this.textureHeight = size;
            }

            System.Drawing.Bitmap newImage = image;

            //  If need to scale, do so now.
            if (image.Width != this.textureWidth || image.Height != this.textureHeight)
            {
                //  Resize the image.
                newImage = (System.Drawing.Bitmap)image.GetThumbnailImage(this.textureWidth, this.textureHeight, null, IntPtr.Zero);
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

            //GL.TexImage2D(TexImage2DTargets.Texture2D, 0,
            //    TexImage2DFormats.Alpha, widthOfTexture, heightOfTexture,
            //    0, TexImage2DFormats.Alpha, TexImage2DTypes.UnsignedByte, IntPtr.Zero);

            /* We require 1 byte alignment when uploading texture data */
            //GL.PixelStorei(GL.GL_UNPACK_ALIGNMENT, 1);

            /* Clamping to edges is important to prevent artifacts when scaling */
            GL.TexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_WRAP_S, (int)GL.GL_CLAMP_TO_EDGE);
            GL.TexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_WRAP_T, (int)GL.GL_CLAMP_TO_EDGE);

            /* Linear filtering usually looks best for text */
            GL.TexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MIN_FILTER, (int)GL.GL_LINEAR);
            GL.TexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MAG_FILTER, (int)GL.GL_LINEAR);

        }

        private System.Drawing.Bitmap GetBigBitmap(FreeTypeFace face, int maxTextureWidth, int widthOfTexture, int heightOfTexture)
        {
            System.Drawing.Bitmap bigBitmap = new System.Drawing.Bitmap(widthOfTexture, heightOfTexture);
            Graphics graphics = Graphics.FromImage(bigBitmap);

            /* Paste all glyph bitmaps into the texture, remembering the offset */

            //for (int i = (int)'-'; i < (int)'7' + 1; i++)
            for (int i = 0; i < maxChar; i++)
            {
                char c = Convert.ToChar(i);
                FreeTypeBitmapGlyph glyph = new FreeTypeBitmapGlyph(face, c, this.fontHeight);
                bool zeroSize = (glyph.obj.bitmap.rows == 0 && glyph.obj.bitmap.width == 0);
                bool zeroBuffer = glyph.obj.bitmap.buffer == IntPtr.Zero;
                if (zeroSize && (!zeroBuffer)) { throw new Exception(); }
                if ((!zeroSize) && zeroBuffer) { throw new Exception(); }

                if (!zeroSize)
                {
                    int size = glyph.obj.bitmap.width * glyph.obj.bitmap.rows;
                    byte[] byteBitmap = new byte[size];
                    Marshal.Copy(glyph.obj.bitmap.buffer, byteBitmap, 0, byteBitmap.Length);
                    CharacterInfo cInfo = this.charactersInfoInTexture[i];

                    if (cInfo.width > 0)
                    {
                        System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(cInfo.width, cInfo.height);
                        for (int tmpRow = 0; tmpRow < cInfo.height; ++tmpRow)
                        {
                            for (int tmpWidth = 0; tmpWidth < cInfo.width; ++tmpWidth)
                            {
                                byte color = byteBitmap[tmpRow * cInfo.width + tmpWidth];
                                bitmap.SetPixel(tmpWidth, tmpRow, Color.FromArgb(color, color, color));
                            }
                        }

                        bitmap.Save(string.Format("grayText-{0}.bmp", i));

                        int baseLine = this.fontHeight / 4 * 3;
                        //graphics.DrawImage(bitmap, xoffset, yoffset);
                        graphics.DrawImage(bitmap, cInfo.xoffset,
                            cInfo.yoffset + baseLine - glyph.obj.top);
                        //cInfo.yoffset + (this.fontHeight - glyph.obj.top) / 2);
                    }
                }

            }

            graphics.Dispose();

            using (StreamWriter sw = new StreamWriter("characterinfo.txt"))
            {
                //for (int i = 0; i < characterInfos.Length; i++)
                for (int i = 0; i < charactersInfoInTexture.Length; i++)
                {
                    try
                    {
                        CharacterInfo cInfo = this.charactersInfoInTexture[i];
                        sw.Write(i); sw.Write(": "); sw.WriteLine(Convert.ToChar(i));
                        sw.WriteLine(cInfo);
                    }
                    catch (Exception)
                    {
                    }
                }
            }

            return bigBitmap;
        }

        private void GetTextureBlueprint(FreeTypeFace face, int fontHeight, int maxTextureWidth, out int widthOfTexture, out int heightOfTexture)
        {
            widthOfTexture = 0;
            heightOfTexture = this.fontHeight;

            int glyphX = 0;
            int glyphY = 0;

            //for (int i = (int)'-'; i < (int)'7' + 1; i++)
            for (int i = 0; i < maxChar; i++)
            {
                char c = Convert.ToChar(i);
                FreeTypeBitmapGlyph glyph = new FreeTypeBitmapGlyph(face, c, fontHeight);
                bool zeroSize = (glyph.obj.bitmap.rows == 0 && glyph.obj.bitmap.width == 0);
                bool zeroBuffer = glyph.obj.bitmap.buffer == IntPtr.Zero;
                if (zeroSize && (!zeroBuffer)) { throw new Exception(); }
                if ((!zeroSize) && zeroBuffer) { throw new Exception(); }
                if (zeroSize) { continue; }

                // Next we expand the bitmap into an opengl texture
                // 把glyph_bmp.bitmap的长宽扩展成2的指数倍
                int glyphWidth = glyph.obj.bitmap.width; //next_po2(glyph.obj.bitmap.width);
                int glyphHeight = glyph.obj.bitmap.rows; //next_po2(glyph.obj.bitmap.rows);

                if (glyphX + glyphWidth + 1 > maxTextureWidth)
                {
                    //widthOfTexture = Math.Max(widthOfTexture, glyphX);
                    heightOfTexture += this.fontHeight;

                    glyphX = 0;
                    glyphY = heightOfTexture - this.fontHeight;

                    CharacterInfo cInfo = new CharacterInfo();
                    cInfo.xoffset = glyphX; cInfo.yoffset = glyphY;
                    cInfo.width = glyphWidth; cInfo.height = glyphHeight;
                    cInfo.textureName = this.texture[0];
                    this.charactersInfoInTexture[i] = cInfo;
                }
                else
                {
                    widthOfTexture = Math.Max(widthOfTexture, glyphX + glyphWidth + 1);

                    CharacterInfo cInfo = new CharacterInfo();
                    cInfo.xoffset = glyphX; cInfo.yoffset = glyphY;
                    cInfo.width = glyphWidth; cInfo.height = glyphHeight;
                    cInfo.textureName = this.texture[0];
                    this.charactersInfoInTexture[c] = cInfo;

                }

                glyphX += glyphWidth + 1;
            }

        }


        internal int next_po2(int a)
        {
            int rval = 1;
            while (rval < a) rval <<= 1;
            return rval;
        }

        private void InitShaderProgram()
        {
            //  Create the shader program.
            var vertexShaderSource = ManifestResourceLoader.LoadTextFile(@"Texts.freetype.vert");
            var fragmentShaderSource = ManifestResourceLoader.LoadTextFile(@"Texts.freetype.frag");
            var shaderProgram = new ShaderProgram();
            shaderProgram.Create(vertexShaderSource, fragmentShaderSource, null);

            //{
            //    int location = shaderProgram.GetAttributeLocation("in_Position");
            //    if (location >= 0) { this.in_PositionLocation = (uint)location; }
            //    else { throw new Exception(); }
            //}
            //{
            //    int location = shaderProgram.GetAttributeLocation("in_TexCoord");
            //    if (location >= 0) { this.in_TexCoordLocation = (uint)location; }
            //    else { throw new Exception(); }
            //}

            //this.transformMatrixLocation = shaderProgram.GetUniformLocation("transformMatrix");
            //if (this.transformMatrixLocation < 0) { throw new Exception(); }

            //this.colorLocation = shaderProgram.GetUniformLocation("color");
            //if (this.colorLocation < 0) { throw new Exception(); }

            //this.texLocation = GL.GetUniformLocation(shaderProgram.ShaderProgramObject, "tex");
            //if (this.texLocation < 0) { throw new Exception(); }

            shaderProgram.AssertValid();

            this.shaderProgram = shaderProgram;
        }

        public override void Render(RenderModes renderMode)
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
