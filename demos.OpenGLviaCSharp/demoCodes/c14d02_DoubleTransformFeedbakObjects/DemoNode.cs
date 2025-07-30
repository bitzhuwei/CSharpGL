using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c14d02_DoubleTransformFeedbakObjects {
    /// <summary>
    /// totally same with <see cref="SimpleTransformFeedBackNode"/>
    /// </summary>
    partial class DemoNode : ModernNode, IRenderable {
        private const string inPosition = "inPosition";
        private const string outPosition = "outPosition";
        private const string mvpMat = "mvpMat";
        private TransformFeedbackObject[] transformFeedbackObjects = new TransformFeedbackObject[2];
        private int currentIndex = 0;

        public static DemoNode Create() {
            RenderMethodBuilder updateBuilder, updateBuilder2;
            {
                var feedbackVaryings = new string[] { outPosition, };
                var program = GLProgram.Create(feedbackVaryings, GLProgram.BufferMode.Separate,
                    updateVert); Debug.Assert(program != null);
                var map = new AttributeMap();
                map.Add(inPosition, DemoModel.strPosition);
                var map2 = new AttributeMap();
                map2.Add(inPosition, DemoModel.strPosition2);
                updateBuilder = new RenderMethodBuilder(program, map);
                updateBuilder2 = new RenderMethodBuilder(program, map2);
            }

            RenderMethodBuilder renderBuilder, renderBuilder2;
            {
                var program = GLProgram.Create(renderVert, renderFrag); Debug.Assert(program != null);
                var map = new AttributeMap();
                map.Add(inPosition, DemoModel.strPosition);
                var map2 = new AttributeMap();
                map2.Add(inPosition, DemoModel.strPosition2);
                renderBuilder = new RenderMethodBuilder(program, map);
                renderBuilder2 = new RenderMethodBuilder(program, map2);
            }

            var model = new DemoModel();
            var node = new DemoNode(model, updateBuilder, updateBuilder2, renderBuilder, renderBuilder2);
            node.Initialize();

            return node;
        }

        private DemoNode(IBufferSource model, params RenderMethodBuilder[] builders)
            : base(model, builders) {
        }

        protected override void DoInitialize() {
            base.DoInitialize();

            for (int i = 0; i < 2; i++) {
                var tfo = new TransformFeedbackObject();
                RenderMethod method = this.RenderUnit.Methods[i];
                VertexArrayObject vao = method.VertexArrayObjects[0]; // only one element here.
                var attributes = vao.VertexAttributes;
                for (int bindingPointIndex = 0; bindingPointIndex < attributes.Count; bindingPointIndex++) {
                    tfo.BindBuffer((uint)bindingPointIndex, attributes[bindingPointIndex].buffer);
                }
                this.transformFeedbackObjects[i] = tfo;
            }
        }


        #region IRenderable 成员

        private ThreeFlags enableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children | ThreeFlags.AfterChildren;
        /// <summary>
        /// Render before/after children? Render children? 
        /// RenderAction cares about this property. Other actions, maybe, maybe not, your choice.
        /// </summary>
        public ThreeFlags EnableRendering {
            get { return this.enableRendering; }
            set { this.enableRendering = value; }
        }

        public unsafe void RenderBeforeChildren(RenderEventArgs arg) {
            var gl = GL.Current; Debug.Assert(gl != null);

            TransformFeedbackObject tfo = transformFeedbackObjects[(currentIndex + 1) % 2];
            // update content at (currentIndex + 1)
            {
                gl.glEnable(GL.GL_RASTERIZER_DISCARD);

                RenderMethod method = this.RenderUnit.Methods[currentIndex];
                GLProgram program = method.Program;
                //program.SetUniform("xxx", value);
                method.Render(tfo); // update buffers and record output to tf's binding.

                gl.glDisable(GL.GL_RASTERIZER_DISCARD);
            }
            // render at (currentIndex + 1)
            {
                RenderMethod method = this.RenderUnit.Methods[(currentIndex + 1) % 2 + 2];
                GLProgram program = method.Program;
                ICamera camera = arg.Camera;
                mat4 projection = camera.GetProjectionMatrix();
                mat4 view = camera.GetViewMatrix();
                mat4 model = this.GetModelMatrix();

                program.SetUniform(mvpMat, projection * view * model);
                //unit.Render(); // this method must specify vertex count.
                tfo.Draw(method); // render updated buffers without specifying vertex count.
            }
            // exchange
            {
                currentIndex = (currentIndex + 1) % 2;
            }
        }

        public void RenderAfterChildren(RenderEventArgs arg) {
        }

        #endregion
    }
}
