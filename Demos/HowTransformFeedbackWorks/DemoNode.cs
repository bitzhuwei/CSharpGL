using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace HowTransformFeedbackWorks
{
    /// <summary>
    /// totally same with <see cref="SimpleTransformFeedBackNode"/>
    /// </summary>
    partial class DemoNode : ModernNode
    {
        private const string inPosition = "inPosition";
        private const string inVelocity = "inVelocity";
        private const string outPosition = "outPosition";
        private const string outVelocity = "outVelocity";
        private const string mvpMatrix = "mvpMatrix";
        private TransformFeedbackObject[] transformFeedbackObjects = new TransformFeedbackObject[2];
        private int currentIndex = 0;

        public static DemoNode Create()
        {
            RenderMethodBuilder updateBuilder, updateBuilder2;
            {
                IShaderProgramProvider updateProvider;
                var vs = new VertexShader(updateVert);
                var feedbackVaryings = new string[] { outPosition, outVelocity };
                updateProvider = new ShaderArray(feedbackVaryings, ShaderProgram.BufferMode.Separate, vs);
                {
                    var map = new AttributeMap();
                    map.Add(inPosition, DemoModel.inPosition);
                    map.Add(inVelocity, DemoModel.inVelocity);
                    updateBuilder = new RenderMethodBuilder(updateProvider, map);
                }
                {
                    var map = new AttributeMap();
                    map.Add(inPosition, DemoModel.inPosition2);
                    map.Add(inVelocity, DemoModel.inVelocity2);
                    updateBuilder2 = new RenderMethodBuilder(updateProvider, map);
                }
            }

            RenderMethodBuilder renderBuilder, renderBuilder2;
            {
                IShaderProgramProvider renderProvider;
                var vs = new VertexShader(renderVert);
                var fs = new FragmentShader(renderFrag);
                renderProvider = new ShaderArray(vs, fs);
                {
                    var map = new AttributeMap();
                    map.Add(inPosition, DemoModel.inPosition);
                    map.Add(inVelocity, DemoModel.inVelocity);
                    renderBuilder = new RenderMethodBuilder(renderProvider, map);
                }
                {
                    var map = new AttributeMap();
                    map.Add(inPosition, DemoModel.inPosition2);
                    map.Add(inVelocity, DemoModel.inVelocity2);
                    renderBuilder2 = new RenderMethodBuilder(renderProvider, map);
                }
            }

            var model = new DemoModel();
            var node = new DemoNode(model, updateBuilder, updateBuilder2, renderBuilder, renderBuilder2);
            node.Initialize();

            return node;
        }

        private DemoNode(IBufferSource model, params RenderMethodBuilder[] builders)
            : base(model, builders)
        {
        }

        protected override void DoInitialize()
        {
            base.DoInitialize();

            for (int i = 0; i < 2; i++)
            {
                var tf = new TransformFeedbackObject();
                RenderMethod method = this.RenderUnit.Methods[i];
                VertexShaderAttribute[] attributes = method.VertexArrayObject.VertexAttributes;
                for (uint t = 0; t < attributes.Length; t++)
                {
                    tf.BindBuffer(t, attributes[t].Buffer);
                }
                this.transformFeedbackObjects[i] = tf;
            }
        }
        #region IRenderable 成员

        public override void RenderBeforeChildren(RenderEventArgs arg)
        {
            TransformFeedbackObject tf = transformFeedbackObjects[(currentIndex + 1) % 2];
            // update
            {
                GL.Instance.Enable(GL.GL_RASTERIZER_DISCARD);

                RenderMethod method = this.RenderUnit.Methods[currentIndex];
                ShaderProgram program = method.Program;
                //program.SetUniform("xxx", value);
                method.Render(IndexBuffer.ControlMode.ByFrame, tf); // update buffers and record output to tf's binding.

                GL.Instance.Disable(GL.GL_RASTERIZER_DISCARD);
            }
            // render
            {
                RenderMethod method = this.RenderUnit.Methods[(currentIndex + 1) % 2 + 2];
                ShaderProgram program = method.Program;
                ICamera camera = arg.CameraStack.Peek();
                mat4 projection = camera.GetProjectionMatrix();
                mat4 view = camera.GetViewMatrix();
                mat4 model = this.GetModelMatrix();

                program.SetUniform(mvpMatrix, projection * view * model);
                //unit.Render(); // this method must specify vertex count.
                tf.Draw(method); // render updated buffers without specifying vertex count.
            }
            // exchange
            {
                currentIndex = (currentIndex + 1) % 2;
            }
        }

        public override void RenderAfterChildren(RenderEventArgs arg)
        {
        }

        #endregion
    }
}
