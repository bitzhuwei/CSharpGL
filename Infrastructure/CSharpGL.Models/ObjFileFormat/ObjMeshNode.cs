using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL.Models
{
    /// <summary>
    /// contains a single mesh.
    /// </summary>
    public class ObjMeshNode : PickableNode
    {

        private const string inPosition = "position";
        private const string inNormal = "normal";
        private const string model_matrix = "model_matrix";
        private const string view_matrix = "view_matrix";
        private const string projection_matrix = "projection_matrix";
        private const string light_position = "light_position";
        private const string material_ambient = "material_ambient";
        private const string material_diffuse = "material_diffuse";
        private const string material_specular = "material_specular";
        private const string material_specular_power = "material_specular_power";

        private const string vertexCode =
            @"#version 330

uniform mat4 " + model_matrix + @";
uniform mat4 " + view_matrix + @";
uniform mat4 " + projection_matrix + @";

layout (location = 0) in vec4 " + inPosition + @";
layout (location = 1) in vec3 " + inNormal + @";

out VS_FS_INTERFACE
{
	vec3 world_coord;
	vec3 eye_coord;
	vec3 normal;
} vertex;

void main(void)
{
	vec4 world_pos = model_matrix * position;
	vec4 eye_pos = view_matrix * world_pos;
	vec4 clip_pos = projection_matrix * eye_pos;
	
	vertex.world_coord = world_pos.xyz;
	vertex.eye_coord = eye_pos.xyz;
	vertex.normal = normalize(mat3(view_matrix * model_matrix) * normal);
	
	gl_Position = clip_pos;
}
";
        private const string fragmentCode =
            @"#version 330

uniform vec3 " + light_position + @";

uniform vec3 " + material_ambient + @";
uniform vec3 " + material_diffuse + @";
uniform vec3 " + material_specular + @";
uniform float " + material_specular_power + @";

layout (location = 0) out vec4 color;

in VS_FS_INTERFACE
{
	vec4 shadow_coord;
	vec3 world_coord;
	vec3 eye_coord;
	vec3 normal;
} fragment;

void main(void)
{
	vec3 N = normalize(fragment.normal);
	vec3 L = normalize(light_position - fragment.eye_coord);
	vec3 R = reflect(L, N);
	vec3 E = normalize(fragment.eye_coord);
	float NdotL = dot(N, L);
	float EdotR = dot(E, R);
	float diffuse = max(NdotL, 0.0);
	float specular = max(pow(EdotR, material_specular_power), 0.0);
	
	color = vec4(material_ambient + material_diffuse * diffuse + material_specular * specular, 1.0);
}
";


        public static ObjMeshNode Create(ObjMesh mesh)
        {
            RenderUnitBuilder builder;
            {
                var vs = new VertexShader(vertexCode, inPosition, inNormal);
                var fs = new FragmentShader(fragmentCode);
                var provider = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add(ObjMesh2Buffer.strPosition, inPosition);
                map.Add(ObjMesh2Buffer.strNormal, inNormal);
                builder = new RenderUnitBuilder(provider, map);
            }

            var model = new ObjMesh2Buffer(mesh);

            var node = new ObjMeshNode(model, ObjMesh2Buffer.strPosition, builder);
            node.ModelSize = mesh.size;
            node.WorldPosition = mesh.position;
            node.Initialize();

            return node;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="positionNameInIBufferSource"></param>
        /// <param name="builders"></param>
        private ObjMeshNode(ObjMesh2Buffer model, string positionNameInIBufferSource, params RenderUnitBuilder[] builders)
            : base(model, positionNameInIBufferSource, builders)
        {
            this.Ambient = new vec3(1, 1, 1) * 0.2f;
            this.Diffuse = System.Drawing.Color.SkyBlue.ToVec3();
            this.Specular = new vec3(1, 1, 1) * 0.1f;
            this.SpecularPower = 0.2f;
            this.LightPositon = new vec3(1, 1, 1) * 10;
        }

        public vec3 LightPositon { get; set; }

        public float RotateSpeed { get; set; }

        public vec3 Ambient { get; set; }
        public vec3 Diffuse { get; set; }
        public vec3 Specular { get; set; }
        public float SpecularPower { get; set; }

        public override void RenderBeforeChildren(RenderEventArgs arg)
        {
            if (!this.IsInitialized) { Initialize(); }

            this.RotationAngle += this.RotateSpeed;

            ICamera camera = arg.CameraStack.Peek();
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();

            var renderUnit = this.RenderUnits[0]; // the only render unit in this node.
            ShaderProgram program = renderUnit.Program;
            program.SetUniform(model_matrix, model);
            program.SetUniform(view_matrix, view);
            program.SetUniform(projection_matrix, projection);
            program.SetUniform(light_position, new vec3(view * new vec4(this.LightPositon, 1.0f)));
            program.SetUniform(material_ambient, this.Ambient);
            program.SetUniform(material_diffuse, this.Diffuse);
            program.SetUniform(material_specular, this.Specular);
            program.SetUniform(material_specular_power, this.SpecularPower);

            renderUnit.Render();
        }

        public override void RenderAfterChildren(RenderEventArgs arg)
        {

        }
    }
}
