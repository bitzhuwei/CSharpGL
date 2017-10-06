using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HowTransformFeedbackWorks
{
    partial class OGLDevParticleNode : ModernNode
    {
        private const string inPosition = "inposition";
        private const string inVelocity = "invelocity";
        private const string outPosition = "outposition";
        private const string outVelocity = "outvelocity";

        private const string vposition = "vposition";

        private TransformFeedbackObject[] transformFeedbackObjects = new TransformFeedbackObject[2];
        private int currentIndex = 0;

        public static OGLDevParticleNode Create(int particleCount)
        {
            IShaderProgramProvider updateProvider, renderProvider;
            {
                var vs = new VertexShader(updateVert, inPosition, inVelocity);
                var feedbackVaryings = new string[] { outPosition, outVelocity };
                updateProvider = new ShaderArray(feedbackVaryings, ShaderProgram.BufferMode.Separate, vs);
            }
            {
                var vs = new VertexShader(renderVert, vposition);
                var gs = new GeometryShader(renderGeom);
                var fs = new FragmentShader(renderFrag);
                renderProvider = new ShaderArray(vs, gs, fs);
            }
            RenderMethodBuilder updateBuilder, updateBuilder2, renderBuilder, renderBuilder2;
            var blend = new BlendState(BlendingSourceFactor.One, BlendingDestinationFactor.One);
            {
                var map = new AttributeMap();
                map.Add(inPosition, OGLDevParticleModel.inPosition);
                map.Add(inVelocity, OGLDevParticleModel.inVelocity);
                updateBuilder = new RenderMethodBuilder(updateProvider, map);
            }
            {
                var map = new AttributeMap();
                map.Add(inPosition, OGLDevParticleModel.inPosition2);
                map.Add(inVelocity, OGLDevParticleModel.inVelocity2);
                updateBuilder2 = new RenderMethodBuilder(updateProvider, map);
            }
            {
                var map = new AttributeMap();
                map.Add(vposition, OGLDevParticleModel.inPosition);
                renderBuilder = new RenderMethodBuilder(renderProvider, map, blend);
            }
            {
                var map = new AttributeMap();
                map.Add(vposition, OGLDevParticleModel.inPosition2);
                renderBuilder2 = new RenderMethodBuilder(renderProvider, map, blend);
            }

            var model = new OGLDevParticleModel(particleCount);
            var node = new OGLDevParticleNode(model, updateBuilder, updateBuilder2, renderBuilder, renderBuilder2);
            node.Initialize();

            return node;
        }
        // define spheres for the particles to bounce off 
        const int spheres = 3;
        vec3[] center = new vec3[spheres];
        float[] radius = new float[spheres];

        // physical parameters 
        float dt = 1.0f / 60.0f;
        vec3 g = new vec3(0.0f, -9.81f, 0.0f);
        float bounce = 1.2f; // inelastic: 1.0f, elastic: 2.0f 
        Random random = new Random();

        private OGLDevParticleNode(IBufferSource model, params RenderMethodBuilder[] builders)
            : base(model, builders)
        {
            center[0] = new vec3(0, 0, 1);
            radius[0] = 3;
            center[1] = new vec3(-3, 0, 0);
            radius[1] = 7;
            center[2] = new vec3(5, -10, 0);
            radius[2] = 12;
        }

        protected override void DoInitialize()
        {
            base.DoInitialize();

            for (int i = 0; i < 2; i++)
            {
                var tf = new TransformFeedbackObject();
                RenderMethod unit = this.RenderUnit.Methods[i];
                VertexShaderAttribute[] attributes = unit.VertexArrayObject.VertexAttributes;
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

                RenderMethod unit = this.RenderUnit.Methods[currentIndex];
                ShaderProgram program = unit.Program;
                // set the uniforms 
                program.SetUniform("center", center);
                program.SetUniform("radius", radius);
                program.SetUniform("g", g);
                program.SetUniform("dt", dt);
                program.SetUniform("bounce", bounce);
                program.SetUniform("seed", random.Next());
                unit.Render(this.ControlMode, tf); // update buffers and record output to tf's binding.

                GL.Instance.Disable(GL.GL_RASTERIZER_DISCARD);
            }
            // render
            {
                RenderMethod unit = this.RenderUnit.Methods[(currentIndex + 1) % 2 + 2];
                ShaderProgram program = unit.Program;
                ICamera camera = arg.CameraStack.Peek();
                mat4 projection = camera.GetProjectionMatrix();
                mat4 view = camera.GetViewMatrix();
                mat4 model = this.GetModelMatrix();

                program.SetUniform("Projection", projection);
                program.SetUniform("View", view * model);
                //unit.Render(); // this methos must specify vertes count.
                tf.Draw(unit); // render updated buffersi without specifying vertex count.
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