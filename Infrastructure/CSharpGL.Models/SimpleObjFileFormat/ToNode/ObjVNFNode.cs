using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ObjVNFNode : PickableNode, IRenderable
    {
        private const string inPosition = "position";
        private const string inNormal = "normal";
        private const string modelMat = "modelMat";
        private const string viewMat = "viewMat";
        private const string projectionMat = "projectionMat";
        private const string materialAmbient = "materialAmbient";
        private const string materialDiffuse = "materialDiffuse";
        private const string materialSpecular = "materialSpecular";
        private const string materialSpecularPower = "materialSpecularPower";
        private const string light_position = "light_position";

        private const string vertexCode =
            @"#version 330

uniform mat4 " + modelMat + @";
uniform mat4 " + viewMat + @";
uniform mat4 " + projectionMat + @";

layout (location = 0) in vec4 " + inPosition + @";
layout (location = 1) in vec3 " + inNormal + @";

out _Vertex
{
	vec3 worldPos;
	vec3 eye_coord;
	vec3 normal;
} v;

void main(void)
{
	vec4 world_pos = modelMat * position;
	vec4 eye_pos = viewMat * world_pos;
	vec4 clip_pos = projectionMat * eye_pos;
	
	v.worldPos = world_pos.xyz;
	v.eye_coord = eye_pos.xyz;
	v.normal = normalize(mat3(viewMat * modelMat) * normal);
	
	gl_Position = clip_pos;
}
";
        private const string fragmentCode =
            @"#version 330

uniform vec3 " + materialAmbient + @" = vec3(0.2, 0.2, 0.2);
uniform vec3 " + materialDiffuse + @";
uniform vec3 " + materialSpecular + @";
uniform float " + materialSpecularPower + @";

uniform vec3 " + light_position + @";

layout (location = 0) out vec4 color;

in _Vertex
{
	vec3 worldPos;
	vec3 eye_coord;
	vec3 normal;
} fsVertex;

void main(void)
{
	vec3 N = normalize(fsVertex.normal);
	vec3 L = normalize(light_position - fsVertex.eye_coord);
	vec3 R = reflect(L, N);
	vec3 E = normalize(fsVertex.eye_coord);
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
        public static ObjVNFNode Create(ObjVNFMesh mesh)
        {
            var model = new ObjVNF(mesh);
            RenderMethodBuilder builder;
            {
                var vs = new VertexShader(vertexCode);
                var fs = new FragmentShader(fragmentCode);
                var provider = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add(inPosition, Teapot.strPosition);
                map.Add(inNormal, Teapot.strNormal);
                builder = new RenderMethodBuilder(provider, map);
            }
            var node = new ObjVNFNode(model, ObjVNF.strPosition, builder);
            node.ModelSize = model.GetSize();
            node.WorldPosition = model.GetPosition();

            node.Initialize();

            return node;
        }

        private ObjVNFNode(IBufferSource model, string positionNameInIBufferSource, params RenderMethodBuilder[] builders)
            : base(model, positionNameInIBufferSource, builders)
        {
            this.Diffuse = System.Drawing.Color.Orange.ToVec3();
            this.Specular = new vec3(1, 1, 1) * 0.2f;
            this.SpecularPower = 0.2f;
            this.LightPosition = new vec3(1, 1, 1) * 10;
        }

        /// <summary>
        /// 
        /// </summary>
        public vec3 Ambient
        {
            get
            {
                vec3 value = new vec3();
                if (this.RenderUnit != null && this.RenderUnit.Methods.Length > 0)
                {
                    var method = this.RenderUnit.Methods[0];
                    ShaderProgram program = method.Program;
                    program.GetUniformValue(materialAmbient, out value);
                }
                return value;
            }
            set
            {
                if (this.RenderUnit != null && this.RenderUnit.Methods.Length > 0)
                {
                    var method = this.RenderUnit.Methods[0];
                    ShaderProgram program = method.Program;
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
        public ThreeFlags EnableRendering
        {
            get { return this.enableRendering; }
            set { this.enableRendering = value; }
        }

        public void RenderBeforeChildren(RenderEventArgs arg)
        {
            if (!this.IsInitialized) { Initialize(); }

            ICamera camera = arg.Camera;
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();

            var method = this.RenderUnit.Methods[0];
            ShaderProgram program = method.Program;
            program.SetUniform(modelMat, model);
            program.SetUniform(viewMat, view);
            program.SetUniform(projectionMat, projection);
            program.SetUniform(light_position, new vec3(view * new vec4(LightPosition, 1.0f)));
            //program.SetUniform(materialAmbient, this.Ambient);
            program.SetUniform(materialDiffuse, this.Diffuse);
            program.SetUniform(materialSpecular, this.Specular);
            program.SetUniform(materialSpecularPower, this.SpecularPower);

            method.Render();
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }
    }
}
