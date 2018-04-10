using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HowTransformFeedbackWorks
{
    partial class ParticleDemoNode : ModernNode, IRenderable
    {
        private const string inPosition = "inposition";
        private const string inVelocity = "invelocity";
        private const string outPosition = "outposition";
        private const string outVelocity = "outvelocity";

        private const string vposition = "vposition";

        private TransformFeedbackObject[] transformFeedbackObjects = new TransformFeedbackObject[2];
        private int currentIndex = 0;

        public static ParticleDemoNode Create(int particleCount)
        {
            IShaderProgramProvider updateProvider, renderProvider;
            {
                var vs = new VertexShader(updateVert);
                var feedbackVaryings = new string[] { outPosition, outVelocity };
                updateProvider = new ShaderArray(feedbackVaryings, ShaderProgram.BufferMode.Separate, vs);
            }
            {
                var vs = new VertexShader(renderVert);
                var gs = new GeometryShader(renderGeom);
                var fs = new FragmentShader(renderFrag);
                renderProvider = new ShaderArray(vs, gs, fs);
            }
            RenderMethodBuilder updateBuilder, updateBuilder2, renderBuilder, renderBuilder2;
            var blend = new BlendFuncSwitch(BlendSrcFactor.One, BlendDestFactor.One);
            {
                var map = new PropertyMap();
                map.Add(inPosition, ParticleDemoModel.inPosition);
                map.Add(inVelocity, ParticleDemoModel.inVelocity);
                updateBuilder = new RenderMethodBuilder(updateProvider, map);
            }
            {
                var map = new PropertyMap();
                map.Add(inPosition, ParticleDemoModel.inPosition2);
                map.Add(inVelocity, ParticleDemoModel.inVelocity2);
                updateBuilder2 = new RenderMethodBuilder(updateProvider, map);
            }
            {
                var map = new PropertyMap();
                map.Add(vposition, ParticleDemoModel.inPosition);
                renderBuilder = new RenderMethodBuilder(renderProvider, map, blend);
            }
            {
                var map = new PropertyMap();
                map.Add(vposition, ParticleDemoModel.inPosition2);
                renderBuilder2 = new RenderMethodBuilder(renderProvider, map, blend);
            }

            var model = new ParticleDemoModel(particleCount);
            var node = new ParticleDemoNode(model, updateBuilder, updateBuilder2, renderBuilder, renderBuilder2);
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

        private ParticleDemoNode(IBufferSource model, params RenderMethodBuilder[] builders)
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
            // update
            {
                GL.Instance.Enable(GL.GL_RASTERIZER_DISCARD);

                RenderMethod method = this.RenderUnit.Methods[currentIndex];
                ShaderProgram program = method.Program;
                // set the uniforms 
                program.SetUniform("center", center);
                program.SetUniform("radius", radius);
                program.SetUniform("g", g);
                program.SetUniform("dt", dt);
                program.SetUniform("bounce", bounce);
                program.SetUniform("seed", random.Next());
                method.Render(tf); // update buffers and record output to tf's binding.

                GL.Instance.Disable(GL.GL_RASTERIZER_DISCARD);
            }
            // render
            {
                RenderMethod method = this.RenderUnit.Methods[(currentIndex + 1) % 2 + 2];
                ShaderProgram program = method.Program;
                ICamera camera = arg.Camera;
                mat4 projection = camera.GetProjectionMatrix();
                mat4 view = camera.GetViewMatrix();
                mat4 model = this.GetModelMatrix();

                program.SetUniform("Projection", projection);
                program.SetUniform("View", view * model);
                //unit.Render(); // this methos must specify vertes count.
                tf.Draw(method); // render updated buffersi without specifying vertex count.
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