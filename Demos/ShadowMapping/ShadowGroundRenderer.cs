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
        private const string color = "color";
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
        //        private const string fragmentCode =
        //            @"#version 330 core
        //
        //uniform vec4 " + color + @";
        //
        //layout(location = 0) out vec4 out_Color;
        ////out vec4 out_Color;
        //
        //void main(void) {
        //    out_Color = color;
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
        /// 
        /// </summary>
        public vec4 Color { get; set; }

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
                var vs = new VertexShader(lightVertexCode, inPosition);
                var fs = new FragmentShader(lightFragmentCode);
                var provider = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add(inPosition, GroundModel.strPosition);
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
            this.Color = new vec4(1, 1, 1, 1);
        }

        public override void RenderBeforeChildren(RenderEventArgs arg)
        {
            //base.RenderBeforeChildren(arg);

            //ICamera camera = arg.CameraStack.Peek();
            //mat4 projection = camera.GetProjectionMatrix();
            //mat4 view = camera.GetViewMatrix();
            //mat4 model = this.GetModelMatrix();

            //var renderUnit = this.RenderUnits[1]; // renderBuilder
            //ShaderProgram program = renderUnit.Program;
            //program.SetUniform(projectionMatrix, projection);
            //program.SetUniform(viewMatrix, view);
            //program.SetUniform(modelMatrix, model);
            //program.SetUniform(color, this.Color);

            //renderUnit.Render();
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
            mat4 projection = light.GetProjectionMatrix(arg);
            mat4 view = light.GetViewMatrix(arg);
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
        }

    }
}