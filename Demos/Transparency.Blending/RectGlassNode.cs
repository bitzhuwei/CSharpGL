using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace Transparency.Blending
{
    partial class RectGlassNode : ModernNode, IRenderable
    {
        public static RectGlassNode Create(float width, float height)
        {
            var model = new RectGlassModel(width, height);
            var vs = new VertexShader(vert);
            var fs = new FragmentShader(frag);
            var array = new ShaderArray(vs, fs);
            var map = new AttributeMap();
            map.Add("inPosition", RectGlassModel.strPosition);
            var blend = new BlendSwitch(BlendingSourceFactor.SourceAlpha, BlendingDestinationFactor.OneMinusSourceAlpha);
            var depthMask = new DepthMaskSwitch(false);
            var builder = new RenderMethodBuilder(array, map, blend, depthMask);
            var node = new RectGlassNode(model, builder);
            node.Blend = blend;
            node.ModelSize = new vec3(width, height, 0);
            node.Initialize();

            return node;
        }

        private RectGlassNode(IBufferSource model, params RenderMethodBuilder[] builders)
            : base(model, builders)
        {
            this.Color = new vec4(1, 0, 0, 0.2f);
        }

        public BlendSwitch Blend { get; private set; }

        public vec4 Color { get; set; }

        #region IRenderable 成员

        private ThreeFlags enableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children;

        public ThreeFlags EnableRendering
        {
            get { return enableRendering; }
            set { enableRendering = value; }
        }

        public void RenderBeforeChildren(RenderEventArgs arg)
        {
            var camera = arg.Camera;
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();

            RenderMethod method = this.RenderUnit.Methods[0];
            ShaderProgram program = method.Program;
            program.SetUniform("mvpMat", projection * view * model);
            program.SetUniform("color", this.Color);
            //var clearColor = new int[4];
            //GL.Instance.GetIntegerv((uint)GetTarget.ColorClearValue, clearColor);
            var clearColor = new float[4];
            GL.Instance.GetFloatv((uint)GetTarget.ColorClearValue, clearColor);
            var background = new vec4(clearColor[0], clearColor[1], clearColor[2], clearColor[3]);
            program.SetUniform("backgroundColor", background);

            // TODO: rename ControlMode to AccessMode.
            method.Render(IndexAccessMode.Random);
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }

        #endregion
    }
}
