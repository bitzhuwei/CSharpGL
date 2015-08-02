using CSharpGL.Maths;
using CSharpGL.Objects;
using CSharpGL.Objects.Shaders;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Winforms.Demo
{
    class ShaderVBOTextureElementDemo : VAOElement
    {
        uint[] texture = new uint[1];

        //  Constants that specify the attribute indexes.
        internal uint coordLocation;
        internal int colorLocation;
        internal int texLocation;
        private ShaderProgram shaderProgram;

        private PrimitiveMode mode;
        private uint[] vao;
        private int primitiveCount;
        private int width;
        private int height;

        protected override void DoInitialize()
        {
            InitTexture();

            InitShaderProgram();

            InitVAO();
        }

        private void InitVAO()
        {
            mode = PrimitiveMode.Quads;
            primitiveCount = 4;

            vao = new uint[1];
            GL.GenVertexArrays(1, vao);
            GL.BindVertexArray(vao[0]);

            UnmanagedArray<vec4> coord = new UnmanagedArray<vec4>(4);
            coord[0] = new vec4(0, 0, 0, height);
            coord[1] = new vec4(0, 1, 0, 0);
            coord[2] = new vec4(1, 1, width, 0);
            coord[3] = new vec4(1, 0, width, height);

            //  Create a vertex buffer for the vertex data.
            {
                uint[] ids = new uint[1];
                GL.GenBuffers(1, ids);
                GL.BindBuffer(GL.GL_ARRAY_BUFFER, ids[0]);

                GL.BufferData(BufferTarget.ArrayBuffer, coord, BufferUsage.StaticDraw);
                GL.VertexAttribPointer(coordLocation, 3, GL.GL_FLOAT, false, 0, IntPtr.Zero);
                GL.EnableVertexAttribArray(coordLocation);
            }

            //  Unbind the vertex array, we've finished specifying data for it.
            GL.BindVertexArray(0);
        }

        private void InitTexture()
        {
            System.Drawing.Bitmap image = ManifestResourceLoader.LoadBitmap("64.bmp");

            //	Get the maximum texture size supported by GL.
            int[] textureMaxSize = { 0 };
            GL.GetInteger(GetTarget.MaxTextureSize, textureMaxSize);

            //	Find the target width and height sizes, which is just the highest
            //	posible power of two that'll fit into the image.
            int targetWidth = textureMaxSize[0];
            int targetHeight = textureMaxSize[0];

            for (int size = 1; size <= textureMaxSize[0]; size *= 2)
            {
                if (image.Width < size)
                {
                    targetWidth = size / 2;
                    break;
                }
                if (image.Width == size)
                    targetWidth = size;
            }

            for (int size = 1; size <= textureMaxSize[0]; size *= 2)
            {
                if (image.Height < size)
                {
                    targetHeight = size / 2;
                    break;
                }
                if (image.Height == size)
                    targetHeight = size;
            }

            //  If need to scale, do so now.
            if (image.Width != targetWidth || image.Height != targetHeight)
            {
                //  Resize the image.
                Image newImage = image.GetThumbnailImage(targetWidth, targetHeight, null, IntPtr.Zero);

                //  Destory the old image, and reset.
                image.Dispose();
                image = (Bitmap)newImage;
            }

            /* Create a texture that will be used to hold all ASCII glyphs */
            GL.ActiveTexture(GL.GL_TEXTURE0);
            GL.GenTextures(1, texture);
            GL.BindTexture(GL.GL_TEXTURE_2D, texture[0]);

            this.width = image.Width;
            this.height = image.Height;

            //  Lock the image bits (so that we can pass them to OGL).
            BitmapData bitmapData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height),
                ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            //	Bind our texture object (make it the current texture).
            GL.BindTexture(GL.GL_TEXTURE_2D, texture[0]);

            //  Set the image data.
            GL.TexImage2D(GL.GL_TEXTURE_2D, 0, (int)GL.GL_RGBA,
                targetWidth, targetHeight, 0, GL.GL_BGRA, GL.GL_UNSIGNED_BYTE,
                bitmapData.Scan0);

            //  Unlock the image.
            image.UnlockBits(bitmapData);

            /* Clamping to edges is important to prevent artifacts when scaling */
            GL.TexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_WRAP_S, (int)GL.GL_CLAMP_TO_EDGE);
            GL.TexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_WRAP_T, (int)GL.GL_CLAMP_TO_EDGE);

            /* Linear filtering usually looks best for text */
            GL.TexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MIN_FILTER, (int)GL.GL_LINEAR);
            GL.TexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MAG_FILTER, (int)GL.GL_LINEAR);
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

            ShaderProgram shader = this.shaderProgram;

            shader.Bind();

            GL.Uniform1(this.texLocation, this.texture[0]);
            GL.Uniform4(this.colorLocation, 1.0f, 1.0f, 1.0f, 1.0f);

            GL.BindVertexArray(vao[0]);
            GL.DrawArrays(this.mode, 0, this.primitiveCount);
            GL.BindVertexArray(0);

            shader.Unbind();
            GL.BindTexture(GL.GL_TEXTURE_2D, 0);
        }
    }
}
