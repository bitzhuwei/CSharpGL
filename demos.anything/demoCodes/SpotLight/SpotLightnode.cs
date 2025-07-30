﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;
using System.Drawing;
using System.Diagnostics;

namespace SpotLight {
    /// <summary>
    /// 
    /// </summary>
    public partial class SpotLightNode : PickableNode, IRenderable {
        private const string inPosition = "inPosition";
        private const string inNormal = "inNormal";

        private const string projectionMat = "projectionMat";
        private const string viewMat = "viewMat";
        private const string modelMat = "modelMat";
        private const string normalMatrix = "normalMatrix";
        private const string lightPosition = "lightPosition";
        private const string lightColor = "lightColor";
        private const string spotDirection = "spotDirection";
        private const string materialColor = "materialColor";
        private const string ambientColor = "ambientColor";
        //private const string constantAttenuation = "constantAttenuation";
        //private const string linearAttenuation = "linearAttenuation";
        //private const string quadraticAttenuation = "quadraticAttenuation";

        private CSharpGL.SpotLight light;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="position"></param>
        /// <param name="normal"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static SpotLightNode Create(CSharpGL.SpotLight light, IBufferSource model, string position, string normal, vec3 size) {
            var program = GLProgram.Create(spotLightVert, spotLightFrag); Debug.Assert(program != null);
            var map = new AttributeMap();
            map.Add(inPosition, position);
            map.Add(inNormal, normal);
            var builder = new RenderMethodBuilder(program, map);

            var node = new SpotLightNode(model, position, builder);
            node.light = light;
            node.ModelSize = size;
            node.Children.Add(new LegacyBoundingBoxNode(size));

            node.Initialize();

            return node;
        }

        private SpotLightNode(IBufferSource model, string positionNameInIBufferSource, params RenderMethodBuilder[] builders)
            : base(model, positionNameInIBufferSource, builders) {
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

        public void RenderBeforeChildren(RenderEventArgs arg) {
            RenderMethod method = this.RenderUnit.Methods[0];
            GLProgram program = method.Program;
            ICamera camera = arg.Camera;
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();
            mat4 normal = glm.transpose(glm.inverse(view * model));
            program.SetUniform(projectionMat, projection);
            program.SetUniform(viewMat, view);
            program.SetUniform(modelMat, model);
            program.SetUniform(normalMatrix, normal);
            program.SetUniform(lightPosition, new vec3(view * new vec4(light.Position, 1.0f)));
            program.SetUniform(lightColor, this.light.Diffuse);
            program.SetUniform(spotDirection, new vec3(view * new vec4(-light.Position, 0.0f)));

            method.Render();
        }

        public void RenderAfterChildren(RenderEventArgs arg) {
        }

        public vec3 MaterialColor {
            get {
                vec3 value = new vec3();
                if (this.RenderUnit != null && this.RenderUnit.Methods.Length > 0) {
                    RenderMethod method = this.RenderUnit.Methods[0];
                    GLProgram program = method.Program;
                    program.GetUniformValue(materialColor, out value);
                }

                return value;
            }
            set {
                if (this.RenderUnit != null && this.RenderUnit.Methods.Length > 0) {
                    RenderMethod method = this.RenderUnit.Methods[0];
                    GLProgram program = method.Program;
                    program.SetUniform(materialColor, value);
                }
            }
        }
    }
}
