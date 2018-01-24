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
            RenderMethodBuilder depthBufferBuilder, extrudeBuilder, underLightBuilder, ambientColorBufer;
            {
                var vs = new VertexShader(depthBufferVert);
                var array = new ShaderArray(vs);
                var map = new AttributeMap();
                map.Add("Position", AdjacentTeapot.strPosition);
                depthBufferBuilder = new RenderMethodBuilder(array, map);
            }
            {
                var vs = new VertexShader(extrudeVert);
                var gs = new GeometryShader(extrudeGeom);
                var fs = new FragmentShader(extrudeFrag);
                var array = new ShaderArray(vs, gs, fs);
                var map = new AttributeMap();
                map.Add("Position", AdjacentTeapot.strPosition);
                extrudeBuilder = new RenderMethodBuilder(array, map);
            }
            {
                var vs = new VertexShader(underLightVert);
                var fs = new FragmentShader(underLightFrag);
                var array = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add("inPosition", AdjacentTeapot.strPosition);
                map.Add("inColor", AdjacentTeapot.strPosition);
                underLightBuilder = new RenderMethodBuilder(array, map);
            }
            {
                var vs = new VertexShader(ambientVert);
                var fs = new FragmentShader(ambientFrag);
                var array = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add("inPosition", AdjacentTeapot.strPosition);
                map.Add("inColor", AdjacentTeapot.strNormal);
                ambientColorBufer = new RenderMethodBuilder(array, map);
            }

            var node = new ShadowVolumeNode(model, depthBufferBuilder, extrudeBuilder, underLightBuilder, ambientColorBufer);
            node.Initialize();
            node.ModelSize = model.GetModelSize();

            return node;
        }

        private ShadowVolumeNode(IBufferSource model, params RenderMethodBuilder[] builders)
            : base(model, builders)
        { }


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
