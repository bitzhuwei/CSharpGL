﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL {
    /// <summary>
    /// 
    /// </summary>
    public partial class ObjVNFNode : PickableNode, IRenderable {
        private const string inPosition = "position";
        private const string inNormal = "inNormal";
        private const string modelMat = "modelMat";
        private const string viewMat = "viewMat";
        private const string projectionMat = "projectionMat";
        private const string materialAmbient = "materialAmbient";
        private const string materialDiffuse = "materialDiffuse";
        private const string materialSpecular = "materialSpecular";
        private const string materialSpecularPower = "materialSpecularPower";
        private const string lightPosition = "lightPosition";

        private const string vertexCode =
            @"#version 330

uniform mat4 " + modelMat + @";
uniform mat4 " + viewMat + @";
uniform mat4 " + projectionMat + @";

layout (location = 0) in vec4 " + inPosition + @";
layout (location = 1) in vec3 " + inNormal + @";

out _Vertex
{
	vec3 worldSpacePos;
	vec3 eyeSpacePos;
	vec3 eyeSpaceNormal;
} v;

void main(void)
{
	vec4 worldPos = modelMat * position;
	vec4 eyePos = viewMat * worldPos;
	vec4 clipPos = projectionMat * eyePos;
	
	v.worldSpacePos = worldPos.xyz;
	v.eyeSpacePos = eyePos.xyz;
	v.eyeSpaceNormal = normalize(mat3(viewMat * modelMat) * inNormal);
	
	gl_Position = clipPos;
}
";
        private const string fragmentCode =
            @"#version 330

uniform vec3 " + materialAmbient + @" = vec3(0.2, 0.2, 0.2);
uniform vec3 " + materialDiffuse + @";
uniform vec3 " + materialSpecular + @";
uniform float " + materialSpecularPower + @";

uniform vec3 " + lightPosition + @";

layout (location = 0) out vec4 color;

in _Vertex
{
	vec3 worldSpacePos;
	vec3 eyeSpacePos;
	vec3 eyeSpaceNormal;
} fsVertex;

void main(void)
{
	vec3 N = normalize(fsVertex.eyeSpaceNormal);
	vec3 L = normalize(lightPosition - fsVertex.eyeSpacePos);
	vec3 R = reflect(L, N);
	vec3 E = normalize(fsVertex.eyeSpacePos);
	float NdotL = dot(N, L);
	float EdotR = dot(E, R);
	float diffuse = max(NdotL, 0.0);
	float specular = 0;//max(pow(EdotR, materialSpecularPower), 0.0);
	
	color = vec4(materialAmbient + materialDiffuse * diffuse + materialSpecular * specular, 1.0);
}
";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static ObjVNFNode Create(ObjVNFMesh mesh) {
            var model = new ObjVNF(mesh);
            RenderMethodBuilder builder;
            {
                var program = GLProgram.Create(vertexCode, fragmentCode); System.Diagnostics.Debug.Assert(program != null);
                var map = new AttributeMap();
                map.Add(inPosition, Teapot.strPosition);
                map.Add(inNormal, Teapot.strNormal);
                builder = new RenderMethodBuilder(program, map);
            }
            var node = new ObjVNFNode(model, ObjVNF.strPosition, builder);
            node.ModelSize = model.GetSize();
            node.WorldPosition = model.GetPosition();

            node.Initialize();

            return node;
        }

        private ObjVNFNode(IBufferSource model, string positionNameInIBufferSource, params RenderMethodBuilder[] builders)
            : base(model, positionNameInIBufferSource, builders) {
            this.Diffuse = System.Drawing.Color.Orange.ToVec3();
            this.Specular = new vec3(1, 1, 1) * 0.2f;
            this.SpecularPower = 0.2f;
            this.LightPosition = new vec3(1, 1, 1) * 10;
        }

        /// <summary>
        /// 
        /// </summary>
        public vec3 Ambient {
            get {
                vec3 value = new vec3();
                if (this.RenderUnit != null && this.RenderUnit.Methods.Length > 0) {
                    var method = this.RenderUnit.Methods[0];
                    GLProgram program = method.Program;
                    program.GetUniformValue(materialAmbient, out value);
                }
                return value;
            }
            set {
                if (this.RenderUnit != null && this.RenderUnit.Methods.Length > 0) {
                    var method = this.RenderUnit.Methods[0];
                    GLProgram program = method.Program;
                    program.SetUniform(materialAmbient, value);
                }
            }
        }
        public vec3 Diffuse { get; set; }
        public vec3 Specular { get; set; }
        public float SpecularPower { get; set; }

        /// <summary>
        /// light's position in world space.
        /// </summary>
        public vec3 LightPosition { get; set; }

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
            if (!this.IsInitialized) { Initialize(); }

            ICamera camera = arg.Camera;
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();

            var method = this.RenderUnit.Methods[0];
            GLProgram program = method.Program;
            program.SetUniform(modelMat, model);
            program.SetUniform(viewMat, view);
            program.SetUniform(projectionMat, projection);
            program.SetUniform(lightPosition, new vec3(view * new vec4(LightPosition, 1.0f)));
            //program.SetUniform(materialAmbient, this.Ambient);
            program.SetUniform(materialDiffuse, this.Diffuse);
            program.SetUniform(materialSpecular, this.Specular);
            program.SetUniform(materialSpecularPower, this.SpecularPower);

            method.Render();
        }

        public void RenderAfterChildren(RenderEventArgs arg) {
        }
    }
}
