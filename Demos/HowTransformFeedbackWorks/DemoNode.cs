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
    partial class DemoNode : ModernNode, IRenderable
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
                var map = new AttributeMap();
                map.Add(inPosition, DemoModel.inPosition);
                map.Add(inVelocity, DemoModel.inVelocity);
                var map2 = new AttributeMap();
                map2.Add(inPosition, DemoModel.inPosition2);
                map2.Add(inVelocity, DemoModel.inVelocity2);
                updateBuilder = new RenderMethodBuilder(updateProvider, map);
                updateBuilder2 = new RenderMethodBuilder(updateProvider, map2);
            }

            RenderMethodBuilder renderBuilder, renderBuilder2;
            {
                IShaderProgramProvider renderProvider;
                var vs = new VertexShader(renderVert);
                var fs = new FragmentShader(renderFrag);
                renderProvider = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add(inPosition, DemoModel.inPosition);
                map.Add(inVelocity, DemoModel.inVelocity);
                var map2 = new AttributeMap();
                map2.Add(inPosition, DemoModel.inPosition2);
                map2.Add(inVelocity, DemoModel.inVelocity2);
                renderBuilder = new RenderMethodBuilder(renderProvider, map);
                renderBuilder2 = new RenderMethodBuilder(renderProvider, map2);
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
                foreach (var vao in method.VertexArrayObjects)
                {
                    VertexShaderAttribute[] attributes = vao.VertexAttributes;
                    for (uint t = 0; t < attributes.Length; t++)
                    {
                        tf.BindBuffer(t, attributes[t].Buffer);
                    }
                }
                this.transformFeedbackObjects[i] = tf;
            }
        }


        #region IRenderable 成员

        private ThreeFlags enableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children | ThreeFlags.AfterChildren;
        /// <summary>
        /// Render before/after children? Render children? 
        /// RenderAction cares about this property. Other actions, maybe, maybe not, your choice.
        /// </summary>
        public ThreeFlags EnableRendering
        {
            get { return this.enableRendering; }
            set { this.enableRendering = value; }
        }

        public void RenderBeforeChildren(RenderEventArgs arg)
        {
            TransformFeedbackObject tf = transformFeedbackObjects[(currentIndex + 1) % 2];
            // update content at (currentIndex + 1)
            {
                GL.Instance.Enable(GL.GL_RASTERIZER_DISCARD);

                RenderMethod method = this.RenderUnit.Methods[currentIndex];
                ShaderProgram program = method.Program;
                //program.SetUniform("xxx", value);
                method.Render(tf); // update buffers and record output to tf's binding.

                GL.Instance.Disable(GL.GL_RASTERIZER_DISCARD);
            }
            // render at (currentIndex + 1)
            {
                RenderMethod method = this.RenderUnit.Methods[(currentIndex + 1) % 2 + 2];
                ShaderProgram program = method.Program;
                ICamera camera = arg.Camera;
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

        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }

        #endregion
    }
}
