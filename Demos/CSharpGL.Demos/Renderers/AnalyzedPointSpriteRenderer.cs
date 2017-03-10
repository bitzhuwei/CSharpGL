using System;
using System.IO;

namespace CSharpGL.Demos
{
    [DemoRenderer]
    internal class AnalyzedPointSpriteRenderer : Renderer
    {
        public static AnalyzedPointSpriteRenderer Create(int particleCount)
        {
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\AnalyzedPointSprite.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\AnalyzedPointSprite.frag"), ShaderType.FragmentShader);
            var provider = new ShaderCodeArray(shaderCodes);
            var map = new AttributeMap();
            map.Add("position", "position");
            var model = new AnalyzedPointSpriteModel(particleCount);
            var renderer = new AnalyzedPointSpriteRenderer(model, provider, map, new PointSpriteState());
            renderer.ModelSize = model.Lengths;

            return renderer;
        }

        private AnalyzedPointSpriteRenderer(
            IBufferable model, IShaderProgramProvider shaderProgramProvider,
            AttributeMap attributeMap, params GLState[] switches)
            : base(model, shaderProgramProvider, attributeMap, switches)
        {
        }

        protected override void DoInitialize()
        {
            base.DoInitialize();

            this.SetUniform("factor", 100.0f);
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            mat4 projection = arg.Camera.GetProjectionMatrix();
            mat4 view = arg.Camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix().Value;
            this.SetUniform("mvp", projection * view * model);

            base.DoRender(arg);
        }

        private class AnalyzedPointSpriteModel : IBufferable
        {
            public AnalyzedPointSpriteModel(int particleCount)
            {
                this.particleCount = particleCount;
            }

            public const string strPosition = "position";
            private VertexBuffer positionBuffer = null;
            private IndexBuffer indexBuffer;
            private int particleCount;
            private Random random = new Random();
            private const float a = 5, b = 4, c = 3;

            public VertexBuffer GetVertexAttributeBuffer(string bufferName, string varNameInShader)
            {
                if (bufferName == strPosition)
                {
                    if (this.positionBuffer == null)
                    {
                        int length = particleCount;
                        VertexBuffer buffer = VertexBuffer.Create(typeof(vec3), length, VBOConfig.Vec3, varNameInShader, BufferUsage.StaticDraw);
                        unsafe
                        {
                            IntPtr pointer = buffer.MapBuffer(MapBufferAccess.WriteOnly);
                            var array = (vec3*)pointer;
                            for (int i = 0; i < particleCount; i++)
                            {
                                double beta = random.NextDouble() * Math.PI;
                                double theta = random.NextDouble() * Math.PI * 2;
                                float x = (float)(a * Math.Sin(beta) * Math.Cos(theta));
                                float y = (float)(b * Math.Sin(beta) * Math.Sin(theta));
                                float z = (float)(c * Math.Cos(beta));
                                array[i] = new vec3(x, y, z);
                            }
                            buffer.UnmapBuffer();
                        }

                        this.positionBuffer = buffer;
                    }

                    return this.positionBuffer;
                }
                else
                {
                    throw new ArgumentException();
                }
            }

            public IndexBuffer GetIndexBuffer()
            {
                if (this.indexBuffer == null)
                {
                    ZeroIndexBuffer buffer = ZeroIndexBuffer.Create(DrawMode.Points, 0, particleCount);
                    this.indexBuffer = buffer;
                }

                return indexBuffer;
            }

            /// <summary>
            /// Uses <see cref="ZeroIndexBuffer"/> or <see cref="OneIndexBuffer"/>.
            /// </summary>
            /// <returns></returns>
            public bool UsesZeroIndexBuffer() { return true; }

            public vec3 Lengths { get { return new vec3(a, b, c) * 2; } }
        }
    }
}