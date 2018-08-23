using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace Lighting.ShadowVolume
{
    partial class ShadowVolumeNode : ModernNode, IBlinnPhong
    {

        public static ShadowVolumeNode Create(IBufferSource model, string position, string normal, vec3 size)
        {
            RenderMethodBuilder ambientBuilder, extrudeBuilder, underLightBuilder;
            {
                var vs = new VertexShader(ambientVert);
                var fs = new FragmentShader(ambientFrag);
                var array = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add("inPosition", position);
                ambientBuilder = new RenderMethodBuilder(array, map);
            }
            {
                var vs = new VertexShader(extrudeVert);
                var gs = new GeometryShader(extrudeGeom);
                var fs = new FragmentShader(extrudeFrag);
                var array = new ShaderArray(vs, gs, fs);
                var map = new AttributeMap();
                map.Add("inPosition", position);
                extrudeBuilder = new RenderMethodBuilder(array, map);
            }
            {
                var vs = new VertexShader(blinnPhongVert);
                var fs = new FragmentShader(blinnPhongFrag);
                var array = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add("inPosition", position);
                map.Add("inNormal", normal);
                underLightBuilder = new RenderMethodBuilder(array, map);
            }

            var node = new ShadowVolumeNode(model, ambientBuilder, extrudeBuilder, underLightBuilder);
            node.Initialize();
            node.ModelSize = size;

            return node;
        }

        private ShadowVolumeNode(IBufferSource model, params RenderMethodBuilder[] builders)
            : base(model, builders)
        {
            this.Color = new vec3(1, 1, 1);
            this.Shiness = 32;
            this.BlinnPhong = true;
        }

        private PolygonOffsetSwitch fillFarOffsetState = new PolygonOffsetFillSwitch(pullNear: false);
        private PolygonOffsetSwitch fillNearOffsetState = new PolygonOffsetFillSwitch(pullNear: true);
        public void ExtrudeShadow(RenderEventArgs arg, LightBase light)
        {
            ICamera camera = arg.Camera;
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();

            var method = this.RenderUnit.Methods[(int)MethodName.extrudeShadow];
            ShaderProgram program = method.Program;
            program.SetUniform("vpMat", projection * view);
            program.SetUniform("gWorld", model);
            if (light is DirectionalLight)
            {
                var d = light as DirectionalLight;
                program.SetUniform("lightPosition", d.Direction);
                program.SetUniform("farAway", true);
            }
            else
            {
                program.SetUniform("lightPosition", light.Position);
                program.SetUniform("farAway", false);
            }

            fillFarOffsetState.On();
            this.lineWidthSwitch.On();
            method.Render();
            this.lineWidthSwitch.Off();
            fillFarOffsetState.Off();
        }

        public vec3 Color { get; set; }

        public float Shiness { get; set; }

        public bool BlinnPhong { get; set; }

        enum MethodName
        {
            renderAmbientColor,
            extrudeShadow,
            renderUnderLight,
        }


        #region IBlinnPhong 成员

        private ThreeFlags enableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children;
        public ThreeFlags EnableRendering { get { return this.enableRendering; } set { this.enableRendering = value; } }

        public void RenderAmbientColor(BlinnPhongAmbientEventArgs arg)
        {
            if (!this.renderBody) { return; }

            ICamera camera = arg.Camera;
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();

            var method = this.RenderUnit.Methods[(int)MethodName.renderAmbientColor];
            ShaderProgram program = method.Program;
            program.SetUniform("mvpMat", projection * view * model);
            program.SetUniform("ambientColor", arg.Ambient);

            method.Render();
        }

        private bool renderBody = true;

        public bool RenderBody
        {
            get { return renderBody; }
            set { renderBody = value; }
        }

        private bool renderOutline = true;

        public bool RenderOutline
        {
            get { return renderOutline; }
            set { renderOutline = value; }
        }

        private LineWidthSwitch lineWidthSwitch = new LineWidthSwitch(1);
        public float LineWidth
        {
            get { return this.lineWidthSwitch.LineWidth; }
            set { this.lineWidthSwitch.LineWidth = value; }
        }
        public void RenderBeforeChildren(RenderEventArgs arg, LightBase light)
        {
            if (this.renderOutline)
            {
                ExtrudeShadow(arg, light);
            }

            if (this.renderBody)
            {
                RenderSelf(arg, light);
            }
        }

        private void RenderSelf(RenderEventArgs arg, LightBase light)
        {

            ICamera camera = arg.Camera;
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();

            var method = this.RenderUnit.Methods[(int)MethodName.renderUnderLight];
            ShaderProgram program = method.Program;
            // matrix.
            program.SetUniform("mvpMat", projection * view * model);
            //program.SetUniform("projectionMat", projection);
            //program.SetUniform("viewMat", view);
            program.SetUniform("modelMat", model);
            program.SetUniform("normalMat", glm.transpose(glm.inverse(model)));
            // light info.
            light.SetBlinnPhongUniforms(program);
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

        public void RenderAfterChildren(RenderEventArgs arg, LightBase light)
        {
        }

        #endregion
    }

}
