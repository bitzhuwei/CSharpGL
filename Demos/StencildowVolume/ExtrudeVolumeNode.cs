using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StencilShadowVolume
{
    partial class ExtrudeVolumeNode : ModernNode, IRenderable
    {

        public static ExtrudeVolumeNode Create(IBufferSource model, string position, string color, vec3 size)
        {
            RenderMethodBuilder extrudVolumeBuilder, regularBuilder;
            {
                var vs = new VertexShader(extrudeVert);
                var gs = new GeometryShader(extrudeGeom);
                var fs = new FragmentShader(extrudeFrag);
                var array = new ShaderArray(vs, gs, fs);
                var map = new AttributeMap();
                map.Add("Position", position);
                extrudVolumeBuilder = new RenderMethodBuilder(array, map);//, new PolygonModeState(PolygonMode.Line));
            }
            {
                var vs = new VertexShader(vertexCode);
                var fs = new FragmentShader(fragmentCode);
                var array = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add("inPosition", position);
                map.Add("inColor", color);
                regularBuilder = new RenderMethodBuilder(array, map);
            }

            var node = new ExtrudeVolumeNode(model, extrudVolumeBuilder, regularBuilder);
            node.Initialize();
            node.ModelSize = size;

            return node;
        }

        private ExtrudeVolumeNode(IBufferSource model, params RenderMethodBuilder[] builders)
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

        private PolygonOffsetState fillOffsetState = new PolygonOffsetFillState(pullNear: false);

        private ThreeFlags enableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children | ThreeFlags.AfterChildren;
        private PointLight light;
        /// <summary>
        /// Render before/after children? Render children? 
        /// RenderAction cares about this property. Other actions, maybe, maybe not, your choice.
        /// </summary>
        public ThreeFlags EnableRendering
        {
            get { return this.enableRendering; }
            set { this.enableRendering = value; }
        }

        public void RenderBeforeChildren(RenderEventArgs arg)
        {
            if (!this.IsInitialized) { this.Initialize(); }

            //this.RotationAngle += 1f;

            ICamera camera = arg.Camera;
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();

            if (this.RenderSilhouette)
            {
                var method = this.RenderUnit.Methods[0];
                ShaderProgram program = method.Program;
                program.SetUniform("gProjectionView", projection * view);
                program.SetUniform("gWorld", model);
                program.SetUniform("gLightPos", this.light.Position);

                fillOffsetState.On();
                method.Render(ControlMode.ByFrame);
                fillOffsetState.Off();
            }

            if (this.RenderBody)
            {
                var method = this.RenderUnit.Methods[1];
                ShaderProgram program = method.Program;
                program.SetUniform("mvpMat", projection * view * model);

                method.Render(ControlMode.Random);
            }
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }

        internal void SetLight(PointLight light)
        {
            this.light = light;
        }
    }
}
