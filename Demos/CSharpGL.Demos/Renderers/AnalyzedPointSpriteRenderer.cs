using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;


namespace CSharpGL.Demos
{

    class AnalyzedPointSpriteRenderer : Renderer
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

        public static AnalyzedPointSpriteRenderer Create(int particleCount)
        {
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\AnalyzedPointSprite.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\AnalyzedPointSprite.frag"), ShaderType.FragmentShader);
            var map = new PropertyNameMap();
            map.Add("position", "position");
            var model = new BillboardModel(particleCount);
            var renderer = new AnalyzedPointSpriteRenderer(model, shaderCodes, map, new PointSpriteSwitch());
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

        class BillboardModel : IBufferable
        {

            public BillboardModel(int particleCount)
            {
                this.particleCount = particleCount;
            }
            public const string strPosition = "position";
            private PropertyBufferPtr positionBufferPtr = null;
            private IndexBufferPtr indexBufferPtr;
            private int particleCount;
            private Random random = new Random();
            private const float a = 5, b = 4, c = 3;
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
                                    double beta = random.NextDouble() * Math.PI;
                                    double theta = random.NextDouble() * Math.PI * 2;
                                    float x = (float)(a * Math.Sin(beta) * Math.Cos(theta));
                                    float y = (float)(b * Math.Sin(beta) * Math.Sin(theta));
                                    float z = (float)(c * Math.Cos(beta));
                                    array[i] = new vec3(x, y, z);
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

    }
}