using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace HowTransformFeedbackWorks
{
    partial class SimpleTransformFeedBackNode : SceneNodeBase, IRenderable
    {
        private const string inPosition = "inPosition";
        private const string inVelocity = "inVelocity";
        private const string outPosition = "outPosition";
        private const string outVelocity = "outVelocity";
        private const string mvpMatrix = "mvpMatrix";
        private TransformFeedbackObject transformFeedbackObject;
        private ShaderProgram updateProgram;
        private ShaderProgram renderProgram;
        private VertexBuffer[] positionBuffers = new VertexBuffer[2];
        private VertexBuffer[] velocityBuffers = new VertexBuffer[2];
        private IndexBuffer[] indexBuffers = new IndexBuffer[2];
        private VertexArrayObject[] updateVAOs = new VertexArrayObject[2];
        private VertexArrayObject[] renderVAOs = new VertexArrayObject[2];
        private int currentIndex = 0;

        private static readonly vec3[] positions = new vec3[3];
        //{
        //new vec3(1, 0, 0), new vec3(0, 0, 1), new vec3(-1, 0, 0),
        //new vec3(0, 0, -1),
        //};
        private static readonly vec3[] velocitys = new vec3[3]
        {
            new vec3(1, 0, 0), new vec3(0, 1, 0), new vec3(0, 0, 1), 
            //new vec3(0, 0, -1),
        };

        public SimpleTransformFeedBackNode()
        {
            var tf = new TransformFeedbackObject();
            this.transformFeedbackObject = tf;
            {
                var vs = new VertexShader(updateVert, inPosition, inVelocity);
                var program = new ShaderProgram();
                var capture = new string[] { outPosition, outVelocity };
                program.Initialize(capture, ShaderProgram.BufferMode.Separate, vs);
                this.updateProgram = program;

            }
            {
                var vs = new VertexShader(renderVert, inPosition);
                var fs = new FragmentShader(renderFrag);
                var program = new ShaderProgram();
                program.Initialize(vs, fs);
                this.renderProgram = program;
            }
            {
                for (int i = 0; i < 2; i++)
                {
                    VertexBuffer buffer = positions.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.DynamicCopy);
                    this.positionBuffers[i] = buffer;
                }
                for (int i = 0; i < 2; i++)
                {
                    VertexBuffer buffer = velocitys.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.DynamicCopy);
                    this.velocityBuffers[i] = buffer;
                }
                for (int i = 0; i < 2; i++)
                {
                    IndexBuffer buffer = ZeroIndexBuffer.Create(DrawMode.Triangles, 0, positions.Length);
                    this.indexBuffers[i] = buffer;
                }
            }
            {
                for (int i = 0; i < 2; i++)
                {
                    var attributes = new VertexShaderAttribute[2];
                    attributes[0] = new VertexShaderAttribute(this.positionBuffers[i], inPosition);
                    attributes[1] = new VertexShaderAttribute(this.velocityBuffers[i], inVelocity);
                    var vao = new VertexArrayObject(this.indexBuffers[i], attributes);
                    vao.Initialize(this.updateProgram);
                    this.updateVAOs[i] = vao;
                }
                for (int i = 0; i < 2; i++)
                {
                    var attributes = new VertexShaderAttribute[2];
                    attributes[0] = new VertexShaderAttribute(this.positionBuffers[i], inPosition);
                    attributes[1] = new VertexShaderAttribute(this.velocityBuffers[i], inVelocity);
                    var vao = new VertexArrayObject(this.indexBuffers[i], attributes);
                    vao.Initialize(this.renderProgram);
                    this.renderVAOs[i] = vao;
                }
            }
        }

        #region IRenderable 成员

        public ThreeFlags EnableRendering { get { return ThreeFlags.BeforeChildren | ThreeFlags.Children; } set { } }

        public void RenderBeforeChildren(RenderEventArgs arg)
        {
            // update
            {
                GL.Instance.Enable(GL.GL_RASTERIZER_DISCARD);


                ShaderProgram program = this.updateProgram;
                VertexArrayObject vao = this.updateVAOs[currentIndex];
                TransformFeedbackObject tf = this.transformFeedbackObject;

                tf.BindBuffer(0, this.positionBuffers[(currentIndex + 1) % 2].BufferId);
                tf.BindBuffer(1, this.velocityBuffers[(currentIndex + 1) % 2].BufferId);

                tf.Bind();
                program.Bind();
                program.PushUniforms();
                {
                    tf.Begin(DrawMode.Triangles);
                    vao.Render();
                    tf.End();
                }
                program.Unbind();
                tf.Unbind();
                GL.Instance.Disable(GL.GL_RASTERIZER_DISCARD);
            }
            unsafe
            {
                var array = (vec3*)this.positionBuffers[(currentIndex + 1) % 2].MapBuffer(MapBufferAccess.ReadOnly);
                var data = new vec3[this.positionBuffers[(currentIndex + 1) % 2].Length];
                for (int i = 0; i < data.Length; i++)
                {
                    data[i] = array[i];
                }
                this.positionBuffers[(currentIndex + 1) % 2].UnmapBuffer();
            }
            // render
            {
                ShaderProgram program = this.renderProgram;
                VertexArrayObject vao = this.renderVAOs[(currentIndex + 1) % 2];
                {
                    ICamera camera = arg.CameraStack.Peek();
                    mat4 projection = camera.GetProjectionMatrix();
                    mat4 view = camera.GetViewMatrix();
                    mat4 model = this.GetModelMatrix();

                    program.SetUniform(mvpMatrix, projection * view * model);

                    program.Bind();
                    program.PushUniforms();

                    vao.Render();
                    program.Unbind();
                }
            }
            // exchange
            {
                currentIndex = (currentIndex + 1) % 2;
            }
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }

        #endregion
    }
}
