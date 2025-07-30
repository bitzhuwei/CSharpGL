using CSharpGL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace SimpleObjFile {
    class TexturedNode : PickableNode, IRenderable {
        private const string vertexCode =
            @"#version 330

uniform mat4 projectionMat;
uniform mat4 viewMat;
uniform mat4 modelMat;

layout (location = 0) in vec3 inPosition;
layout (location = 1) in vec3 inNormal;
layout (location = 2) in vec2 inTexCoord;

out _Vertex
{
	vec3 viewSpacePos;
	vec3 viewSpaceNormal;
    vec2 texCoord;
} v;

void main(void)
{
    vec4 pos = viewMat * modelMat * vec4(inPosition, 1.0);
    v.viewSpacePos = vec3(pos);
    v.viewSpaceNormal = mat3(transpose(inverse(viewMat * modelMat))) * inNormal;
    v.texCoord = inTexCoord;
	gl_Position = projectionMat * pos;
}
";
        private const string fragmentCode =
            @"#version 330

layout (location = 0) out vec4 color;

in _Vertex
{
	vec3 viewSpacePos;
	vec3 viewSpaceNormal;
    vec2 texCoord;
} fsVertex;

uniform bool useTexture = false;
uniform sampler2D tex;
uniform vec3 materialColor = vec3(1, 0.6471, 0);

const vec3 lightPosition = vec3(0, 0, 0);

void main(void)
{
	vec3 N = normalize(fsVertex.viewSpaceNormal);
	vec3 L = normalize(lightPosition - fsVertex.viewSpacePos);
	float diffuse = max(dot(N, L), 0.0);
	
    if (useTexture) {
        color = vec4(diffuse * texture(tex, fsVertex.texCoord).rgb, 1.0);
    }
    else {
        color = vec4(diffuse * materialColor, 1.0);
    }
}
";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static TexturedNode Create(ObjVNFMesh mesh) {
            var model = new ObjVNF(mesh);
            RenderMethodBuilder builder;
            {
                var program = GLProgram.Create(vertexCode, fragmentCode); Debug.Assert(program != null);
                var map = new AttributeMap();
                map.Add("inPosition", ObjVNF.strPosition);
                map.Add("inNormal", ObjVNF.strNormal);
                map.Add("inTexCoord", ObjVNF.strTexCoord);
                builder = new RenderMethodBuilder(program, map);
            }
            var node = new TexturedNode(model, ObjVNF.strPosition, builder);
            node.ModelSize = model.GetSize();
            node.WorldPosition = model.GetPosition();

            node.Initialize();

            return node;
        }

        private TexturedNode(IBufferSource model, string positionNameInIBufferSource, params RenderMethodBuilder[] builders)
            : base(model, positionNameInIBufferSource, builders) {
        }

        private Texture texture;

        public Texture Texture {
            get { return texture; }
            set { texture = value; }
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
            if (!this.IsInitialized) { Initialize(); }

            ICamera camera = arg.Camera;
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();

            var method = this.RenderUnit.Methods[0];
            GLProgram program = method.Program;
            program.SetUniform("modelMat", model);
            program.SetUniform("viewMat", view);
            program.SetUniform("projectionMat", projection);
            Texture texture = this.texture;
            if (texture != null) {
                program.SetUniform("useTexture", true);
                program.SetUniform("tex", texture);
            }
            else {
                program.SetUniform("useTexture", false);
            }

            method.Render();
        }

        public void RenderAfterChildren(RenderEventArgs arg) {
        }
    }
}
