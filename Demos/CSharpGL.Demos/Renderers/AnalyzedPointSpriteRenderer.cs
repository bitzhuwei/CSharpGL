using System;
using System.Drawing;
using System.IO;

namespace CSharpGL.Demos
{
    internal class AnalyzedPointSpriteRenderer : Renderer
    {

        public static AnalyzedPointSpriteRenderer Create(int particleCount)
        {
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\AnalyzedPointSprite.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\AnalyzedPointSprite.frag"), ShaderType.FragmentShader);
            var map = new PropertyNameMap();
            map.Add("position", "position");
            var model = new BillboardModel(particleCount);
            var renderer = new AnalyzedPointSpriteRenderer(model, shaderCodes, map, new PointSpriteSwitch());
            renderer.Lengths = model.Lengths;

            return renderer;
        }

        private AnalyzedPointSpriteRenderer(
            IBufferable bufferable, ShaderCode[] shaderCodes,
            PropertyNameMap propertyNameMap, params GLSwitch[] switches)
            : base(bufferable, shaderCodes, propertyNameMap, switches)
        {
        }

        protected override void DoInitialize()
        {
            base.DoInitialize();

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

        private class BillboardModel : IBufferable
        {
            public BillboardModel(int particleCount)
            {
                this.particleCount = particleCount;
            }

            public const string strPosition = "position";
            private VertexAttributeBufferPtr positionBufferPtr = null;
            private IndexBufferPtr indexBufferPtr;
            private int particleCount;
            private Random random = new Random();
            private const float a = 5, b = 4, c = 3;

            public VertexAttributeBufferPtr GetProperty(string bufferName, string varNameInShader)
            {
                if (bufferName == strPosition)
                {
                    if (positionBufferPtr == null)
                    {
                        using (var buffer = new VertexAttributeBuffer<vec3>(
                            varNameInShader, 3, OpenGL.GL_FLOAT, BufferUsage.StaticDraw))
                        {
                            buffer.Create(particleCount);
                            unsafe
                            {
                                var array = (vec3*)buffer.Header.ToPointer();
                                for (int i = 0; i < particleCount; i++)
                                {
                                    double beta = random.NextDouble() * Math.PI;
                                    double theta = random.NextDouble() * Math.PI * 2;
                                    float x = (float)(a * Math.Sin(beta) * Math.Cos(theta));
                                    float y = (float)(b * Math.Sin(beta) * Math.Sin(theta));
                                    float z = (float)(c * Math.Cos(beta));
                                    array[i] = new vec3(x, y, z);
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
            /// Uses <see cref="ZeroIndexBufferPtr"/> or <see cref="OneIndexBufferPtr"/>.
            /// </summary>
            /// <returns></returns>
            public bool UsesZeroIndexBufferPtr() { return true; }

            public vec3 Lengths { get { return new vec3(a, b, c) * 2; } }
        }
    }
}