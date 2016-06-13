using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

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

        static ShaderCode[] staticShaderCodes;
        static PropertyNameMap map;
        static AnalyzedPointSpriteRenderer()
        {
            staticShaderCodes = new ShaderCode[2];
            staticShaderCodes[0] = new ShaderCode(File.ReadAllText(@"08AnalyzedPointSprite\AnalyzedPointSprite.vert"), ShaderType.VertexShader);
            staticShaderCodes[1] = new ShaderCode(File.ReadAllText(@"08AnalyzedPointSprite\AnalyzedPointSprite.frag"), ShaderType.FragmentShader);
            map = new PropertyNameMap();
            map.Add("position", "position");
        }
        public AnalyzedPointSpriteRenderer(int particleCount)
            : base(new BillboardModel(particleCount), staticShaderCodes, map)
        {
            this.SwitchList.Add(new PointSpriteSwitch());
        }

        protected override void DoInitialize()
        {
            base.DoInitialize();

            this.SetUniform("factor", 100.0f);
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            mat4 model = mat4.identity();
            mat4 view = arg.Camera.GetViewMat4();
            mat4 projection = arg.Camera.GetProjectionMat4();
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
            private float factor = 1;
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
                            buffer.Alloc(particleCount);
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