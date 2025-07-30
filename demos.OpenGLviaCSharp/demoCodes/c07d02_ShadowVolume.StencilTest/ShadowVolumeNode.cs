using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c07d02_ShadowVolume.StencilTest {
    partial class ShadowVolumeNode : ModernNode, ISupportShadowVolume {

        public static ShadowVolumeNode Create(IBufferSource model, string position, string normal, vec3 size) {
            RenderMethodBuilder ambientBuilder, extrudeBuilder, underLightBuilder;
            {
                var program = GLProgram.Create(ambientVert, ambientFrag); Debug.Assert(program != null);
                var map = new AttributeMap();
                map.Add("inPosition", position);
                ambientBuilder = new RenderMethodBuilder(program, map);
            }
            {
                var program = GLProgram.Create(extrudeVert, extrudeGeom, extrudeFrag); Debug.Assert(program != null);
                var map = new AttributeMap();
                map.Add("inPosition", position);
                extrudeBuilder = new RenderMethodBuilder(program, map);
            }
            {
                var program = GLProgram.Create(blinnPhongVert, blinnPhongFrag); Debug.Assert(program != null);
                var map = new AttributeMap();
                map.Add("inPosition", position);
                map.Add("inNormal", normal);
                underLightBuilder = new RenderMethodBuilder(program, map);
            }

            var node = new ShadowVolumeNode(model, ambientBuilder, extrudeBuilder, underLightBuilder);
            node.Initialize();
            node.ModelSize = size;

            return node;
        }

        private ShadowVolumeNode(IBufferSource model, params RenderMethodBuilder[] builders)
            : base(model, builders) {
            this.Color = new vec3(1, 1, 1);
            this.Shiness = 32;
            this.BlinnPhong = true;
        }


        #region ISupportShadowVolume 成员

        private TwoFlags enableShadowVolume = TwoFlags.BeforeChildren | TwoFlags.Children;
        public TwoFlags EnableShadowVolume { get { return this.enableShadowVolume; } set { this.enableShadowVolume = value; } }

        public void RenderAmbientColor(ShadowVolumeAmbientEventArgs arg) {
            ICamera camera = arg.Camera;
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();

            var method = this.RenderUnit.Methods[(int)MethodName.renderAmbientColor];
            GLProgram program = method.Program;
            program.SetUniform("mvpMat", projection * view * model);
            program.SetUniform("ambientColor", arg.Ambient);

            method.Render();
        }

        private TwoFlags enableExtrude = TwoFlags.BeforeChildren | TwoFlags.Children;
        public TwoFlags EnableExtrude { get { return this.enableExtrude; } set { this.enableExtrude = value; } }

        private DirectionalLight directionalLight = new DirectionalLight(new vec3(1, 1, 1));

        public DirectionalLight DirectionalLight {
            get { return directionalLight; }
        }
        private PolygonOffsetSwitch fillFarOffsetSwitch = new PolygonOffsetFillSwitch(pullNear: false);
        private PolygonOffsetSwitch fillNearOffsetSwitch = new PolygonOffsetFillSwitch(pullNear: true);
        private PolygonModeSwitch polygonModeSwitch = new PolygonModeSwitch(PolygonMode.Line);
        private LineWidthSwitch lineWidthSwitch = new LineWidthSwitch(1);

        public void ExtrudeShadow(ShadowVolumeExtrudeEventArgs arg) {
            ICamera camera = arg.Camera;
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();

            var method = this.RenderUnit.Methods[(int)MethodName.extrudeShadow];
            GLProgram program = method.Program;
            program.SetUniform("vpMat", projection * view);
            program.SetUniform("modelMat", model);
            if (arg.Light is DirectionalLight) {
                var light = arg.Light as DirectionalLight;
                program.SetUniform("lightPosition", light.Direction);
                program.SetUniform("farAway", true);
            }
            else {
                program.SetUniform("lightPosition", arg.Light.Position);
                program.SetUniform("farAway", false);
            }

            // light info.
            directionalLight.SetBlinnPhongUniforms(program);
            // material.
            program.SetUniform("material.diffuse", new vec3(1, 0, 0));//this.Color);
            program.SetUniform("material.specular", new vec3(1, 0, 0));//this.Color);
            program.SetUniform("material.shiness", this.Shiness);

            fillFarOffsetSwitch.On();
            program.SetUniform("wireframe", false);
            method.Render();
            fillFarOffsetSwitch.Off();

            polygonModeSwitch.On();
            lineWidthSwitch.On();
            program.SetUniform("wireframe", true);
            method.Render();
            lineWidthSwitch.Off();
            polygonModeSwitch.Off();

        }

        private TwoFlags enableRenderUnderLight = TwoFlags.BeforeChildren | TwoFlags.Children;
        public TwoFlags EnableRenderUnderLight { get { return this.enableRenderUnderLight; } set { this.enableRenderUnderLight = value; } }

        public void RenderUnderLight(ShadowVolumeUnderLightEventArgs arg) {
            ICamera camera = arg.Camera;
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();

            var method = this.RenderUnit.Methods[(int)MethodName.renderUnderLight];
            GLProgram program = method.Program;
            // matrix.
            program.SetUniform("mvpMat", projection * view * model);
            //program.SetUniform("projectionMat", projection);
            //program.SetUniform("viewMat", view);
            program.SetUniform("modelMat", model);
            program.SetUniform("normalMat", glm.transpose(glm.inverse(model)));
            // light info.
            arg.Light.SetBlinnPhongUniforms(program);
            // material.
            program.SetUniform("material.diffuse", this.Color);
            program.SetUniform("material.specular", this.Color);
            program.SetUniform("material.shiness", this.Shiness);
            // eye pos.
            program.SetUniform("eyePos", camera.Position); // camera's position in world space.
            // use blinn phong or not?
            program.SetUniform("blinn", this.BlinnPhong);

            //fillNearOffsetState.On();
            method.Render();
            //fillNearOffsetState.Off();
        }

        #endregion

        public vec3 Color { get; set; }

        public float Shiness { get; set; }

        public bool BlinnPhong { get; set; }

        enum MethodName {
            renderAmbientColor,
            extrudeShadow,
            renderUnderLight,
        }

    }

}