using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;


namespace CSharpGL.Demos
{

    class PointSpriteRenderer : Renderer
    {

        private Color clearColor = Color.Black;
        public Color ClearColor
        {
            get { return clearColor; }
            set
            {
                if (value != clearColor)
                {
                    clearColor = value;
                    OpenGL.ClearColor(value.R / 255.0f, value.G / 255.0f, value.B / 255.0f, value.A / 255.0f);
                }
            }
        }

        private uint[] sprite_texture = new uint[1];
        static ShaderCode[] staticShaderCodes;
        static PropertyNameMap map;
        static PointSpriteRenderer()
        {
            staticShaderCodes = new ShaderCode[2];
            staticShaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\PointSprite.vert"), ShaderType.VertexShader);
            staticShaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\PointSprite.frag"), ShaderType.FragmentShader);
            map = new PropertyNameMap();
            map.Add("position", "position");
        }
        public PointSpriteRenderer(int particleCount)
            : base(new PointSpriteModel(particleCount), staticShaderCodes, map)
        {
            this.SwitchList.Add(new PointSpriteSwitch());
        }

        protected override void DoInitialize()
        {
            {
                // This is the texture that the compute program will write into
                Texture2D texture = new Texture2D();
                var bitmap = new System.Drawing.Bitmap(@"Textures\PointSprite.png");
                texture.Initialize(bitmap);
                bitmap.Dispose();
                this.sprite_texture[0] = texture.Id;
            }
            base.DoInitialize();
            this.SetUniform("sprite_texture", new samplerValue(
                  BindTextureTarget.Texture2D, this.sprite_texture[0], OpenGL.GL_TEXTURE0));
            this.SetUniform("factor", 100.0f);
        }

        protected override void DoRender(RenderEventArg arg)
        {
            mat4 model = mat4.identity();
            mat4 view = arg.Camera.GetViewMat4();
            mat4 projection = arg.Camera.GetProjectionMat4();
            this.SetUniform("mvp", projection * view * model);

            base.DoRender(arg);
        }

        protected override void DisposeUnmanagedResources()
        {
            OpenGL.DeleteTextures(1, sprite_texture);
        }

        class PointSpriteModel : IBufferable
        {

            public PointSpriteModel(int particleCount)
            {
                this.particleCount = particleCount;
            }
            public const string strPosition = "position";
            private PropertyBufferPtr positionBufferPtr = null;
            private IndexBufferPtr indexBufferPtr;
            private int particleCount;
            private Random random = new Random();
            private float factor = 1;

            public PropertyBufferPtr GetProperty(string bufferName, string varNameInShader)
            {
                if (bufferName == strPosition)
                {
                    if (positionBufferPtr == null)
                    {
                        using (var buffer = new PropertyBuffer<vec3>(
                            varNameInShader, 3, OpenGL.GL_FLOAT, BufferUsage.StaticDraw))
                        {
                            buffer.Create(particleCount);
                            unsafe
                            {
                                var array = (vec3*)buffer.Header.ToPointer();
                                for (int i = 0; i < particleCount; i++)
                                {
                                    if (i % 2 == 0)
                                    {
                                        array[i] = new vec3(
                                            (float)(random.NextDouble() * 2 - 1) * factor,
                                            (float)(random.NextDouble() * 2 - 1) * factor,
                                            (float)(random.NextDouble() * 2 - 1) * factor);
                                    }
                                    else
                                    {
                                        double theta = random.NextDouble() * 2 * Math.PI - Math.PI;
                                        double alpha = random.NextDouble() * 2 * Math.PI - Math.PI;
                                        array[i] = new vec3(
                                            (float)(Math.Sin(theta) * Math.Cos(alpha)) * factor,
                                            (float)(Math.Sin(theta) * Math.Sin(alpha)) * factor,
                                            (float)(Math.Cos(theta)) * factor);
                                    }
                                }
                            }

                            positionBufferPtr = buffer.GetBufferPtr() as PropertyBufferPtr;
                        }
                    }

                    return positionBufferPtr;
                }
                else
                {
                    throw new ArgumentException();
                }
            }

            public IndexBufferPtr GetIndex()
            {
                if (indexBufferPtr == null)
                {
                    using (var buffer = new ZeroIndexBuffer(
                      DrawMode.Points, 0, particleCount))
                    {
                        indexBufferPtr = buffer.GetBufferPtr() as IndexBufferPtr;
                    }
                }

                return indexBufferPtr;
            }
        }

        internal void UpdateTexture(string filename)
        {
            // This is the texture that the compute program will write into
            Texture2D texture = new Texture2D();
            var bitmap = new System.Drawing.Bitmap(filename);
            texture.Initialize(bitmap);
            bitmap.Dispose();
            var old = new uint[1];
            old[0] = this.sprite_texture[0];
            this.sprite_texture[0] = texture.Id;
            this.SetUniform("sprite_texture", new samplerValue(
                BindTextureTarget.Texture2D, this.sprite_texture[0], OpenGL.GL_TEXTURE0));

            OpenGL.DeleteTextures(1, old);
        }
    }
}