using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace ShadowMapping
{
    /// <summary>
    /// render a teapot with shadow.
    /// </summary>
    class ShadowTeapotRenderer : ModernNode, IShadowMapping
    {
        private const string inPosition = "inPosition";
        private const string mvpMatrix = "mvpMatrix";

        private const string shadowVertexCode =
            @"#version 330

uniform mat4 " + mvpMatrix + @";

layout (location = 0) in vec4 " + inPosition + @";;

void main(void)
{
	gl_Position = mvpMatrix * inPosition;
}
";
        // this fragment shader is not needed.
        //        private const string shadowFragmentCode =
        //            @"#version 330 core
        //
        //layout(location = 0) out float fragmentdepth;
        ////out vec4 out_Color;
        //
        //void main(void) {
        //    fragmentdepth = gl_FragCoord.z;
        //
        //}
        //";

        private const string lightVertexCode =
            @"#version 330

uniform mat4 model_matrix;
uniform mat4 view_matrix;
uniform mat4 projection_matrix;

uniform mat4 shadow_matrix;

layout (location = 0) in vec4 position;
layout (location = 1) in vec3 normal;

out VS_FS_INTERFACE
{
	vec4 shadow_coord;
	vec3 world_coord;
	vec4 eye_coord;
	vec3 normal;
} vertex;

void main(void)
{
	vec4 world_pos = model_matrix * position;
	vec4 eye_pos = view_matrix * world_pos;
	vec4 clip_pos = projection_matrix * eye_pos;
	
	vertex.world_coord = world_pos.xyz;
	vertex.eye_coord = eye_pos.xyz;
	vertex.shadow_coord = shadow_matrix * world_pos;
	vertex.normal = mat3(view_matrix * model_matrix) * normal;
	
	gl_Position = clip_pos;
}
";
        private const string lightFragmentCode =
            @"#version 330

uniform sampler2DShadow depth_texture;
uniform vec3 light_position;

uniform vec3 material_ambient;
uniform vec3 material_diffuse;
uniform vec3 material_specular;
uniform float material_specular_power;

layout (location = 0) out vec4 color;

in VS_FS_INTERFACE
{
	vec4 shadow_coord;
	vec3 world_coord;
	vec3 eye_coord;
	vec3 normal;
} fragment;

void maint(void)
{
	vec3 N = fragment.normal;
	vec3 L = normalize(light_position - fragment.world_coord);
	vec3 R = reflect(-L, N);
	vec3 E = normalize(fragment.eye_coord);
	float NdotL = dot(N, L);
	float EdotR = dot(-E, R);
	float diffuse = max(NdotL, 0.0);
	float specular = max(pow(EdotR, material_specular_power), 0.0);
	float f = textureProj(depth_texture, fragment. shadow_coord);
	
	color = vec4(material_ambient + f * (material_diffuse * diffuse + material_specular * specular), 1.0);
}
";

        /// <summary>
        /// Render teapot to framebuffer in modern opengl.
        /// </summary>
        /// <returns></returns>
        public static ShadowTeapotRenderer Create()
        {
            RenderUnitBuilder shadowBuilder, lightBuilder;
            {
                var vs = new VertexShader(shadowVertexCode, inPosition);
                var provider = new ShaderArray(vs);
                var map = new AttributeMap();
                map.Add(inPosition, Teapot.strPosition);
                shadowBuilder = new RenderUnitBuilder(provider, map);
            }
            {
                var vs = new VertexShader(lightVertexCode, inPosition);
                var fs = new FragmentShader(lightFragmentCode);
                var provider = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add(inPosition, Teapot.strPosition);
                lightBuilder = new RenderUnitBuilder(provider, map);
            }
            var model = new Teapot();
            var renderer = new ShadowTeapotRenderer(model, shadowBuilder, lightBuilder);
            renderer.Initialize();

            return renderer;
        }

        private ShadowTeapotRenderer(Teapot model, params RenderUnitBuilder[] builder)
            : base(model, builder)
        {
            this.ModelSize = model.GetModelSize();
        }

        #region IRenderable 成员

        public float RotateSpeed { get; set; }

        public override void RenderBeforeChildren(RenderEventArgs arg)
        {
            if (!this.IsInitialized) { Initialize(); }

            this.RotationAngle += this.RotateSpeed;

            ICamera camera = arg.CameraStack.Peek();
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();

            var renderUnit = this.RenderUnits[1]; // the only render unit in this renderer.
            ShaderProgram program = renderUnit.Program;
            program.SetUniform(mvpMatrix, projection * view * model);

            renderUnit.Render();
        }

        #endregion


        #region IShadowMapping 成员

        private bool enableShadowMapping = true;

        public bool EnableShadowMapping
        {
            get { return enableShadowMapping; }
            set { enableShadowMapping = value; }
        }

        public void CastShadow(ShdowMappingEventArgs arg)
        {
            if (!this.IsInitialized) { this.Initialize(); }

            this.RotationAngle += this.RotateSpeed;

            LightBase light = arg.CurrentLight;
            mat4 projection = light.GetProjectionMatrix(arg);
            mat4 view = light.GetViewMatrix(arg);
            mat4 model = this.GetModelMatrix();

            var renderUnit = this.RenderUnits[0]; // the only render unit in this renderer.
            ShaderProgram program = renderUnit.Program;
            program.SetUniform(mvpMatrix, projection * view * model);

            renderUnit.Render();
        }

        #endregion


        public override void RenderAfterChildren(RenderEventArgs arg)
        {
        }
    }
}
