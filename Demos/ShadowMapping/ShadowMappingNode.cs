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
    public partial class ShadowMappingNode : PickableNode, ISupportShadowMapping
    {
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
            RenderMethodBuilder ambientBuilder, shadowBuilder, lightBuilder;
            {
                var vs = new VertexShader(ambientVert);
                var fs = new FragmentShader(ambientFrag);
                var array = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add("inPosition", position);
                ambientBuilder = new RenderMethodBuilder(array, map);
            }
            {
                var vs = new VertexShader(shadowVertexCode);
                var provider = new ShaderArray(vs);
                var map = new AttributeMap();
                map.Add("inPosition", position);
                shadowBuilder = new RenderMethodBuilder(provider, map);
            }
            {
                var vs = new VertexShader(blinnPhongVert);
                var fs = new FragmentShader(blinnPhongFrag);
                var provider = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add("inPosition", position);
                map.Add("inNormal", normal);
                lightBuilder = new RenderMethodBuilder(provider, map);
            }
            var node = new ShadowMappingNode(model, position, ambientBuilder, shadowBuilder, lightBuilder);
            node.ModelSize = size;
            node.Initialize();

            return node;
        }

        private ShadowMappingNode(IBufferSource model, string positionNameInIBufferSource, params RenderMethodBuilder[] builder)
            : base(model, positionNameInIBufferSource, builder)
        {
            //this.Ambient = new vec3(1, 1, 1) * 0.2f;
            //this.Diffuse = System.Drawing.Color.SkyBlue.ToVec3();
            //this.Specular = new vec3(1, 1, 1) * 0.1f;
            //this.SpecularPower = 0.2f;
        }


        #region IShadowMapping 成员

        private TwoFlags enableShadowMapping = TwoFlags.BeforeChildren | TwoFlags.Children;
        public TwoFlags EnableShadowMapping
        {
            get { return enableShadowMapping; }
            set { enableShadowMapping = value; }
        }

        public void RenderAmbientColor(ShadowMappingAmbientEventArgs arg)
        {
            ICamera camera = arg.Camera;
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();

            var method = this.RenderUnit.Methods[(int)MethodName.ambient];
            ShaderProgram program = method.Program;
            program.SetUniform("mvpMat", projection * view * model);
            program.SetUniform("ambientColor", arg.Ambient);

            method.Render();
        }

        private TwoFlags enableCastShadow = TwoFlags.BeforeChildren | TwoFlags.Children;
        public TwoFlags EnableCastShadow
        {
            get { return enableCastShadow; }
            set { enableCastShadow = value; }
        }

        public void CastShadow(ShadowMappingCastShadowEventArgs arg)
        {
            if (!this.IsInitialized) { this.Initialize(); }

            //this.RotationAngle += this.RotateSpeed;

            LightBase light = arg.Light;
            mat4 projection = light.GetProjectionMatrix();
            mat4 view = light.GetViewMatrix();
            mat4 model = this.GetModelMatrix();

            var method = this.RenderUnit.Methods[(int)MethodName.castShadow];
            ShaderProgram program = method.Program;
            program.SetUniform("mvpMatrix", projection * view * model);

            method.Render();
        }

        private TwoFlags enableRenderUnderLight = TwoFlags.BeforeChildren | TwoFlags.Children;
        public TwoFlags EnableRenderUnderLight { get { return this.enableRenderUnderLight; } set { this.enableRenderUnderLight = value; } }

        public void RenderUnderLight(ShadowMappingUnderLightEventArgs arg)
        {
            if (!this.IsInitialized) { Initialize(); }

            //this.RotationAngle += this.RotateSpeed;

            ICamera camera = arg.Camera;
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();
            mat4 lightBias = glm.translate(mat4.identity(), new vec3(1, 1, 1) * 0.5f);
            lightBias = glm.scale(lightBias, new vec3(1, 1, 1) * 0.5f);
            LightBase light = arg.Light;
            mat4 lightProjection = light.GetProjectionMatrix();
            mat4 lightView = light.GetViewMatrix();

            var method = this.RenderUnit.Methods[(int)MethodName.renderUnderLight];
            ShaderProgram program = method.Program;
            // matrix.
            program.SetUniform("mvpMat", projection * view * model);
            //program.SetUniform("projectionMat", projection);
            //program.SetUniform("viewMat", view);
            program.SetUniform("modelMat", model);
            program.SetUniform("normalMat", glm.transpose(glm.inverse(model)));
            program.SetUniform("shadow_matrix", lightBias * lightProjection * lightView);
            // light info.
            light.SetUniforms(program);
            // material.
            program.SetUniform("material.diffuse", this.Color);
            program.SetUniform("material.specular", this.Color);
            program.SetUniform("material.shiness", this.Shiness);
            program.SetUniform("depth_texture", arg.ShadowMap);
            // eye pos.
            program.SetUniform("eyePos", camera.Position); // camera's position in world space.
            // use blinn phong or not?
            program.SetUniform("blinn", this.BlinnPhong);

            method.Render();
        }

        #endregion


        public float RotateSpeed { get; set; }

        public vec3 Color { get; set; }

        public float Shiness { get; set; }

        public bool BlinnPhong { get; set; }

        enum MethodName
        {
            ambient = 0,
            castShadow = 1,
            renderUnderLight = 2,
        }

    }
}
