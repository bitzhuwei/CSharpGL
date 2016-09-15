using System;
using System.IO;

namespace CSharpGL.Demos
{
    internal class PointSpriteRenderer : Renderer
    {
        private Texture spriteTexture;

        public static PointSpriteRenderer Create(int particleCount)
        {
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\PointSprite.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\PointSprite.frag"), ShaderType.FragmentShader);
            var map = new PropertyNameMap();
            map.Add("position", PointSpriteModel.strposition);
            var model = new PointSpriteModel(particleCount);
            var renderer = new PointSpriteRenderer(model, shaderCodes, map, new PointSpriteSwitch());
            renderer.Lengths = model.Lengths;

            return renderer;
        }

        public PointSpriteRenderer(IBufferable model, ShaderCode[] shaderCodes,
            PropertyNameMap propertyNameMap, params GLSwitch[] switches)
            : base(model, shaderCodes, propertyNameMap, switches)
        {
        }

        protected override void DoInitialize()
        {
            {
                // This is the texture that the compute program will write into
                var bitmap = new System.Drawing.Bitmap(@"Textures\PointSprite.png");
                var texture = new Texture(BindTextureTarget.Texture2D, bitmap, new SamplerParameters());
                texture.Initialize();
                bitmap.Dispose();
                this.spriteTexture = texture;
            }
            base.DoInitialize();
            this.SetUniform("spriteTexture", this.spriteTexture.ToSamplerValue());
            this.SetUniform("factor", 100.0f);
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            mat4 model = mat4.identity();
            mat4 view = arg.Camera.GetViewMatrix();
            mat4 projection = arg.Camera.GetProjectionMatrix();
            this.SetUniform("mvp", projection * view * model);

            base.DoRender(arg);
        }

        protected override void DisposeUnmanagedResources()
        {
            base.DisposeUnmanagedResources();

            this.spriteTexture.Dispose();
        }

        private class PointSpriteModel : IBufferable
        {
            public PointSpriteModel(int particleCount)
            {
                this.particleCount = particleCount;
            }

            public const string strposition = "position";
            private VertexAttributeBufferPtr positionBufferPtr = null;
            private IndexBufferPtr indexBufferPtr;
            private int particleCount;
            private Random random = new Random();
            private float factor = 1;

            public VertexAttributeBufferPtr GetProperty(string bufferName, string varNameInShader)
            {
                if (bufferName == strposition)
                {
                    if (positionBufferPtr == null)
                    {
                        using (var buffer = new VertexAttributeBuffer<vec3>(
                            varNameInShader, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw))
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

                            positionBufferPtr = buffer.GetBufferPtr() as VertexAttributeBufferPtr;
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
            /// <summary>
            /// UsesUses <see cref="ZeroIndexBuffer"/> or <see cref="OneIndexBuffer&lt;T&gt;"/>.
            /// </summary>
            /// <returns></returns>
            public bool UsesZeroIndexBuffer() { return true; }

            public vec3 Lengths { get { return new vec3(2, 2, 2); } }
        }

        internal void UpdateTexture(string filename)
        {
            // This is the texture that the compute program will write into
            var bitmap = new System.Drawing.Bitmap(filename);
            var texture = new Texture(BindTextureTarget.Texture2D, bitmap, new SamplerParameters());
            texture.Initialize();
            bitmap.Dispose();
            Texture old = this.spriteTexture;
            this.spriteTexture = texture;
            this.SetUniform("sprite_texture", texture.ToSamplerValue());

            old.Dispose();
        }
    }
}