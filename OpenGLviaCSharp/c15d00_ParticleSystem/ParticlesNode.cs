using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c15d00_ParticleSystem
{
    partial class ParticlesNode : ModernNode, IRenderable
    {
        private ShaderProgram computeProgram;
        private Texture texPosition;
        private Texture texVelocity;
        public static ParticlesNode Create(int groupCount)
        {
            var model = new ParticlesModel(groupCount * 128);
            var vs = new VertexShader(renderVert);
            var gs = new GeometryShader(renderGeom);
            var fs = new FragmentShader(renderFrag);
            var array = new ShaderArray(vs, gs, fs);
            var map = new AttributeMap();
            map.Add("inPosition", ParticlesModel.strPosition);
            var builder = new RenderMethodBuilder(array, map,
                new BlendSwitch(BlendEquationMode.Add, BlendSrcFactor.One, BlendDestFactor.One)

                );
            var node = new ParticlesNode(model, builder);
            node.groupCount = groupCount;
            node.Initialize();

            return node;
        }

        private ParticlesNode(IBufferSource model, params RenderMethodBuilder[] builders) : base(model, builders) { }

        const int attractorCount = 64;
        private vec4[] attractors = new vec4[attractorCount];

        public vec4[] Attractors
        {
            get { return attractors; }
            set { attractors = value; }
        }

        protected override void DoInitialize()
        {
            base.DoInitialize();
            {
                var shader = new ComputeShader(computeCode);
                var array = new ShaderArray(shader);
                ShaderProgram program = array.GetShaderProgram();
                this.computeProgram = program;
            }
            {
                VertexBuffer buffer = this.RenderUnit.Model.GetVertexAttribute(ParticlesModel.strPosition).First();
                Texture texture = buffer.DumpBufferTexture(GL.GL_RGBA32F, false);
                this.texPosition = texture;
            }
            {
                VertexBuffer buffer = this.RenderUnit.Model.GetVertexAttribute(ParticlesModel.strVelocity).First();
                Texture texture = buffer.DumpBufferTexture(GL.GL_RGBA32F, false);
                this.texVelocity = texture;
            }
            {
                var random = new Random();
                for (int i = 0; i < attractorCount; i++)
                {
                    this.attractors[i] = new vec4((float)random.NextDouble(), (float)random.NextDouble(), (float)random.NextDouble(), (float)random.NextDouble());
                }
            }
        }

        #region IRenderable 成员

        private DateTime lastTime = DateTime.Now;
        private bool firstRendering = true;

        private float speed = 1f;

        public float Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        private double attractorInterval;

        private Random random = new Random();

        private ThreeFlags enableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children;
        public ThreeFlags EnableRendering
        {
            get { return this.enableRendering; }
            set { this.enableRendering = value; }
        }

        public unsafe void RenderBeforeChildren(RenderEventArgs arg)
        {
            {
                this.attractorInterval += random.NextDouble() * 5;
                for (int i = 0; i < attractorCount; i++)
                {
                    this.attractors[i] = new vec4(
                        (float)(Math.Sin(attractorInterval * (i + 4) * 7.5f * 20.0f)) * 5.0f,
                        (float)(Math.Cos(attractorInterval * (i + 7) * 3.9f * 20.0f)) * 5.0f,
                        (float)(Math.Sin(attractorInterval * (i + 3) * 5.3f * 20.0f))
                            * (float)(Math.Cos(attractorInterval * (i + 5) * 9.1f)) * 10.0f,
                        this.attractors[i].w);
                }
            }
            {
                DateTime now = DateTime.Now;
                if (this.firstRendering)
                {
                    this.lastTime = now;
                    this.firstRendering = false;
                }

                TimeSpan span = now.Subtract(this.lastTime);
                this.lastTime = now;
                float deltaTime = (float)(span.TotalSeconds * this.speed);

                this.computeProgram.Bind();
                const uint imageUnit0 = 0, imageUnit1 = 1;
                const int level = 0, layer = 0;
                const bool layered = false;
                glBindImageTexture(imageUnit0, this.texPosition.Id, level, layered, layer, GL.GL_READ_WRITE, GL.GL_RGBA32F);
                glBindImageTexture(imageUnit1, this.texVelocity.Id, level, layered, layer, GL.GL_READ_WRITE, GL.GL_RGBA32F);
                this.computeProgram.SetUniform("deltaTime", deltaTime);
                this.computeProgram.SetUniform("attractors", this.attractors);
                this.computeProgram.PushUniforms();
                glDispatchCompute((uint)this.groupCount, 1, 1);
                glMemoryBarrier(GL.GL_SHADER_IMAGE_ACCESS_BARRIER_BIT);
                glBindImageTexture(imageUnit0, 0, level, layered, layer, GL.GL_READ_WRITE, GL.GL_RGBA32F);
                glBindImageTexture(imageUnit1, 0, level, layered, layer, GL.GL_READ_WRITE, GL.GL_RGBA32F);
                this.computeProgram.Unbind();
            }
            {
                ICamera camera = arg.Camera;
                mat4 projection = camera.GetProjectionMatrix();
                mat4 view = camera.GetViewMatrix();
                mat4 model = this.GetModelMatrix();
                var method = this.RenderUnit.Methods[0];
                GL.Instance.Enable(GL.GL_VERTEX_PROGRAM_POINT_SIZE);
                ShaderProgram program = method.Program;
                program.SetUniform("projectionMat", projection);
                program.SetUniform("viewMat", view * model);
                method.Render();
            }
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }

        #endregion

        private static readonly GLDelegates.void_uint_uint_int_bool_int_uint_uint glBindImageTexture;
        private static readonly GLDelegates.void_uint_uint_uint glDispatchCompute;
        private static readonly GLDelegates.void_uint glMemoryBarrier;
        private int groupCount;
        static ParticlesNode()
        {
            glBindImageTexture = GL.Instance.GetDelegateFor("glBindImageTexture", GLDelegates.typeof_void_uint_uint_int_bool_int_uint_uint) as GLDelegates.void_uint_uint_int_bool_int_uint_uint;
            glDispatchCompute = GL.Instance.GetDelegateFor("glDispatchCompute", GLDelegates.typeof_void_uint_uint_uint) as GLDelegates.void_uint_uint_uint;
            glMemoryBarrier = GL.Instance.GetDelegateFor("glMemoryBarrier", GLDelegates.typeof_void_uint) as GLDelegates.void_uint;

        }

    }
}
