using CSharpGL.Maths;
using CSharpGL.Objects.Cameras;
using CSharpGL.Objects.Shaders;
using CSharpGL.Objects.Texts.FreeTypes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects.Texts
{
    /// <summary>
    /// 用一个纹理绘制ASCII表上所有可见字符（具有指定的高度和字体）
    /// </summary>
    public class ModernSingleTextureFont : VAOElement
    {

        const int maxChar = char.MaxValue;//128;

        private string text = string.Empty;

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

            //  Create a vertex buffer for the vertex data.
            UnmanagedArray<vec4> coord = new UnmanagedArray<vec4>(this.vertexCount);
            for (int i = 0; i < value.Length; i++)
            {
                char c = value[i];
                CharacterLocation location = characterInfos[c];
                coord[i * 4 + 0] = new vec4(i + 0, 0,
                   location.xoffset, location.yoffset);
                coord[i * 4 + 1] = new vec4(i + 1, 0,
                    location.xoffset + location.bitmapWidth / 2 / this.textureWidth, location.yoffset);
                coord[i * 4 + 2] = new vec4(i + 1, 1,
                    location.xoffset + location.bitmapWidth / 2 / this.textureWidth, location.yoffset + location.bitmapTop / this.textureHeight);
                coord[i * 4 + 3] = new vec4(i + 0, 1,
                    location.xoffset, location.yoffset + location.bitmapTop / this.textureHeight);
                //coord[i * 4 + 0] = new vec4(i + 0, 0,
                //    location.xoffset, location.yoffset);
                //coord[i * 4 + 1] = new vec4(i + 0, 1,
                //    location.xoffset + location.bitmapWidth / this.textureWidth, location.yoffset);
                //coord[i * 4 + 2] = new vec4(i + 1, 1,
                //    location.xoffset + location.bitmapWidth / this.textureWidth, location.yoffset + location.bitmapTop / this.textureHeight);
                //coord[i * 4 + 3] = new vec4(i + 1, 0,
                //    location.xoffset, location.yoffset + location.bitmapTop / this.textureHeight);
            }

            if (vao[0] != 0)
            { GL.DeleteBuffers(1, vao); }
            if (vbo[0] != 0)
            { GL.DeleteBuffers(1, vbo); }

            GL.GenVertexArrays(1, vao);
            GL.BindVertexArray(vao[0]);

            GL.GenBuffers(1, vbo);
            GL.BindBuffer(GL.GL_ARRAY_BUFFER, vbo[0]);
            GL.BufferData(BufferTarget.ArrayBuffer, coord, BufferUsage.StaticDraw);
            GL.VertexAttribPointer(coordLocation, 4, GL.GL_FLOAT, false, 0, IntPtr.Zero);
            GL.EnableVertexAttribArray(coordLocation);

            GL.BindVertexArray(0);
        }

        ScientificCamera camera;

        public ModernSingleTextureFont(ScientificCamera camera, string fontFilename, int fontHeight)
        {
            this.camera = camera;
            this.fontFilename = fontFilename;
            this.fontHeight = fontHeight;
        }

        uint[] texture = new uint[1];
        private int textureWidth;
        private int textureHeight;
        CharacterLocation[] characterInfos = new CharacterLocation[maxChar];

        //  Constants that specify the attribute indexes.
        internal uint coordLocation;
        internal int transformMatrixLocation;
        internal int colorLocation;
        internal int texLocation;
        private ShaderProgram shaderProgram;

        private PrimitiveModes mode;
        private uint[] vao = new uint[1];
        private uint[] vbo = new uint[1];
        private int vertexCount;


        protected override void DoInitialize()
        {
            InitTexture();

            InitShaderProgram();

            InitVAO("0=");
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

            FindTextureSize(face, this.fontHeight, maxTextureWidth[0], out this.textureWidth, out this.textureHeight);

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
            GL.PixelStorei(GL.GL_UNPACK_ALIGNMENT, 1);

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
            int xoffset = 0;
            int yoffset = 0;

            int newRowHeight = 0;

            //for (int i = (int)'-'; i < (int)'7' + 1; i++)
            for (int i = 0; i < maxChar; i++)
            {
                char c = Convert.ToChar(i);
                FreeTypeBitmapGlyph glyph = new FreeTypeBitmapGlyph(face, c, this.fontHeight);
                bool zeroSize = (glyph.obj.bitmap.rows == 0 && glyph.obj.bitmap.width == 0);
                bool zeroBuffer = glyph.obj.bitmap.buffer == IntPtr.Zero;
                if (zeroSize && (!zeroBuffer)) { throw new Exception(); }
                if ((!zeroSize) && zeroBuffer) { throw new Exception(); }
                int currentWidth = 0;
                int currentHeight = 0;
                if (!zeroSize)
                {
                    int size = glyph.obj.bitmap.width * glyph.obj.bitmap.rows;
                    byte[] byteBitmap = new byte[size];
                    Marshal.Copy(glyph.obj.bitmap.buffer, byteBitmap, 0, byteBitmap.Length);
                    currentWidth = next_po2(glyph.obj.bitmap.width);
                    currentHeight = next_po2(glyph.obj.bitmap.rows);
                    UnmanagedArray<byte> expanded = new UnmanagedArray<byte>(2 * currentWidth * currentHeight);
                    for (int row = 0; row < currentHeight; row++)
                    {
                        for (int col = 0; col < currentWidth; col++)
                        {
                            expanded[2 * (col + row * currentWidth)] = expanded[2 * (col + row * currentWidth) + 1] =
                                (col >= glyph.obj.bitmap.width || row >= glyph.obj.bitmap.rows) ?
                                (byte)0 : byteBitmap[col + glyph.obj.bitmap.width * row];
                        }
                    }

                    if (xoffset + currentWidth + 1 >= maxTextureWidth)
                    {
                        yoffset += newRowHeight;
                        newRowHeight = 0;
                        xoffset = 0;
                    }

                    if (currentWidth >= 2)
                    {
                        System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(
                            currentWidth / 2,
                            glyph.obj.bitmap.rows,
                            currentWidth * 4 / 2,
                            System.Drawing.Imaging.PixelFormat.Format32bppRgb,
                            expanded.Header);
                        graphics.DrawImage(bitmap, xoffset, yoffset);
                    }
                }

                characterInfos[i].advanceX = glyph.glyphRec.advance.x >> 6;
                characterInfos[i].advanceY = glyph.glyphRec.advance.y >> 6;

                characterInfos[i].bitmapWidth = currentWidth;
                characterInfos[i].bitmapHeight = currentHeight;

                characterInfos[i].bitmapLeft = glyph.obj.left;
                characterInfos[i].bitmapTop = glyph.obj.top;

                characterInfos[i].xoffset = xoffset / (float)widthOfTexture;
                characterInfos[i].yoffset = yoffset / (float)heightOfTexture;

                newRowHeight = Math.Max(newRowHeight, currentHeight);
                xoffset += currentWidth + 1;
            }

            graphics.Dispose();

            using (StreamWriter sw = new StreamWriter("characterinfo.txt"))
            {
                for (int i = 0; i < characterInfos.Length; i++)
                {
                    try
                    {
                        sw.Write(i); sw.Write(": "); sw.WriteLine(Convert.ToChar(i));
                        sw.WriteLine(characterInfos[i]);
                    }
                    catch (Exception)
                    {
                    }
                }
            }

            return bigBitmap;
        }

        private void FindTextureSize(FreeTypeFace face, int fontHeight, int maxTextureWidth, out int widthOfTexture, out int heightOfTexture)
        {
            widthOfTexture = 0;
            heightOfTexture = 0;

            int newRowWidth = 0;
            int newRowHeight = 0;

            //for (int i = (int)'-'; i < (int)'7' + 1; i++)
            for (int i = 0; i < maxChar; i++)
            {
                FreeTypeBitmapGlyph glyph = new FreeTypeBitmapGlyph(face, Convert.ToChar(i), fontHeight);
                bool zeroSize = (glyph.obj.bitmap.rows == 0 && glyph.obj.bitmap.width == 0);
                bool zeroBuffer = glyph.obj.bitmap.buffer == IntPtr.Zero;
                if (zeroSize && (!zeroBuffer)) { throw new Exception(); }
                if ((!zeroSize) && zeroBuffer) { throw new Exception(); }
                if (zeroSize) { continue; }

                // Next we expand the bitmap into an opengl texture
                // 把glyph_bmp.bitmap的长宽扩展成2的指数倍
                int width = next_po2(glyph.obj.bitmap.width);
                int height = next_po2(glyph.obj.bitmap.rows);

                if (newRowWidth + width + 1 >= maxTextureWidth)
                {
                    widthOfTexture = Math.Max(widthOfTexture, newRowWidth);
                    heightOfTexture += newRowHeight;
                    newRowWidth = 0;
                    newRowHeight = 0;
                }

                newRowWidth += width + 1;
                newRowHeight = Math.Max(newRowHeight, height);
            }

            widthOfTexture = Math.Max(widthOfTexture, newRowWidth);
            heightOfTexture += newRowHeight;
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

            int coord = shaderProgram.GetAttributeLocation("coord");
            if (coord >= 0) { this.coordLocation = (uint)coord; }
            else { throw new Exception(); }

            this.transformMatrixLocation = shaderProgram.GetUniformLocation("transformMatrix");
            //this.transformMatrixLocation = GL.GetUniformLocation(shaderProgram.ShaderProgramObject, "transformMatrix");
            if (this.transformMatrixLocation < 0) { throw new Exception(); }

            this.colorLocation = shaderProgram.GetUniformLocation("color");
            if (this.colorLocation < 0) { throw new Exception(); }

            this.texLocation = GL.GetUniformLocation(shaderProgram.ShaderProgramObject, "tex");
            if (this.texLocation < 0) { throw new Exception(); }

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

            shaderProgram.SetUniform1("tex", texture[0]);

            mat4 projectionMatrix = this.camera.GetProjectionMat4();
            mat4 viewMatrix = this.camera.GetViewMat4();
            mat4 matrix = projectionMatrix * viewMatrix;
            shader.SetUniformMatrix4("transformMatrix", matrix.to_array());

            const float scale = 3.5f;
            rotation += 0.1f;
            mat4 transformMatrix = glm.translate(mat4.identity(), new vec3(0, -2, 0));
            transformMatrix = glm.rotate(transformMatrix, rotation, new vec3(0, 1, 0));
            transformMatrix = glm.scale(transformMatrix, new vec3(scale, scale, scale));
            //shader.SetUniformMatrix4("transformMatrix", transformMatrix.to_array());

            GL.Uniform1(this.texLocation, this.texture[0]);
            //GL.Uniform4(this.colorLocation, 1.0f, 1.0f, 1.0f, 1.0f);
            GL.Uniform4(this.colorLocation, (float)random.NextDouble(), (float)random.NextDouble(), (float)random.NextDouble(), (float)random.NextDouble());

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

        float rotation = 0.0f;
        public bool blend;
        static Random random = new Random();
        private string fontFilename;
        private int fontHeight;
    }

}
