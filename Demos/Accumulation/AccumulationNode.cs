﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace Accumulation
{
    partial class AccumulationNode : ModernNode
    {
        public static AccumulationNode Create()
        {
            var model = new Sphere();
            RenderMethodBuilder renderBuilder;
            {
                var vs = new VertexShader(renderVert);
                var fs = new FragmentShader(renderFrag);
                var provider = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add("inPosition", Sphere.strPosition);
                map.Add("inColor", Sphere.strColor);
                var blend = new BlendState(BlendingSourceFactor.SourceAlpha, BlendingDestinationFactor.OneMinusSourceAlpha);
                renderBuilder = new RenderMethodBuilder(provider, map);
            }
            var node = new AccumulationNode(model, renderBuilder);
            node.ModelSize = model.Size;
            node.Initialize();

            return node;
        }

        private AccumulationNode(IBufferSource model, params RenderMethodBuilder[] builders)
            : base(model, builders)
        {
        }

        public override void RenderBeforeChildren(RenderEventArgs arg)
        {
            ICamera camera = arg.CameraStack.Peek();
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();

            RenderMethod method = this.RenderUnit.Methods[0];
            ShaderProgram program = method.Program;
            // setup uniforms
            program.SetUniform("projectionMatrix", projection);
            program.SetUniform("viewMatrix", view);

            GL.Instance.Clear(GL.GL_ACCUM_BUFFER_BIT);
            for (int i = 0; i < 3; i++)
            {
                mat4 matrix = glm.translate(mat4.identity(), new vec3(i, 0, 0));
                matrix = glm.scale(matrix, this.Scale);
                matrix = glm.rotate(matrix, this.RotationAngle, this.RotationAxis);

                program.SetUniform("modelMatrix", matrix);
                method.Render();

                if (i == 0)
                {
                    GL.Instance.Accum(GL.GL_LOAD, 0.5f);
                }
                else
                {
                    GL.Instance.Accum(GL.GL_ACCUM, 0.5f / (float)i);
                }
            }

            GL.Instance.Accum(GL.GL_RETURN, 1.0f);
        }

        public override void RenderAfterChildren(RenderEventArgs arg)
        {
        }

    }
}
