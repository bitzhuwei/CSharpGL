using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace ParticleSystem.TransformFeedback
{
    public partial class ParticleSimulatorNode : SceneNodeBase, IRenderable
    {
        public const string vPosition = "vPosition";
        public const string Projection = "Projection";
        public const string View = "View";
        private ShaderProgram renderProgram;
        private ShaderProgram updateProgram;
        private VertexArrayObject[] vaos = new VertexArrayObject[2];
        private VertexBuffer[] positionBuffers = new VertexBuffer[2];
        private VertexBuffer[] velocityBuffers = new VertexBuffer[2];

        private TransformFeedbackObject transformFeedback;
        private int current_buffer = 0;
        private const int spheres = 3;
        private vec3[] center = new vec3[spheres];
        private float[] radius = new float[spheres];
        // physical parameters
        private float dt = 1.0f / 60.0f;
        private vec3 g = new vec3(0.0f, -9.81f, 0.0f);
        private float bounce = 1.2f; // inelastic: 1.0f, elastic: 2.0f
        private Random random = new Random();

        /// <summary>
        /// 0
        /// </summary>
        private const int updateUnit = 0;
        /// <summary>
        /// 1
        /// </summary>
        private const int renderUnit = 1;
        private BlendState blendState;
        private PointSizeState pointSizeState;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="particleCount"></param>
        public ParticleSimulatorNode(int particleCount = 128*1024)
        {
            {
                var vs = new VertexShader(renderVert, vPosition);
                var gs = new GeometryShader(renderGeom);
                var fs = new FragmentShader(renderFrag);
                var provider = new ShaderArray(vs, gs, fs);
                this.renderProgram = provider.GetShaderProgram();
            }
            {
                var vs = new VertexShader(updateVert, "inposition", "invelocity");
                var program = new ShaderProgram();
                var varying_names = new string[] { "outposition", "outvelocity" };
                program.Initialize(varying_names, ShaderProgram.BufferMode.Separate, vs);
                this.updateProgram = program;
                var tf = new TransformFeedbackObject();
                this.transformFeedback = tf;

                int loc = this.updateProgram.GetAttributeLocation("inposition");
                //Console.WriteLine(loc);
                //loc = this.updateProgram.GetAttributeLocation("invelocity");
                //Console.WriteLine(loc);
            }
            {
                var positions = new vec3[particleCount];
                var random = new Random();
                for (int i = 0; i < positions.Length; i++)
                {
                    positions[i] = new vec3(
                        (float)random.NextDouble(),
                        (float)random.NextDouble(),
                        (float)random.NextDouble()
                        ) * 5 + new vec3(0, 20, 0);
                }
                for (int i = 0; i < 2; i++)
                {
                    this.positionBuffers[i] = positions.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.DynamicCopy);
                }
            }
            {
                var velocitys = new vec3[particleCount];
                for (int i = 0; i < 2; i++)
                {
                    this.velocityBuffers[i] = velocitys.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.DynamicCopy);
                }
            }
            {
                for (int i = 0; i < 2; i++)
                {
                    var indexBuffer = ZeroIndexBuffer.Create(DrawMode.Points, 0, particleCount);
                    var attributes = new VertexShaderAttribute[2];
                    attributes[0] = new VertexShaderAttribute(this.positionBuffers[i], "inposition");
                    attributes[1] = new VertexShaderAttribute(this.velocityBuffers[i], "invelocity");
                    this.vaos[i] = new VertexArrayObject(indexBuffer, attributes);
                    this.vaos[i].Initialize(this.updateProgram);
                }
            }
            //{
            //    var tf = new TransformFeedbackObject();
            //    var varying_names = new string[] { "outposition", "outvelocity" };
            //    tf.Capture(varying_names, this.updateProgram, TransformFeedbackObject.BufferMode.Separate);

            //    this.transformFeedback = tf;
            //}
            {
                this.pointSizeState = new PointSizeState(20);
                this.blendState = new BlendState(BlendingSourceFactor.One, BlendingDestinationFactor.One);
            }
            {
                // define spheres for the particles to bounce off
                center[0] = new vec3(0, 12, 1);
                radius[0] = 3;
                center[1] = new vec3(-3, 0, 0);
                radius[1] = 7;
                center[2] = new vec3(5, -10, 0);
                radius[2] = 12;
            }
        }

        #region IRenderable 成员

        /// <summary>
        /// 
        /// </summary>
        public ThreeFlags EnableRendering { get { return ThreeFlags.BeforeChildren | ThreeFlags.Children; } set { } }

        public void RenderBeforeChildren(RenderEventArgs arg)
        {
            {
                GL.Instance.Disable(GL.GL_DEPTH_TEST);
                this.blendState.On();
                this.pointSizeState.On();
            }
            // update
            {
                TransformFeedbackObject tf = this.transformFeedback;
                tf.Bind();
                {
                    {
                        var vao = this.vaos[(current_buffer) % 2];
                        var attributes = vao.VertexAttributes;
                        for (uint i = 0; i < attributes.Length; i++)
                        {
                            tf.BindBuffer(i, attributes[i].Buffer.BufferId);
                        }
                    }
                    {
                        GL.Instance.Enable(GL.GL_RASTERIZER_DISCARD);
                        var vao = this.vaos[(current_buffer + 1) % 2];
                        tf.Begin(vao.IndexBuffer.Mode);
                        {
                            ShaderProgram program = this.updateProgram;
                            program.SetUniform("center", this.center);
                            program.SetUniform("radius", this.radius);
                            program.SetUniform("g", this.g);
                            program.SetUniform("dt", this.dt);
                            program.SetUniform("bounce", this.bounce);
                            program.SetUniform("seed", this.random.Next());
                            program.Bind();
                            { vao.Render(); }
                            program.Unbind();
                        }
                        tf.End();
                        GL.Instance.Disable(GL.GL_RASTERIZER_DISCARD);
                    }
                }
                tf.Unbind();
                //unsafe
                //{
                //    var buffer = this.dataNodes[1].RenderUnits[updateUnit].VertexArrayObject.VertexAttributeBuffers[0].Buffer;
                //    var array = (vec4*)buffer.MapBuffer(MapBufferAccess.ReadOnly);
                //    int length = buffer.Length;
                //    var data = new vec4[length];
                //    for (int i = 0; i < length; i++)
                //    {
                //        data[i] = array[i];
                //    }
                //    buffer.UnmapBuffer();
                //    Console.WriteLine();
                //}
            }
            // render
            {
                ICamera camera = arg.CameraStack.Peek();
                mat4 projection = camera.GetProjectionMatrix();
                mat4 view = camera.GetViewMatrix();
                mat4 model = this.GetModelMatrix();

                var vao = this.vaos[(current_buffer) % 2];
                ShaderProgram program = this.renderProgram;
                program.SetUniform(Projection, projection);
                program.SetUniform(View, view * model);
                program.Bind();
                { vao.Render(); }
                program.Unbind();
            }
            // exchange
            {
                current_buffer = (current_buffer + 1) % 2;
            }
            {
                this.pointSizeState.Off();
                this.blendState.Off();
                GL.Instance.Enable(GL.GL_DEPTH_TEST);
            }
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }

        #endregion
    }
}
