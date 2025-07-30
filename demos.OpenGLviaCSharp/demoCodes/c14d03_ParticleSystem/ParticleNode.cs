using CSharpGL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace c14d03_ParticleSystem {
    partial class ParticleNode : ModernNode, IRenderable {
        private const string inPosition = "inPosition";
        private const string inVelocity = "inVelocity";
        private const string outPosition = "outPosition";
        private const string outVelocity = "outVelocity";

        private TransformFeedbackObject[] transformFeedbackObjects = new TransformFeedbackObject[2];

        private int currentIndex = 0;

        public static ParticleNode Create(int particleCount) {
            GLProgram? updateProgram, renderProgram;
            {
                var feedbackVaryings = new string[] { outPosition, outVelocity };
                updateProgram = GLProgram.Create(feedbackVaryings, GLProgram.BufferMode.Separate,
                    updateVert); Debug.Assert(updateProgram != null);
            }
            {
                renderProgram = GLProgram.Create(renderVert, renderGeom, renderFrag); Debug.Assert(renderProgram != null);
            }
            RenderMethodBuilder updateBuilder, updateBuilder2, renderBuilder, renderBuilder2;
            var blend = new BlendSwitch(BlendEquationMode.Add, BlendSrcFactor.One, BlendDestFactor.One);
            {
                var map = new AttributeMap();
                map.Add(inPosition, ParticleModel.inPosition);
                map.Add(inVelocity, ParticleModel.inVelocity);
                updateBuilder = new RenderMethodBuilder(updateProgram, map);
            }
            {
                var map = new AttributeMap();
                map.Add(inPosition, ParticleModel.inPosition2);
                map.Add(inVelocity, ParticleModel.inVelocity2);
                updateBuilder2 = new RenderMethodBuilder(updateProgram, map);
            }
            {
                var map = new AttributeMap();
                map.Add(inPosition, ParticleModel.inPosition);
                map.Add(inVelocity, ParticleModel.inVelocity);
                renderBuilder = new RenderMethodBuilder(renderProgram, map, blend);
            }
            {
                var map = new AttributeMap();
                map.Add(inPosition, ParticleModel.inPosition2);
                map.Add(inVelocity, ParticleModel.inVelocity2);
                renderBuilder2 = new RenderMethodBuilder(renderProgram, map, blend);
            }

            var model = new ParticleModel(particleCount);
            var node = new ParticleNode(model, updateBuilder, updateBuilder2, renderBuilder, renderBuilder2);
            node.Initialize();

            return node;
        }

        // physical parameters 
        vec3 gravity = new vec3(0.0f, -9.8f, 0.0f);
        private DateTime lastTime;
        private bool firstRendering = true;

        private ParticleNode(IBufferSource model, params RenderMethodBuilder[] builders)
            : base(model, builders) {
        }

        protected override void DoInitialize() {
            base.DoInitialize();

            for (int i = 0; i < 2; i++) {
                var tfo = new TransformFeedbackObject();
                RenderMethod method = this.RenderUnit.Methods[i];
                // make sure there is only one vao in this case.
                foreach (var vao in method.VertexArrayObjects) {
                    var attributes = vao.VertexAttributes;
                    for (int bingdingPointIndex = 0; bingdingPointIndex < attributes.Count; bingdingPointIndex++) {
                        tfo.BindBuffer((uint)bingdingPointIndex, attributes[bingdingPointIndex].buffer);
                    }
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
            // update
            {
                if (this.firstRendering) {
                    this.lastTime = DateTime.Now;
                    this.firstRendering = false;
                }

                var now = DateTime.Now;
                float seconds = (float)now.Subtract(this.lastTime).TotalSeconds;
                this.lastTime = now;

                gl.glEnable(GL.GL_RASTERIZER_DISCARD);

                RenderMethod method = this.RenderUnit.Methods[currentIndex];
                GLProgram program = method.Program;
                // set the uniforms 
                program.SetUniform("gravity", gravity);
                program.SetUniform("deltaTime", seconds);
                method.Render(tfo); // update buffers and record output to tf's binding.

                gl.glDisable(GL.GL_RASTERIZER_DISCARD);
            }
            // render
            {
                RenderMethod method = this.RenderUnit.Methods[(currentIndex + 1) % 2 + 2];
                GLProgram program = method.Program;
                ICamera camera = arg.Camera;
                mat4 projection = camera.GetProjectionMatrix();
                mat4 view = camera.GetViewMatrix();
                mat4 model = this.GetModelMatrix();

                program.SetUniform("projectionMat", projection);
                program.SetUniform("viewMat", view * model);
                //unit.Render(); // this method requires specified vertes count.
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