using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.EarthMoonSystem
{

    class BackgroundStarsRenderer : Renderer
    {

        private uint[] sprite_texture = new uint[1];
        static ShaderCode[] staticShaderCodes;
        static PropertyNameMap map;
        static BackgroundStarsRenderer()
        {
            staticShaderCodes = new ShaderCode[2];
            staticShaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\PointSprite.vert"), ShaderType.VertexShader);
            staticShaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\PointSprite.frag"), ShaderType.FragmentShader);
            map = new PropertyNameMap();
            map.Add("position", "position");
        }
        public BackgroundStarsRenderer(int particleCount, double backgroundRadius)
            : base(new PointSpriteModel(particleCount, backgroundRadius), staticShaderCodes, map)
        {
            this.SwitchList.Add(new PointSpriteSwitch());
        }

        protected override void DoInitialize()
        {
            {
                // This is the texture that the compute program will write into
                sampler2D texture = new sampler2D();
                var bitmap = new System.Drawing.Bitmap(@"Images\star1.png");
                texture.Initialize(bitmap);
                bitmap.Dispose();
                this.sprite_texture[0] = texture.Id;
            }
            base.DoInitialize();
            this.SetUniform("sprite_texture", new samplerValue(
                  BindTextureTarget.Texture2D, this.sprite_texture[0], OpenGL.GL_TEXTURE0));
            this.SetUniform("factor", 20000.0f);
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            mat4 model = mat4.identity();
            mat4 view = arg.Camera.GetViewMat4();
            mat4 projection = arg.Camera.GetProjectionMat4();
            this.SetUniform("mvp", projection * view * model);

            base.DoRender(arg);

            // 把所有在此之前渲染的内容都推到最远。
            OpenGL.Clear(OpenGL.GL_DEPTH_BUFFER_BIT);
        }

        protected override void DisposeUnmanagedResources()
        {
            OpenGL.DeleteTextures(1, sprite_texture);
        }

        class PointSpriteModel : IBufferable
        {

            public PointSpriteModel(int particleCount, double backgroundRadius)
            {
                this.particleCount = particleCount;
                this.backgroundRadius = backgroundRadius;
            }
            public const string strPosition = "position";
            private PropertyBufferPtr positionBufferPtr = null;
            private IndexBufferPtr indexBufferPtr;
            private int particleCount;
            private Random random = new Random();
            private double backgroundRadius;

            public PropertyBufferPtr GetProperty(string bufferName, string varNameInShader)
            {
                if (bufferName == strPosition)
                {
                    if (positionBufferPtr == null)
                    {
                        using (var buffer = new PropertyBuffer<vec3>(
                            varNameInShader, 3, OpenGL.GL_FLOAT, BufferUsage.StaticDraw))
                        {
                            buffer.Alloc(particleCount);
                            unsafe
                            {
                                var array = (vec3*)buffer.Header.ToPointer();
                                for (int i = 0; i < particleCount; i++)
                                {
                                    //if (i % 2 == 0)
                                    {
                                        array[i] = new vec3(
                                            (float)((random.NextDouble() * 2 - 1) * backgroundRadius),
                                            (float)((random.NextDouble() * 2 - 1) * backgroundRadius),
                                            (float)((random.NextDouble() * 2 - 1) * backgroundRadius));
                                    }
                                    //else
                                    //{
                                    //    double theta = random.NextDouble() * 2 * Math.PI - Math.PI;
                                    //    double alpha = random.NextDouble() * 2 * Math.PI - Math.PI;
                                    //    array[i] = new vec3(
                                    //        (float)(Math.Sin(theta) * Math.Cos(alpha)) * backgroundRadius,
                                    //        (float)(Math.Sin(theta) * Math.Sin(alpha)) * backgroundRadius,
                                    //        (float)(Math.Cos(theta)) * backgroundRadius);
                                    //}
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
            sampler2D texture = new sampler2D();
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