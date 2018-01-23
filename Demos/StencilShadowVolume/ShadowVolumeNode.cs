using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StencilShadowVolume
{
    partial class ShadowVolumeNode : ModernNode, ISupportShadowVolume
    {

        public static ShadowVolumeNode Create()
        {
            var model = new AdjacentTeapot();
            RenderMethodBuilder extrudVolumeBuilder, regularBuilder;
            {
                var vs = new VertexShader(extrudeVert);
                var gs = new GeometryShader(extrudeGeom);
                var fs = new FragmentShader(extrudeFrag);
                var array = new ShaderArray(vs, gs, fs);
                var map = new AttributeMap();
                map.Add("Position", AdjacentTeapot.strPosition);
                extrudVolumeBuilder = new RenderMethodBuilder(array, map, new PolygonModeState(PolygonMode.Line));
            }
            {
                var vs = new VertexShader(underLightVert);
                var fs = new FragmentShader(underLightFrag);
                var array = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add("inPosition", AdjacentTeapot.strPosition);
                map.Add("inColor", AdjacentTeapot.strNormal);
                regularBuilder = new RenderMethodBuilder(array, map);
            }

            var node = new ShadowVolumeNode(model, extrudVolumeBuilder, regularBuilder);
            node.Initialize();
            node.ModelSize = model.GetModelSize();

            return node;
        }

        private ShadowVolumeNode(IBufferSource model, params RenderMethodBuilder[] builders)
            : base(model, builders)
        { }

        //private bool renderBody = true;

        //public bool RenderBody
        //{
        //    get { return renderBody; }
        //    set { renderBody = value; }
        //}

        //private bool renderSilhouette = true;

        //public bool RenderSilhouette
        //{
        //    get { return renderSilhouette; }
        //    set { renderSilhouette = value; }
        //}

        private PolygonOffsetState fillOffsetState = new PolygonOffsetFillState(pullNear: false);
        public override void RenderBeforeChildren(RenderEventArgs arg)
        {
            if (!this.IsInitialized) { this.Initialize(); }

            //this.RotationAngle += 1f;

            //ICamera camera = arg.CameraStack.Peek();
            //mat4 projection = camera.GetProjectionMatrix();
            //mat4 view = camera.GetViewMatrix();
            //mat4 model = this.GetModelMatrix();

            //if (this.RenderSilhouette)
            //{
            //    var method = this.RenderUnit.Methods[0]; // the only render unit in this node.
            //    ShaderProgram program = method.Program;
            //    program.SetUniform("gWVP", projection * view * model);
            //    program.SetUniform("gWorld", model);
            //    program.SetUniform("gLightPos", this.lightPosition);

            //    method.Render(ControlMode.ByFrame);
            //}

            //if (this.RenderBody)
            //{
            //    var method = this.RenderUnit.Methods[1]; // the only render unit in this node.
            //    ShaderProgram program = method.Program;
            //    program.SetUniform("mvpMat", projection * view * model);

            //    fillOffsetState.On();
            //    method.Render(ControlMode.Random);
            //    fillOffsetState.Off();
            //}
        }

        public override void RenderAfterChildren(RenderEventArgs arg)
        {
        }

        #region ISupportShadowVolume 成员

        public TwoFlags EnableShadowVolume { get { return TwoFlags.BeforeChildren | TwoFlags.Children; } set { } }

        public void RenderToDepthBuffer(RenderEventArgs arg)
        {
            throw new NotImplementedException();
        }

        public void ExtrudeShadow(ShadowVolumeEventArgs arg)
        {
            throw new NotImplementedException();
        }

        public void RenderUnderLight(RenderEventArgs arg, LightBase light)
        {
            throw new NotImplementedException();
        }

        public void RenderAmbientColor(RenderEventArgs arg)
        {
            throw new NotImplementedException();
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
