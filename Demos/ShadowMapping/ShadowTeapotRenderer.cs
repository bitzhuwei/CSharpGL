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
    class ShadowTeapotRenderer : Renderer, IShadowMapping
    {

        private const string inPosition = "inPosition";
        private const string projectionMatrix = "projectionMatrix";
        private const string viewMatrix = "viewMatrix";
        private const string modelMatrix = "modelMatrix";

        private const string shadowVertexCode =
            @"#version 330 core

in vec3 " + inPosition + @";

uniform mat4 " + projectionMatrix + @";
uniform mat4 " + viewMatrix + @";
uniform mat4 " + modelMatrix + @";

void main(void) {
	gl_Position = projectionMatrix * viewMatrix * modelMatrix * vec4(inPosition, 1.0);
}
";
        // this fragment shader is not needed.
        //        private const string fragmentCode =
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
layout (location = 0) in vec3 Position;
layout (location = 1) in vec2 TexCoord;
layout (location = 2) in vec3 Normal;
uniform mat4 gWVP;
uniform mat4 gLightWVP;
uniform mat4 gWorld;
out vec4 LightSpacePos;
out vec2 TexCoord0;
out vec3 Normal0;
out vec3 WorldPos0;
void main()
{
    gl_Position = gWVP * vec4(Position, 1.0);
    LightSpacePos = gLightWVP * vec4(Position, 1.0);
    TexCoord0 = TexCoord;
    Normal0 = (gWorld * vec4(Normal, 0.0)).xyz;
    WorldPos0 = (gWorld * vec4(Position, 1.0)).xyz;
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
            var shadowVertexShader = new VertexShader(shadowVertexCode, inPosition);
            var shadowProvider = new ShaderArray(shadowVertexShader);
            //var lightVertexShader = new VertexShader(lightVertexCode,)
            var map = new AttributeMap();
            map.Add(inPosition, Teapot.strPosition);
            var model = new Teapot();
            var builder = new RenderUnitBuilder(shadowProvider, map);
            var renderer = new ShadowTeapotRenderer(model, builder);
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
            base.RenderBeforeChildren(arg);

            this.RotationAngle += this.RotateSpeed;

            ICamera camera = arg.CameraStack.Peek();
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();

            var renderUnit = this.RenderUnits[0]; // the only render unit in this renderer.
            ShaderProgram program = renderUnit.Program;
            program.SetUniform(projectionMatrix, projection);
            program.SetUniform(viewMatrix, view);
            program.SetUniform(modelMatrix, model);

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
            program.SetUniform(projectionMatrix, projection);
            program.SetUniform(viewMatrix, view);
            program.SetUniform(modelMatrix, model);

            renderUnit.Render();
        }

        #endregion

    }
}
