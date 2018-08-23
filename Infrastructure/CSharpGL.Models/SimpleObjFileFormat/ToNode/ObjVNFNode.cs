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
        private const string model_matrix = "model_matrix";
        private const string view_matrix = "view_matrix";
        private const string projection_matrix = "projection_matrix";
        private const string material_ambient = "material_ambient";
        private const string material_diffuse = "material_diffuse";
        private const string material_specular = "material_specular";
        private const string material_specular_power = "material_specular_power";
        private const string light_position = "light_position";

        private const string vertexCode =
            @"#version 330

uniform mat4 " + model_matrix + @";
uniform mat4 " + view_matrix + @";
uniform mat4 " + projection_matrix + @";

layout (location = 0) in vec4 " + inPosition + @";
layout (location = 1) in vec3 " + inNormal + @";

out _Vertex
{
	vec3 world_coord;
	vec3 eye_coord;
	vec3 normal;
} v;

void main(void)
{
	vec4 world_pos = model_matrix * position;
	vec4 eye_pos = view_matrix * world_pos;
	vec4 clip_pos = projection_matrix * eye_pos;
	
	v.world_coord = world_pos.xyz;
	v.eye_coord = eye_pos.xyz;
	v.normal = normalize(mat3(view_matrix * model_matrix) * normal);
	
	gl_Position = clip_pos;
}
";
        private const string fragmentCode =
            @"#version 330

uniform vec3 " + material_ambient + @" = vec3(0.2, 0.2, 0.2);
uniform vec3 " + material_diffuse + @";
uniform vec3 " + material_specular + @";
uniform float " + material_specular_power + @";

uniform vec3 " + light_position + @";

layout (location = 0) out vec4 color;

in _Vertex
{
	vec3 world_coord;
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
	float specular = 0;//max(pow(EdotR, material_specular_power), 0.0);
	
	color = vec4(material_ambient + material_diffuse * diffuse + material_specular * specular, 1.0);
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
                    program.GetUniformValue(material_ambient, out value);
                }
                return value;
            }
            set
            {
                if (this.RenderUnit != null && this.RenderUnit.Methods.Length > 0)
                {
                    var method = this.RenderUnit.Methods[0];
                    ShaderProgram program = method.Program;
                    program.SetUniform(material_ambient, value);
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
            program.SetUniform(model_matrix, model);
            program.SetUniform(view_matrix, view);
            program.SetUniform(projection_matrix, projection);
            program.SetUniform(light_position, new vec3(view * new vec4(LightPosition, 1.0f)));
            //program.SetUniform(material_ambient, this.Ambient);
            program.SetUniform(material_diffuse, this.Diffuse);
            program.SetUniform(material_specular, this.Specular);
            program.SetUniform(material_specular_power, this.SpecularPower);

            method.Render();
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }
    }
}
