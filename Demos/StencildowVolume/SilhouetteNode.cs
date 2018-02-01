using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StencilShadowVolume
{
    partial class SilhouetteNode : ModernNode, IRenderable
    {

        public static SilhouetteNode Create(IBufferSource model, string position, string color, vec3 size)
        {
            RenderMethodBuilder silhouetteBuilder, regularBuilder;
            {
                var vs = new VertexShader(silhouetteVert);
                var gs = new GeometryShader(silhouetteGeom);
                var fs = new FragmentShader(silhouetteFrag);
                var array = new ShaderArray(vs, gs, fs);
                var map = new AttributeMap();
                map.Add("Position", position);
                silhouetteBuilder = new RenderMethodBuilder(array, map);
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

            var node = new SilhouetteNode(model, silhouetteBuilder, regularBuilder);
            node.Initialize();
            node.ModelSize = size;

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
                var method = this.RenderUnit.Methods[0]; // the only render unit in this node.
                ShaderProgram program = method.Program;
                program.SetUniform("gWVP", projection * view * model);
                program.SetUniform("gWorld", model);
                program.SetUniform("gLightPos", this.light.Position);

                method.Render(ControlMode.ByFrame);
            }

            if (this.RenderBody)
            {
                var method = this.RenderUnit.Methods[1]; // the only render unit in this node.
                ShaderProgram program = method.Program;
                program.SetUniform("mvpMat", projection * view * model);

                fillOffsetState.On();
                method.Render(ControlMode.Random);
                fillOffsetState.Off();
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
