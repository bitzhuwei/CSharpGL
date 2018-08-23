using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace Lighting.ShadowMapping
{
    partial class ShadowMappingNode : ModernNode, ISupportShadowMapping
    {
        public static ShadowMappingNode Create(IBufferSource model, string position, string normal, vec3 size)
        {
            RenderMethodBuilder ambientBuilder, shadowBuilder, blinnPhongBuilder;
            {
                var vs = new VertexShader(ambientVert);
                var fs = new FragmentShader(ambientFrag);
                var array = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add("inPosition", position);
                ambientBuilder = new RenderMethodBuilder(array, map);
            }
            {
                var vs = new VertexShader(shadowVert);
                var array = new ShaderArray(vs);
                var map = new AttributeMap();
                map.Add("inPosition", position);
                shadowBuilder = new RenderMethodBuilder(array, map);
            }
            {
                var vs = new VertexShader(blinnPhongVert);
                var fs = new FragmentShader(blinnPhongFrag);
                var array = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add("inPosition", position);
                map.Add("inNormal", normal);
                blinnPhongBuilder = new RenderMethodBuilder(array, map);
            }

            var node = new ShadowMappingNode(model, ambientBuilder, shadowBuilder, blinnPhongBuilder);
            node.Initialize();
            node.ModelSize = size;

            return node;
        }

        private ShadowMappingNode(IBufferSource model, params RenderMethodBuilder[] builders)
            : base(model, builders)
        {
            this.Color = new vec3(1, 1, 1);
            this.Shiness = 32;
            this.BlinnPhong = true;
        }

        public vec3 Color { get; set; }

        public float Shiness { get; set; }

        public bool BlinnPhong { get; set; }

        #region ISupportShadowMapping 成员

        private TwoFlags enableShadowMapping = TwoFlags.BeforeChildren | TwoFlags.Children;
        public TwoFlags EnableShadowMapping { get { return this.enableShadowMapping; } set { this.enableShadowMapping = value; } }

        public void RenderAmbientColor(ShadowMappingAmbientEventArgs arg)
        {
            ICamera camera = arg.Camera;
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();

            RenderMethod method = this.RenderUnit.Methods[0];
            ShaderProgram program = method.Program;
            program.SetUniform("mvpMat", projection * view * model);
            program.SetUniform("ambientColor", arg.Ambient);

            method.Render();
        }

        private TwoFlags enableCastShadow = TwoFlags.BeforeChildren | TwoFlags.Children;
        public TwoFlags EnableCastShadow { get { return this.enableCastShadow; } set { this.enableCastShadow = value; } }

        public void CastShadow(ShadowMappingCastShadowEventArgs arg)
        {
            LightBase light = arg.Light;
            mat4 projection = light.GetProjectionMatrix();
            mat4 view = light.GetViewMatrix();
            mat4 model = this.GetModelMatrix();

            var method = this.RenderUnit.Methods[1];
            ShaderProgram program = method.Program;
            program.SetUniform("mvpMatrix", projection * view * model);

            method.Render();
        }

        private TwoFlags enableRenderUnderLight = TwoFlags.BeforeChildren | TwoFlags.Children;
        public TwoFlags EnableRenderUnderLight { get { return this.enableRenderUnderLight; } set { this.enableRenderUnderLight = value; } }

        private static readonly mat4 lightBias = glm.scale(glm.translate(mat4.identity(), new vec3(1, 1, 1) * 0.5f), new vec3(1, 1, 1) * 0.5f);
        public void RenderUnderLight(ShadowMappingUnderLightEventArgs arg)
        {
            ICamera camera = arg.Camera;
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();
            LightBase light = arg.Light;
            mat4 lightProjection = light.GetProjectionMatrix();
            mat4 lightView = light.GetViewMatrix();

            RenderMethod method = this.RenderUnit.Methods[2];
            ShaderProgram program = method.Program;
            // matrix.
            program.SetUniform("mvpMat", projection * view * model);
            //program.SetUniform("projectionMat", projection);
            //program.SetUniform("viewMat", view);
            program.SetUniform("modelMat", model);
            program.SetUniform("normalMat", glm.transpose(glm.inverse(model)));
            program.SetUniform("shadowMat", lightBias * lightProjection * lightView);
            // light info.
            light.SetBlinnPhongUniforms(program);
            // material.
            program.SetUniform("material.diffuse", this.Color);
            program.SetUniform("material.specular", this.Color);
            program.SetUniform("material.shiness", this.Shiness);
            program.SetUniform("depth_texture", arg.ShadowMap);
            // eye pos.
            program.SetUniform("eyePos", camera.Position); // camera's position in world space.
            // use blinn phong or not?
            program.SetUniform("blinn", this.BlinnPhong);
            program.SetUniform("useShadow", this.UseShadow);

            method.Render();
        }

        #endregion

        private bool useShadow = true;

        public bool UseShadow
        {
            get { return useShadow; }
            set { useShadow = value; }
        }
    }
}
