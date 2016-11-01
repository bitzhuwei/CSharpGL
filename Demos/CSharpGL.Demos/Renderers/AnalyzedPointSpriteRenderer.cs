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
            var map = new AttributeMap();
            map.Add("position", "position");
            var model = new AnalyzedPointSpriteModel(particleCount);
            var renderer = new AnalyzedPointSpriteRenderer(model, shaderCodes, map, new PointSpriteSwitch());
            renderer.ModelSize = model.Lengths;

            return renderer;
        }

        private AnalyzedPointSpriteRenderer(
            IBufferable model, ShaderCode[] shaderCodes,
            AttributeMap attributeMap, params GLSwitch[] switches)
            : base(model, shaderCodes, attributeMap, switches)
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
            private VertexAttributeBufferPtr positionBufferPtr = null;
            private IndexBufferPtr indexBufferPtr;
            private int particleCount;
            private Random random = new Random();
            private const float a = 5, b = 4, c = 3;

            public VertexAttributeBufferPtr GetVertexAttributeBufferPtr(string bufferName, string varNameInShader)
            {
                if (bufferName == strPosition)
                {
                    if (this.positionBufferPtr == null)
                    {
                        int length = particleCount;
                        VertexAttributeBufferPtr bufferPtr = VertexAttributeBufferPtr.Create(typeof(vec3), length, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw, varNameInShader);
                        unsafe
                        {
                            IntPtr pointer = bufferPtr.MapBuffer(MapBufferAccess.WriteOnly);
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
                            bufferPtr.UnmapBuffer();
                        }

                        this.positionBufferPtr = bufferPtr;
                    }

                    return this.positionBufferPtr;
                }
                else
                {
                    throw new ArgumentException();
                }
            }

            public IndexBufferPtr GetIndexBufferPtr()
            {
                if (this.indexBufferPtr == null)
                {
                    ZeroIndexBufferPtr bufferPtr = ZeroIndexBufferPtr.Create(DrawMode.Points, 0, particleCount);
                    this.indexBufferPtr = bufferPtr;
                }

                return indexBufferPtr;
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