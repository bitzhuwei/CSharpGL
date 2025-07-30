using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using CSharpGL;

namespace Accumulation {
    partial class AccumulationNode : ModernNode, IRenderable {
        public static AccumulationNode Create() {
            var model = new Sphere();
            RenderMethodBuilder renderBuilder;
            {
                var program = GLProgram.Create(renderVert, renderFrag); Debug.Assert(program != null);
                var map = new AttributeMap();
                map.Add("inPosition", Sphere.strPosition);
                map.Add("inColor", Sphere.strColor);
                var blend = new BlendFuncSwitch(BlendSrcFactor.SrcAlpha, BlendDestFactor.OneMinusSrcAlpha);
                renderBuilder = new RenderMethodBuilder(program, map);
            }
            var node = new AccumulationNode(model, renderBuilder);
            node.ModelSize = model.Size;
            node.Initialize();

            return node;
        }

        private AccumulationNode(IBufferSource model, params RenderMethodBuilder[] builders)
            : base(model, builders) {
        }

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
            //int bits;
            //gl.glGetIntegerv(GL.GL_ACCUM_RED_BITS, &bits);
            ICamera camera = arg.Camera;
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();

            RenderMethod method = this.RenderUnit.Methods[0];
            GLProgram program = method.Program;
            // setup uniforms
            program.SetUniform("projectionMat", projection);
            program.SetUniform("viewMat", view);

            gl.glClear(GL.GL_ACCUM_BUFFER_BIT);
            for (int i = 0; i < 3; i++) {
                //mat4 matrix = glm.translate(new vec3(i, 0, 0));
                //matrix = glm.scale(matrix, this.Scale);
                //matrix = glm.rotate(matrix, this.RotationAngle, this.RotationAxis);
                //mat4 matrix = glm.translate(new vec3(i, 0, 0))
                //* glm.scale(this.Scale)
                //* glm.rotate(this.RotationAngle, this.RotationAxis);
                mat4 matrix = glm.rotate(this.RotationAngle, this.RotationAxis)
                    * glm.scale(this.Scale)
                    * glm.translate(new vec3(i, 0, 0));

                program.SetUniform("modelMat", matrix);
                method.Render();

                if (i == 0) {
                    gl.glAccum(GL.GL_LOAD, 0.5f);
                }
                else {
                    gl.glAccum(GL.GL_ACCUM, 0.5f / (float)i);
                }
            }

            gl.glAccum(GL.GL_RETURN, 1.0f);

            GL.StopAtError();
        }

        public void RenderAfterChildren(RenderEventArgs arg) {
        }

    }
}
