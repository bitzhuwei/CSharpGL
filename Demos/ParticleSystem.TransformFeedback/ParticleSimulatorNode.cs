using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace ParticleSystem.TransformFeedback
{
    public partial class ParticleSimulatorNode : ModernNode
    {
        public const string vPosition = "position";           //xyz pos, w speed
        public const string prev_position = "prev_position";      //xyz prevPos, w life
        public const string vDirection = "direction";			//xyz direction, w 0
        private DataNode[] dataNodes;
        private TransformFeedbackObject transformFeedback;

        /// <summary>
        /// 0
        /// </summary>
        private const int updateUnit = 0;
        /// <summary>
        /// 1
        /// </summary>
        private const int renderUnit = 1;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="particleCount"></param>
        public ParticleSimulatorNode(int particleCount)
            : base(null)
        {
            var providers = new IShaderProgramProvider[2];
            {
                var vs = new VertexShader(udpateVert, vPosition, prev_position, vDirection);
                providers[0] = new ShaderArray(vs);
            }
            {
                var vs = new VertexShader(renderVert, vPosition);
                var fs = new FragmentShader(renderFrag);
                providers[1] = new ShaderArray(vs, fs);
            }
            var maps = new AttributeMap[0];
            {
                maps[0] = new AttributeMap();// don't change the order.
                maps[0].Add(vPosition, ParticleModel.position);
                maps[0].Add(prev_position, ParticleModel.pre_position);
                maps[0].Add(vDirection, ParticleModel.direction);
                maps[1] = new AttributeMap();
                maps[1].Add(vPosition, ParticleModel.position);
            }
            {
                var nodes = new DataNode[2];
                for (int i = 0; i < 2; i++)
                {
                    var model = new ParticleModel(particleCount);
                    var node = DataNode.Create(model, providers, maps);
                    node.Initialize();
                    nodes[i] = node;
                }
                this.dataNodes = nodes;
            }
            {
                var tf = new TransformFeedbackObject();
                var varying_names = new string[] { "out_position", "out_prev_position", "out_direction" };
                tf.Capture(varying_names, providers[0].GetShaderProgram(), TransformFeedbackObject.BufferMode.Separate);

                this.transformFeedback = tf;
            }
            {
                this.dateTime = DateTime.Now;
            }
        }

        private DateTime dateTime;

        public override void RenderBeforeChildren(RenderEventArgs arg)
        {
            ICamera camera = arg.CameraStack.Peek();
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();
            var now = DateTime.Now;
            float time = (float)((now.Subtract(this.dateTime)).TotalMilliseconds);
            dateTime = now;
            // update
            {
                TransformFeedbackObject tf = this.transformFeedback;
                tf.Bind();
                {
                    {
                        RenderUnit unit1 = this.dataNodes[1].RenderUnits[updateUnit];
                        var attributes = unit1.VertexArrayObject.VertexAttributeBuffers;
                        for (uint i = 0; i < attributes.Length; i++)
                        {
                            tf.BindBufferBase(i, attributes[i].Buffer.BufferId);
                        }
                    }
                    {
                        GL.Instance.Enable(GL.GL_RASTERIZER_DISCARD);
                        RenderUnit unit0 = this.dataNodes[0].RenderUnits[updateUnit];
                        tf.Begin(unit0.VertexArrayObject.IndexBuffer.Mode);
                        {
                            ShaderProgram program = unit0.Program;
                            program.SetUniform("MVP", projection * view * model);
                            program.SetUniform("t", time);
                            unit0.Render();
                        }
                        tf.End();
                        GL.Instance.Disable(GL.GL_RASTERIZER_DISCARD);
                    }
                }
                tf.Unbind();
            }
            // exchange
            {
                DataNode tmp = this.dataNodes[0];
                this.dataNodes[0] = this.dataNodes[1];
                this.dataNodes[1] = tmp;
            }
            // render
            {
                RenderUnit unit = this.dataNodes[0].RenderUnits[renderUnit];
                ShaderProgram program = unit.Program;
                program.SetUniform("MVP", projection * view * model);
                program.SetUniform("t", time);
                unit.Render();
            }
        }

        public override void RenderAfterChildren(RenderEventArgs arg)
        {
        }
    }
}
