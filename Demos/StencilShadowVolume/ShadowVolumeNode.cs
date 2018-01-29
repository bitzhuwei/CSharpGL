using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StencilShadowVolume
{
    partial class ShadowVolumeNode : ModernNode, ISupportShadowVolume
    {

        public static ShadowVolumeNode Create(IBufferSource model, string position, string normal, vec3 size)
        {
            RenderMethodBuilder depthBufferBuilder, extrudeBuilder, underLightBuilder, ambientColorBufer;
            {
                var vs = new VertexShader(depthBufferVert);
                var fs = new FragmentShader(depthBufferFrag);
                var array = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add("inPosition", position);
                depthBufferBuilder = new RenderMethodBuilder(array, map);
            }
            {
                var vs = new VertexShader(extrudeVert);
                var gs = new GeometryShader(extrudeGeom);
                var fs = new FragmentShader(extrudeFrag);
                var array = new ShaderArray(vs, gs, fs);
                var map = new AttributeMap();
                map.Add("Position", position);
                extrudeBuilder = new RenderMethodBuilder(array, map);
            }
            {
                var vs = new VertexShader(underLightVert);
                var fs = new FragmentShader(underLightFrag);
                var array = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add("vPosition", position);
                map.Add("vNormal", normal);
                underLightBuilder = new RenderMethodBuilder(array, map);
            }
            {
                var vs = new VertexShader(ambientVert);
                var fs = new FragmentShader(ambientFrag);
                var array = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add("inPosition", position);
                ambientColorBufer = new RenderMethodBuilder(array, map);
            }

            var node = new ShadowVolumeNode(model, depthBufferBuilder, extrudeBuilder, underLightBuilder, ambientColorBufer);
            node.Initialize();
            node.ModelSize = size;

            return node;
        }

        private ShadowVolumeNode(IBufferSource model, params RenderMethodBuilder[] builders)
            : base(model, builders)
        { }


        #region ISupportShadowVolume 成员

        private TwoFlags enableShadowVolume = TwoFlags.BeforeChildren | TwoFlags.Children;
        public TwoFlags EnableShadowVolume { get { return this.enableShadowVolume; } set { this.enableShadowVolume = value; } }

        private TwoFlags enableExtrude = TwoFlags.BeforeChildren | TwoFlags.Children;
        public TwoFlags EnableExtrude { get { return this.enableExtrude; } set { this.enableExtrude = value; } }

        private PolygonOffsetState fillFarOffsetState = new PolygonOffsetFillState(pullNear: false);
        private PolygonOffsetState fillNearOffsetState = new PolygonOffsetFillState(pullNear: true);
        public void ExtrudeShadow(ShadowVolumeExtrudeEventArgs arg)
        {
            ICamera camera = arg.Camera;
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();

            var method = this.RenderUnit.Methods[(int)MethodName.extrudeShadow];
            ShaderProgram program = method.Program;
            program.SetUniform("gProjectionView", projection * view);
            program.SetUniform("gWorld", model);
            program.SetUniform("gLightPos", arg.Light.Position);// TODO: This is how point light works. I need to deal with directional light, etc.

            fillFarOffsetState.On();
            method.Render();
            fillFarOffsetState.Off();
        }

        private TwoFlags enableRenderUnderLight = TwoFlags.BeforeChildren | TwoFlags.Children;
        public TwoFlags EnableRenderUnderLight { get { return this.enableRenderUnderLight; } set { this.enableRenderUnderLight = value; } }

        public void RenderUnderLight(RenderEventArgs arg, LightBase light)
        {
            ICamera camera = arg.Camera;
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();
            mat4 normal = glm.transpose(glm.inverse(view * model));

            var method = this.RenderUnit.Methods[(int)MethodName.renderUnderLight];
            ShaderProgram program = method.Program;
            program.SetUniform("projectionMatrix", projection);
            program.SetUniform("viewMatrix", view);
            program.SetUniform("modelMatrix", model);
            program.SetUniform("normalMatrix", normal);
            program.SetUniform("lightPosition", new vec3(view * new vec4(light.Position, 1.0f)));
            program.SetUniform("lightColor", light.Color);

            //fillNearOffsetState.On();
            method.Render();
            //fillNearOffsetState.Off();
        }

        private vec3 diffuseColor = new vec3(1, 0.8431f, 0);
        public vec3 DiffuseColor
        {
            get
            {
                return diffuseColor;
            }
            set
            {
                this.diffuseColor = value;
                if (this.RenderUnit != null)
                {
                    RenderMethod method = this.RenderUnit.Methods[(int)MethodName.renderUnderLight];
                    ShaderProgram program = method.Program;
                    program.SetUniform("diffuseColor", value);
                }
            }
        }
        public void RenderAmbientColor(ShadowVolumeAmbientEventArgs arg)
        {
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

        #endregion

        enum MethodName
        {
            renderToDepthBuffer = 0,
            extrudeShadow = 1,
            renderUnderLight = 2,
            renderAmbientColor = 3,
        }

    }
}
