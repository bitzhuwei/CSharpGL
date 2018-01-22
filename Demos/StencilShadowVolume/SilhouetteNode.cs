using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StencilShadowVolume
{
    partial class SilhouetteNode : ModernNode
    {

        public static SilhouetteNode Create()
        {
            var model = new AdjacentTeapot();
            RenderMethodBuilder silhouetteBuilder, regularBuilder;
            {
                var vs = new VertexShader(silhouetteVert);
                var gs = new GeometryShader(silhouetteGeom);
                var fs = new FragmentShader(silhouetteFrag);
                var array = new ShaderArray(vs, gs, fs);
                var map = new AttributeMap();
                map.Add("Position", AdjacentTeapot.strPosition);
                silhouetteBuilder = new RenderMethodBuilder(array, map);
            }
            {
                var vs = new VertexShader(vertexCode);
                var fs = new FragmentShader(fragmentCode);
                var array = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add("inPosition", AdjacentTeapot.strPosition);
                map.Add("inColor", AdjacentTeapot.strNormal);
                regularBuilder = new RenderMethodBuilder(array, map);
            }

            var node = new SilhouetteNode(model, silhouetteBuilder, regularBuilder);
            node.Initialize();
            node.ModelSize = model.GetModelSize();

            return node;
        }

        private SilhouetteNode(IBufferSource model, params RenderMethodBuilder[] builders)
            : base(model, builders)
        { }

        private bool renderBody = true;

        public bool RenderBody
        {
            get { return renderBody; }
            set { renderBody = value; }
        }

        private bool renderSilhouette = true;

        public bool RenderSilhouette
        {
            get { return renderSilhouette; }
            set { renderSilhouette = value; }
        }
        private vec3 lightPosition = new vec3(1, 1, 1) * 10;

        public vec3 LightPosition
        {
            get { return lightPosition; }
            set { lightPosition = value; }
        }

        private GLState polygonOffsetState = new PolygonOffsetFillState();
        public override void RenderBeforeChildren(RenderEventArgs arg)
        {
            if (!this.IsInitialized) { this.Initialize(); }

            ICamera camera = arg.CameraStack.Peek();
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();

            polygonOffsetState.On();
            if (this.RenderSilhouette)
            {
                var method = this.RenderUnit.Methods[0]; // the only render unit in this node.
                ShaderProgram program = method.Program;
                program.SetUniform("gWVP", projection * view * model);
                program.SetUniform("gWorld", model);
                program.SetUniform("gLightPos", this.lightPosition);

                method.Render(ControlMode.ByFrame);
            }

            if (this.RenderBody)
            {
                var method = this.RenderUnit.Methods[1]; // the only render unit in this node.
                ShaderProgram program = method.Program;
                program.SetUniform("mvpMat", projection * view * model);

                method.Render(ControlMode.Random);
            }
            polygonOffsetState.Off();
        }

        public override void RenderAfterChildren(RenderEventArgs arg)
        {
        }
    }
}
