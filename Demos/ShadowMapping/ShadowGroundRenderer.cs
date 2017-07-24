using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Render a Ground(two triangles) with single color in modern opengl.
    /// </summary>
    public class ShadowGroundRenderer : PickableNode, IShadowMapping
    {
        private const string inPosition = "inPosition";
        private const string inNormal = "inNormal";
        private const string mvpMatrix = "mvpMatrix";
        private const string model_matrix = "model_matrix";
        private const string view_matrix = "view_matrix";
        private const string projection_matrix = "projection_matrix";
        private const string shadow_matrix = "shadow_matrix";
        private const string depth_texture = "depth_texture";
        private const string light_position = "light_position";
        private const string material_ambient = "material_ambient";
        private const string material_diffuse = "material_diffuse";
        private const string material_specular = "material_specular";
        private const string material_specular_power = "material_specular_power";

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

uniform mat4 " + model_matrix + @";
uniform mat4 " + view_matrix + @";
uniform mat4 " + projection_matrix + @";

uniform mat4 " + shadow_matrix + @";

layout (location = 0) in vec4 " + inPosition + @";
layout (location = 1) in vec3 " + inNormal + @";

out VS_FS_INTERFACE
{
	vec4 shadow_coord;
	vec3 world_coord;
	vec3 eye_coord;
	vec3 normal;
} vertex;

void main(void)
{
	vec4 world_pos = model_matrix * inPosition;
	vec4 eye_pos = view_matrix * world_pos;
	vec4 clip_pos = projection_matrix * eye_pos;
	
	vertex.world_coord = world_pos.xyz;
	vertex.eye_coord = eye_pos.xyz;
	vertex.shadow_coord = shadow_matrix * world_pos;
	vertex.normal = mat3(view_matrix * model_matrix) * inNormal;
	
	gl_Position = clip_pos;
}
";
        private const string lightFragmentCode =
            @"#version 330

uniform sampler2DShadow " + depth_texture + @";
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
    vec3 N = fragment.normal;
    vec3 L = normalize(light_position - fragment.world_coord);
    float LdotN = dot(N, L);
    vec3 R = reflect(-L, N);

    float diffuse = max(LdotN, 0.0);
    float specular = max(pow(dot(normalize(-fragment.eye_coord), R), material_specular_power), 0.0);

    float f = textureProj(depth_texture, fragment.shadow_coord);

    color = vec4(material_ambient + f * (material_diffuse * diffuse + material_specular * specular), 1.0);
    //color = vec4(0,f,f,1) + color * 0.01f;
}
";

        /// <summary>
        /// Render propeller in modern opengl.
        /// </summary>
        /// <returns></returns>
        public static ShadowGroundRenderer Create()
        {
            RenderUnitBuilder shadowmapBuilder, renderBuilder;
            {
                var vs = new VertexShader(shadowVertexCode, inPosition);
                var provider = new ShaderArray(vs);
                var map = new AttributeMap();
                map.Add(inPosition, GroundModel.strPosition);
                shadowmapBuilder = new RenderUnitBuilder(provider, map);
            }
            {
                var vs = new VertexShader(lightVertexCode, inPosition, inNormal);
                var fs = new FragmentShader(lightFragmentCode);
                var provider = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add(inPosition, GroundModel.strPosition);
                map.Add(inNormal, GroundModel.strNormal);
                renderBuilder = new RenderUnitBuilder(provider, map);
            }
            var renderer = new ShadowGroundRenderer(new GroundModel(), GroundModel.strPosition, shadowmapBuilder, renderBuilder);
            renderer.Initialize();

            return renderer;
        }

        /// <summary>
        /// Render propeller in legacy opengl.
        /// </summary>
        private ShadowGroundRenderer(GroundModel model, string positionNameInIBufferable, params RenderUnitBuilder[] builders)
            : base(model, positionNameInIBufferable, builders)
        {
            this.ModelSize = model.ModelSize;
            this.Ambient = new vec3(1, 1, 1) * 0.1f;
            this.Diffuse = System.Drawing.Color.Orange.ToVec3();
            this.Specular = new vec3(1, 1, 1) * 0.2f;
            this.SpecularPower = 0.2f;
        }

        public vec3 Ambient { get; set; }
        public vec3 Diffuse { get; set; }
        public vec3 Specular { get; set; }
        public float SpecularPower { get; set; }

        public override void RenderBeforeChildren(RenderEventArgs arg)
        {
            if (!this.IsInitialized) { Initialize(); }

            ICamera camera = arg.CameraStack.Peek();
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();
            List<LightBase> lights = arg.CurrentLights.Peek();
            LightBase light = lights[0];// now we only use one light for testing.
            mat4 lightBias = glm.scale(mat4.identity(), new vec3(1, 1, 1) * 0.5f);
            lightBias = glm.translate(lightBias, new vec3(1, 1, 1) * 0.5f);
            mat4 lightProjection = light.GetProjectionMatrix();
            mat4 lightView = light.GetViewMatrix();

            var renderUnit = this.RenderUnits[1]; // the only render unit in this renderer.
            ShaderProgram program = renderUnit.Program;
            program.SetUniform(mvpMatrix, projection * view * model);
            program.SetUniform(model_matrix, model);
            program.SetUniform(view_matrix, view);
            program.SetUniform(projection_matrix, projection);
            program.SetUniform(shadow_matrix, lightProjection * lightView);
            program.SetUniform(depth_texture, light.BindingTexture);
            program.SetUniform(light_position, light.Position);
            program.SetUniform(material_ambient, this.Ambient);
            program.SetUniform(material_diffuse, this.Diffuse);
            program.SetUniform(material_specular, this.Specular);
            program.SetUniform(material_specular_power, this.SpecularPower);

            renderUnit.Render();
        }

        public override void RenderAfterChildren(RenderEventArgs arg)
        {
        }

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

            LightBase light = arg.CurrentLight;
            mat4 projection = light.GetProjectionMatrix();
            mat4 view = light.GetViewMatrix();
            mat4 model = this.GetModelMatrix();

            var renderUnit = this.RenderUnits[0]; // shadowmapBuilder
            ShaderProgram program = renderUnit.Program;
            program.SetUniform(mvpMatrix, projection * view * model);

            renderUnit.Render();
        }

        #endregion

        class GroundModel : IBufferSource
        {
            public vec3 ModelSize { get; private set; }

            public GroundModel()
            {
                this.ModelSize = new vec3(xLength * 2, yLength * 2, zLength * 2);
            }

            public const string strPosition = "position";
            private VertexBuffer positionBuffer;
            public const string strNormal = "normal";
            private VertexBuffer normalBuffer;

            private IndexBuffer indexBuffer;

            #region IBufferable 成员

            public VertexBuffer GetVertexAttributeBuffer(string bufferName)
            {
                if (bufferName == strPosition)
                {
                    if (this.positionBuffer == null)
                    {
                        this.positionBuffer = positions.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
                    }

                    return this.positionBuffer;
                }
                else if (bufferName == strNormal)
                {
                    if (this.normalBuffer == null)
                    {
                        this.normalBuffer = normals.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
                    }

                    return this.normalBuffer;
                }

                throw new NotImplementedException();
            }

            public IndexBuffer GetIndexBuffer()
            {
                if (this.indexBuffer == null)
                {
                    this.indexBuffer = ZeroIndexBuffer.Create(DrawMode.Quads, 0, positions.Length);
                }

                return this.indexBuffer;
            }

            #endregion

            private const float xLength = 0.5f;
            private const float yLength = 0.5f;
            private const float zLength = 0.5f;
            /// <summary>
            /// four vertexes.
            /// </summary>
            private static readonly vec3[] positions = new vec3[]
            {
                new vec3(+xLength, 0, +zLength),//  0
                new vec3(+xLength, 0, -zLength),//  1
                new vec3(-xLength, 0, -zLength),//  2
                new vec3(-xLength, 0, +zLength),//  3
            };
            /// <summary>
            /// four vertexes.
            /// </summary>
            private static readonly vec3[] normals = new vec3[]
            {
                new vec3(0, 1, 0),//  0
                new vec3(0, 1, 0),//  1
                new vec3(0, 1, 0),//  2
                new vec3(0, 1, 0),//  3
            };
        }

    }
}