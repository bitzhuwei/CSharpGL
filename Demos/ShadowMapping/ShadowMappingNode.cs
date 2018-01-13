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
    public partial class ShadowMappingNode : PickableNode, IShadowMapping
    {
        private const string inPosition = "position";
        private const string inNormal = "normal";
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
        /// <summary>
        /// Render teapot to framebuffer in modern opengl.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="position"></param>
        /// <param name="normal"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static ShadowMappingNode Create(IBufferSource model, string position, string normal, vec3 size)
        {
            RenderMethodBuilder shadowBuilder, lightBuilder;
            {
                var vs = new VertexShader(shadowVertexCode);
                var provider = new ShaderArray(vs);
                var map = new AttributeMap();
                map.Add(inPosition, position);
                shadowBuilder = new RenderMethodBuilder(provider, map);
            }
            {
                var vs = new VertexShader(lightVertexCode);
                var fs = new FragmentShader(lightFragmentCode);
                var provider = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add(inPosition, position);
                map.Add(inNormal, normal);
                lightBuilder = new RenderMethodBuilder(provider, map);
            }
            var node = new ShadowMappingNode(model, position, shadowBuilder, lightBuilder);
            node.ModelSize = size;
            node.Initialize();

            return node;
        }

        private ShadowMappingNode(IBufferSource model, string positionNameInIBufferSource, params RenderMethodBuilder[] builder)
            : base(model, positionNameInIBufferSource, builder)
        {
            this.Ambient = new vec3(1, 1, 1) * 0.2f;
            this.Diffuse = System.Drawing.Color.SkyBlue.ToVec3();
            this.Specular = new vec3(1, 1, 1) * 0.1f;
            this.SpecularPower = 0.2f;
        }

        #region IRenderable 成员

        public float RotateSpeed { get; set; }

        public vec3 Ambient { get; set; }
        public vec3 Diffuse { get; set; }
        public vec3 Specular { get; set; }
        public float SpecularPower { get; set; }

        public override void RenderBeforeChildren(RenderEventArgs arg)
        {
            if (!this.IsInitialized) { Initialize(); }

            //this.RotationAngle += this.RotateSpeed;

            ICamera camera = arg.CameraStack.Peek();
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();
            List<LightBase> lights = arg.CurrentLights.Peek();
            LightBase light = lights[0];// now we only use one light for testing.
            mat4 lightBias = glm.translate(mat4.identity(), new vec3(1, 1, 1) * 0.5f);
            lightBias = glm.scale(lightBias, new vec3(1, 1, 1) * 0.5f);
            mat4 lightProjection = light.GetProjectionMatrix();
            mat4 lightView = light.GetViewMatrix();

            var method = this.RenderUnit.Methods[1];
            ShaderProgram program = method.Program;
            program.SetUniform(mvpMatrix, projection * view * model);
            program.SetUniform(model_matrix, model);
            program.SetUniform(view_matrix, view);
            program.SetUniform(projection_matrix, projection);
            program.SetUniform(shadow_matrix, lightBias * lightProjection * lightView);
            program.SetUniform(depth_texture, light.BindingTexture);
            program.SetUniform(light_position, new vec3(view * new vec4(light.Position, 1.0f)));
            //program.SetUniform(light_position, light.Position);
            program.SetUniform(material_ambient, this.Ambient);
            program.SetUniform(material_diffuse, this.Diffuse);
            program.SetUniform(material_specular, this.Specular);
            program.SetUniform(material_specular_power, this.SpecularPower);

            method.Render();
        }

        public override void RenderAfterChildren(RenderEventArgs arg)
        {
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
            mat4 projection = light.GetProjectionMatrix();
            mat4 view = light.GetViewMatrix();
            mat4 model = this.GetModelMatrix();

            var method = this.RenderUnit.Methods[0];
            ShaderProgram program = method.Program;
            program.SetUniform(mvpMatrix, projection * view * model);

            method.Render();
        }

        #endregion
    }
}
