using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StencilShadowVolume
{
    partial class ShadowVolumeNode : ModernNode, ISupportShadowVolume
    {

        public static ShadowVolumeNode Create(IBufferSource model, string position, string color, vec3 size)
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
                map.Add("inPosition", position);
                map.Add("inColor", color);
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

        public TwoFlags EnableShadowVolume { get { return TwoFlags.BeforeChildren | TwoFlags.Children; } set { } }

        public void RenderToDepthBuffer(RenderEventArgs arg)
        {
            ICamera camera = arg.CameraStack.Peek();
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();

            var method = this.RenderUnit.Methods[(int)MethodName.renderToDepthBuffer]; // the only render unit in this node.
            ShaderProgram program = method.Program;
            program.SetUniform("mvpMat", projection * view * model);

            method.Render();
        }

        public void ExtrudeShadow(ShadowVolumeEventArgs arg)
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

            method.Render();
        }

        public void RenderUnderLight(RenderEventArgs arg, LightBase light)
        {
            ICamera camera = arg.CameraStack.Peek();
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();

            var method = this.RenderUnit.Methods[(int)MethodName.renderUnderLight];
            ShaderProgram program = method.Program;
            program.SetUniform("mvpMat", projection * view * model);

            method.Render();
        }

        public void RenderAmbientColor(RenderEventArgs arg)
        {
            ICamera camera = arg.CameraStack.Peek();
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();

            var method = this.RenderUnit.Methods[(int)MethodName.renderAmbientColor];
            ShaderProgram program = method.Program;
            program.SetUniform("mvpMat", projection * view * model);
            program.SetUniform("ambientColor", arg.Scene.AmbientColor);

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
