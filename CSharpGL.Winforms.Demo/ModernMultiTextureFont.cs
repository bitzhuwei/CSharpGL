using CSharpGL.Maths;
using CSharpGL.Objects;
using CSharpGL.Objects.Cameras;
using CSharpGL.Objects.Shaders;
using CSharpGL.Objects.Texts.FreeTypes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Winforms.Demo
{
    class ModernMultiTextureFont : VAOElement
    {
        ScientificCamera camera;

        public ModernMultiTextureFont(ScientificCamera camera)
        {
            this.camera = camera;
        }

        uint[] texture = new uint[1];

        //  Constants that specify the attribute indexes.
        internal uint coordLocation;
        internal int transformMatrixLocation;
        internal int colorLocation;
        internal int texLocation;
        private ShaderProgram shaderProgram;

        private PrimitiveModes mode;
        private uint[] vao;
        private int vertexCount;
        private int textureWidth;
        private int textureHeight;

        protected override void DoInitialize()
        {
            InitTexture();

            InitShaderProgram();

            InitVAO();
        }

        private void InitVAO()
        {
            this.mode = PrimitiveModes.Quads;
            this.vertexCount = 4;

            vao = new uint[1];
            GL.GenVertexArrays(1, vao);
            GL.BindVertexArray(vao[0]);

            UnmanagedArray<vec4> coord = new UnmanagedArray<vec4>(this.vertexCount);
            coord[0] = new vec4(0, 0, 0, 1);
            coord[1] = new vec4(0, textureHeight, 0, 0);
            coord[2] = new vec4(textureWidth, textureHeight, 1, 0);
            coord[3] = new vec4(textureWidth, 0, 1, 1);

            //  Create a vertex buffer for the vertex data.
            {
                uint[] ids = new uint[1];
                GL.GenBuffers(1, ids);
                GL.BindBuffer(GL.GL_ARRAY_BUFFER, ids[0]);

                GL.BufferData(BufferTarget.ArrayBuffer, coord, BufferUsage.StaticDraw);
                GL.VertexAttribPointer(coordLocation, 4, GL.GL_FLOAT, false, 0, IntPtr.Zero);
                GL.EnableVertexAttribArray(coordLocation);
            }

            //  Unbind the vertex array, we've finished specifying data for it.
            GL.BindVertexArray(0);
        }

        private void InitTexture()
        {
            // We begin by creating a library pointer
            // 初始化FreeType库：创建FreeType库指针
            FreeTypeLibrary library = new FreeTypeLibrary();

            // Once we have the library we create and load the font face
            // 初始化字体库
            FreeTypeFace face = new FreeTypeFace(library, "LuckiestGuy.ttf");

            int fontHeight = 48;
            int c = (int)'@';
            //int c = (int)'&';

            // 把字形转换为纹理
            FreeTypeBitmapGlyph bmpGlyph = new FreeTypeBitmapGlyph(face, Convert.ToChar(c), fontHeight);
            int size = (bmpGlyph.obj.bitmap.width * bmpGlyph.obj.bitmap.rows);
            if (size <= 0) { throw new Exception(); }

            byte[] bmp = new byte[size];
            Marshal.Copy(bmpGlyph.obj.bitmap.buffer, bmp, 0, bmp.Length);

            // Next we expand the bitmap into an opengl texture
            // 把glyph_bmp.bitmap的长宽扩展成2的指数倍
            this.textureWidth = next_po2(bmpGlyph.obj.bitmap.width);
            this.textureHeight = next_po2(bmpGlyph.obj.bitmap.rows);
            this.modelWidth = (float)bmpGlyph.obj.bitmap.width / (float)this.textureWidth;
            this.modelHeight = (float)bmpGlyph.obj.bitmap.rows / (float)this.textureHeight;

            UnmanagedArray<byte> expanded = new UnmanagedArray<byte>(2 * textureWidth * textureHeight);
            for (int j = 0; j < textureHeight; j++)
            {
                for (int i = 0; i < textureWidth; i++)
                {
                    expanded[2 * (i + j * textureWidth)] = expanded[2 * (i + j * textureWidth) + 1] =
                        (i >= bmpGlyph.obj.bitmap.width || j >= bmpGlyph.obj.bitmap.rows) ?
                        (byte)0 : bmp[i + bmpGlyph.obj.bitmap.width * j];
                }
            }

            // Set up some texture parameters for opengl
            // 指定OpenGL的纹理参数
            //    /* Create a texture that will be used to hold all ASCII glyphs */
            //GL.ActiveTexture(GL.GL_TEXTURE0);
            GL.GenTextures(1, texture);
            GL.BindTexture(GL.GL_TEXTURE_2D, texture[0]);

            GL.TexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MAG_FILTER, (int)GL.GL_LINEAR);
            GL.TexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MIN_FILTER, (int)GL.GL_LINEAR);

            // Create the texture
            // 创建纹理
            GL.TexImage2D(GL.GL_TEXTURE_2D, 0, GL.GL_RGBA, textureWidth, textureHeight,
                0, GL.GL_LUMINANCE_ALPHA, GL.GL_UNSIGNED_BYTE, expanded.Header);
            {
                //  Create the bitmap.
                System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(
                    textureWidth / 2,
                    bmpGlyph.obj.bitmap.rows,
                    textureWidth * 4 / 2,
                    System.Drawing.Imaging.PixelFormat.Format32bppRgb,
                    expanded.Header);
                bitmap.Save(string.Format("ModernMultiTextureFont{0}.bmp", c));
                bitmap.Dispose();
            }
            expanded = null;
            bmp = null;

            /* Clamping to edges is important to prevent artifacts when scaling */
            GL.TexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_WRAP_S, (int)GL.GL_CLAMP_TO_EDGE);
            GL.TexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_WRAP_T, (int)GL.GL_CLAMP_TO_EDGE);

            /* Linear filtering usually looks best for text */
            GL.TexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MIN_FILTER, (int)GL.GL_LINEAR);
            GL.TexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MAG_FILTER, (int)GL.GL_LINEAR);

            face.Dispose();
            library.Dispose();
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
            var vertexShaderSource = ManifestResourceLoader.LoadTextFile(@"freetype.vert");
            var fragmentShaderSource = ManifestResourceLoader.LoadTextFile(@"freetype.frag");
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
        private float modelWidth;
        private float modelHeight;
        static Random random = new Random();
    }
}
