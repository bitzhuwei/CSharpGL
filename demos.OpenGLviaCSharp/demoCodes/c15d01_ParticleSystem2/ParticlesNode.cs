using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c15d01_ParticleSystem2 {
    partial class ParticlesNode : ModernNode, IRenderable {
        private GLProgram computeProgram;
        private Texture texPosition;
        private Texture texVelocity;
        public static ParticlesNode Create(int groupCount) {
            var model = new ParticlesModel(groupCount * 128);
            var program = GLProgram.Create(vertexCode, fragmentCode); Debug.Assert(program != null);
            var map = new AttributeMap();
            map.Add("inPosition", ParticlesModel.strPosition);
            var builder = new RenderMethodBuilder(program, map, new BlendSwitch(BlendEquationMode.Add, BlendSrcFactor.One, BlendDestFactor.One));
            var node = new ParticlesNode(model, builder);
            node.groupCount = groupCount;
            node.Initialize();

            return node;
        }

        private ParticlesNode(IBufferSource model, params RenderMethodBuilder[] builders) : base(model, builders) { }

        const int attractorCount = 64;
        //private attractor_block attractors;
        private vec4[] attractors = new vec4[attractorCount];

        public vec4[] Attractors {
            get { return attractors; }
            set { attractors = value; }
        }

        protected override void DoInitialize() {
            base.DoInitialize();
            {
                var program = GLProgram.Create((computeCode, Shader.Kind.comp)); Debug.Assert(program != null);
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
                //var attractors = new vec4[attractorCount];
                //for (int i = 0; i < attractorCount; i++)
                //{
                //    //attractors[i] = new vec4((float)random.NextDouble(), (float)random.NextDouble(), (float)random.NextDouble(), (float)random.NextDouble());
                //    attractors[i] = new vec4(1, 1, 1, 1);
                //}
                //UniformBuffer buffer = attractors.GenUniformBuffer(GLBuffer.BufferUsage.DynamicCopy);
                //this.attactorBuffer = buffer;
                //var attractors = new attractor_block();
                //attractors.attractor = new vec4[attractorCount];
                for (int i = 0; i < attractorCount; i++) {
                    this.attractors[i] = new vec4((float)random.NextDouble(), (float)random.NextDouble(), (float)random.NextDouble(), (float)random.NextDouble());
                }
            }
        }

        #region IRenderable 成员

        public bool Stopped { get; set; }

        private DateTime lastTime = DateTime.Now;

        private float speed = 10f;

        public float Speed {
            get { return speed; }
            set { speed = value; }
        }

        private double attractorInterval;

        private Random random = new Random();

        private ThreeFlags enableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children;
        public ThreeFlags EnableRendering {
            get { return this.enableRendering; }
            set { this.enableRendering = value; }
        }

        public unsafe void RenderBeforeChildren(RenderEventArgs arg) {
            if (!this.Stopped) {
                this.attractorInterval += random.NextDouble() * 5;
                for (int i = 0; i < attractorCount; i++) {
                    this.attractors[i] = new vec4(
                        (float)(Math.Sin(attractorInterval * (i + 4) * 7.5f * 20.0f)) * 5.0f,
                        (float)(Math.Cos(attractorInterval * (i + 7) * 3.9f * 20.0f)) * 5.0f,
                        (float)(Math.Sin(attractorInterval * (i + 3) * 5.3f * 20.0f))
                            * (float)(Math.Cos(attractorInterval * (i + 5) * 9.1f)) * 10.0f,
                        this.attractors[i].w);
                }
            }
            var gl = GL.Current; Debug.Assert(gl != null);
            {
                DateTime now = DateTime.Now;
                if (this.Stopped) {
                    this.lastTime = now;
                }
                TimeSpan span = now.Subtract(this.lastTime);
                float deltaTime = (float)(span.TotalSeconds * this.speed);
                this.lastTime = now;

                this.computeProgram.Bind();
                const uint imageUnit0 = 0, imageUnit1 = 1;
                const int level = 0, layer = 0;
                const bool layered = false;
                gl.glBindImageTexture(imageUnit0, this.texPosition.id, level, layered, layer, GL.GL_READ_WRITE, GL.GL_RGBA32F);
                gl.glBindImageTexture(imageUnit1, this.texVelocity.id, level, layered, layer, GL.GL_READ_WRITE, GL.GL_RGBA32F);
                this.computeProgram.SetUniform("deltaTime", deltaTime);
                this.computeProgram.SetUniform("attractors", this.attractors);
                this.computeProgram.PushUniforms();
                gl.glDispatchCompute((uint)this.groupCount, 1, 1);
                gl.glMemoryBarrier(GL.GL_SHADER_IMAGE_ACCESS_BARRIER_BIT);
                gl.glBindImageTexture(imageUnit0, 0, level, layered, layer, GL.GL_READ_WRITE, GL.GL_RGBA32F);
                gl.glBindImageTexture(imageUnit1, 0, level, layered, layer, GL.GL_READ_WRITE, GL.GL_RGBA32F);
                this.computeProgram.Unbind();
            }
            {
                ICamera camera = arg.Camera;
                mat4 projection = camera.GetProjectionMatrix();
                mat4 view = camera.GetViewMatrix();
                mat4 model = this.GetModelMatrix();
                var method = this.RenderUnit.Methods[0];
                method.Program.SetUniform("mvp", projection * view * model);
                method.Render();
            }
        }

        public void RenderAfterChildren(RenderEventArgs arg) {
        }

        #endregion

        private int groupCount;

        //private static readonly GLDelegates.void_uint_uint_int_bool_int_uint_uint glBindImageTexture;
        //private static readonly GLDelegates.void_uint_uint_uint glDispatchCompute;
        //private static readonly GLDelegates.void_uint glMemoryBarrier;
        //static ParticlesNode() {
        //    glBindImageTexture = GL.Current.GetDelegateFor("glBindImageTexture", GLDelegates.typeof_void_uint_uint_int_bool_int_uint_uint) as GLDelegates.void_uint_uint_int_bool_int_uint_uint;
        //    glDispatchCompute = GL.Current.GetDelegateFor("glDispatchCompute", GLDelegates.typeof_void_uint_uint_uint) as GLDelegates.void_uint_uint_uint;
        //    glMemoryBarrier = GL.Current.GetDelegateFor("glMemoryBarrier", GLDelegates.typeof_void_uint) as GLDelegates.void_uint;

        //}

    }

    //struct attractor_block : IEquatable<attractor_block>
    //{
    //    public vec4[] attractor;

    //    #region IEquatable<attractor_block> 成员

    //    public bool Equals(attractor_block other)
    //    {
    //        return false;
    //    }

    //    #endregion
    //}
}
