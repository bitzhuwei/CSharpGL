using CSharpGL.Maths;
using CSharpGL.Objects.Shaders;
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
    /// 这是一个使用point sprite进行渲染的简单的例子。
    /// </summary>
    public class SimplePointSpriteElement : SceneElementBase, IDisposable
    {

        /// <summary>
        /// 这是一个使用point sprite进行渲染的简单的例子。
        /// </summary>
        /// <param name="pointSize"></param>
        /// <param name="foreshortening">是否启用近大远小</param>
        public SimplePointSpriteElement(float pointSize = 64.0f, bool foreshortening = true, FragShaderType fragShaderType = FragShaderType.Simple)
        {
            this.PointSize = pointSize;
            this.Foreshortening = foreshortening;
            this.fragShaderType = fragShaderType;
        }

        /// <summary>
        /// shader program
        /// </summary>
        public ShaderProgram shaderProgram;
        const string strin_Position = "in_Position";
        public const string strprojectionMatrix = "projectionMatrix";
        public const string strviewMatrix = "viewMatrix";
        public const string strmodelMatrix = "modelMatrix";
        public const string strtex = "tex";
        public const string strpointSize = "pointSize";
        public const string strforeshortening = "foreshortening";

        /// <summary>
        /// VAO
        /// </summary>
        protected uint[] vao;
        public uint[] texture = new uint[1];

        /// <summary>
        /// 图元类型
        /// </summary>
        protected PrimitiveModes primitiveMode;

        /// <summary>
        /// 顶点数
        /// </summary>
        protected int vertexCount;

        protected void InitializeShader(out ShaderProgram shaderProgram)
        {
            var vertexShaderSource = ManifestResourceLoader.LoadTextFile(@"SceneElements.SimplePointSpriteElement.vert");
            string fragmentShaderSource = string.Empty;
            switch (this.fragShaderType)
            {
                case FragShaderType.Simple:
                    fragmentShaderSource = ManifestResourceLoader.LoadTextFile(
                        @"SceneElements.SimplePointSpriteElement_Simple.frag");
                    break;
                case FragShaderType.Analytic:
                    fragmentShaderSource = ManifestResourceLoader.LoadTextFile(
                        @"SceneElements.SimplePointSpriteElement_Analytic.frag");
                    break;
                default:
                    throw new NotImplementedException();
            }

            shaderProgram = new ShaderProgram();
            shaderProgram.Create(vertexShaderSource, fragmentShaderSource, null);

            shaderProgram.AssertValid();
        }

        static Random random = new Random();

        protected void InitializeVAO()
        {
            this.primitiveMode = PrimitiveModes.Points;
            const int axisCount = 3;
            const int count = axisCount * axisCount * axisCount;
            this.vertexCount = count;

            this.vao = new uint[1];

            GL.GenVertexArrays(4, vao);

            GL.BindVertexArray(vao[0]);

            //  Create a vertex buffer for the vertex data.
            {
                UnmanagedArray<vec3> positionArray = new UnmanagedArray<vec3>(count);
                for (int i = 0, index = 0; i < axisCount; i++)
                {
                    for (int j = 0; j < axisCount; j++)
                    {
                        for (int k = 0; k < axisCount; k++)
                        {
                            //positionArray[index++] = 10 * new vec3(i - axisCount / 2, j - axisCount / 2, k - axisCount / 2);
                            positionArray[index++] = 10 * new vec3((float)random.NextDouble() - 0.5f, (float)random.NextDouble() - 0.5f, (float)random.NextDouble() - 0.5f);
                        }
                    }
                }

                uint positionLocation = shaderProgram.GetAttributeLocation(strin_Position);

                uint[] ids = new uint[1];
                GL.GenBuffers(1, ids);
                GL.BindBuffer(BufferTarget.ArrayBuffer, ids[0]);
                GL.BufferData(BufferTarget.ArrayBuffer, positionArray, BufferUsage.StaticDraw);
                GL.VertexAttribPointer(positionLocation, 3, GL.GL_FLOAT, false, 0, IntPtr.Zero);
                GL.EnableVertexAttribArray(positionLocation);

                positionArray.Dispose();
            }

            //  Unbind the vertex array, we've finished specifying data for it.
            GL.BindVertexArray(0);
        }

        protected override void DoInitialize()
        {
            InitTexture();

            InitializeShader(out shaderProgram);

            InitializeVAO();

            base.BeforeRendering += SimplePointSpriteElement_BeforeRendering;
            base.AfterRendering += SimplePointSpriteElement_AfterRendering;
        }

        void SimplePointSpriteElement_AfterRendering(object sender, RenderEventArgs e)
        {
            this.shaderProgram.Unbind();

            GL.BindTexture(GL.GL_TEXTURE_2D, 0);

            GL.Disable(GL.GL_BLEND);
            GL.Disable(GL.GL_VERTEX_PROGRAM_POINT_SIZE);
            GL.Disable(GL.GL_POINT_SPRITE_ARB);
            GL.Disable(GL.GL_POINT_SMOOTH);
        }

        void SimplePointSpriteElement_BeforeRendering(object sender, RenderEventArgs e)
        {
            GL.Enable(GL.GL_VERTEX_PROGRAM_POINT_SIZE);
            GL.Enable(GL.GL_POINT_SPRITE_ARB);
            //GL.TexEnv(GL.GL_POINT_SPRITE_ARB, GL.GL_COORD_REPLACE_ARB, GL.GL_TRUE);//TODO: test TexEnvi()
            GL.TexEnvf(GL.GL_POINT_SPRITE_ARB, GL.GL_COORD_REPLACE_ARB, GL.GL_TRUE);
            //GL.Enable(GL.GL_POINT_SMOOTH);
            //GL.Hint(GL.GL_POINT_SMOOTH_HINT, GL.GL_NICEST);
            GL.Enable(GL.GL_BLEND);
            GL.BlendEquation(GL.GL_FUNC_ADD_EXT);
            GL.BlendFuncSeparate(GL.GL_SRC_ALPHA, GL.GL_ONE_MINUS_SRC_ALPHA, GL.GL_ONE, GL.GL_ONE);

            GL.BindTexture(GL.GL_TEXTURE_2D, this.texture[0]);

            this.shaderProgram.Bind();
            shaderProgram.SetUniform(strtex, this.texture[0]);
            shaderProgram.SetUniform(strpointSize, this.PointSize);
            shaderProgram.SetUniform(strforeshortening, (this.Foreshortening ? 1.0f : 0.0f));
        }

        private void InitTexture()
        {
            System.Drawing.Bitmap contentBitmap = ManifestResourceLoader.LoadBitmap("SceneElements.SimplePointSpriteElement.png");

            // step 4: get texture's size 
            int targetTextureWidth;
            {

                //	Get the maximum texture size supported by OpenGL.
                int[] textureMaxSize = { 0 };
                GL.GetInteger(GetTarget.MaxTextureSize, textureMaxSize);

                //	Find the target width and height sizes, which is just the highest
                //	posible power of two that'll fit into the image.

                targetTextureWidth = textureMaxSize[0];

                int scaledWidth = contentBitmap.Width;

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
            }

            // step 5: scale contentBitmap to right size
            System.Drawing.Bitmap targetImage = contentBitmap;
            if (contentBitmap.Width != targetTextureWidth || contentBitmap.Height != targetTextureWidth)
            {
                //  Resize the image.
                targetImage = (System.Drawing.Bitmap)contentBitmap.GetThumbnailImage(targetTextureWidth, targetTextureWidth, null, IntPtr.Zero);
            }

            // step 6: generate texture
            {
                //  Lock the image bits (so that we can pass them to OGL).
                BitmapData bitmapData = targetImage.LockBits(new Rectangle(0, 0, targetImage.Width, targetImage.Height),
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

        protected override void DoRender(RenderModes renderMode)
        {
            GL.BindVertexArray(vao[0]);

            GL.DrawArrays(primitiveMode, 0, this.vertexCount);

            GL.BindVertexArray(0);
        }


        #region IDisposable Members

        /// <summary>
        /// Internal variable which checks if Dispose has already been called
        /// </summary>
        protected Boolean disposed;
        private FragShaderType fragShaderType;

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
            if (vao != null)
            {
                GL.DeleteVertexArrays(vao.Length, vao);
                vao = null;
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

        public float PointSize { get; set; }

        public bool Foreshortening { get; set; }
    }

    public enum FragShaderType
    {
        Simple,
        Analytic,
    }
}
