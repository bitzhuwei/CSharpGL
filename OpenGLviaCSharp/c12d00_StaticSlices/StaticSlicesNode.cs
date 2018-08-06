using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c12d00_StaticSlices
{
    partial class StaticSlicesNode : ModernNode, IRenderable
    {
        private Texture texture1D;
        private Texture texture3D;

        /// <summary>
        /// Display 1 / HiddenLength of all slices.
        /// </summary>
        public int HiddenLength { get; set; }

        public bool ShowSlice { get; set; }

        public static StaticSlicesNode Create(int sliceCount, Texture texture1D, Texture texture3D)
        {
            var vs = new VertexShader(vertexCode);
            var fs = new FragmentShader(fragmentCode);
            var array = new ShaderArray(vs, fs);
            var map = new AttributeMap();
            map.Add("inPosition", StaticSlicesModel.strPosition);
            map.Add("inTexCoord", StaticSlicesModel.strTexCoord);
            //var depthTestSwitch = new DepthTestSwitch(false);
            //var polygonModeSwitch = new PolygonModeSwitch(PolygonMode.Line);
            var blendSwitch = new BlendSwitch(BlendEquationMode.Add, BlendSrcFactor.SrcAlpha, BlendDestFactor.OneMinusSrcAlpha);
            var builder = new RenderMethodBuilder(array, map, blendSwitch);

            var model = new StaticSlicesModel(sliceCount);
            var node = new StaticSlicesNode(model, builder);
            node.texture1D = texture1D;
            node.texture3D = texture3D;
            node.Initialize();

            return node;
        }

        private StaticSlicesNode(IBufferSource model, params RenderMethodBuilder[] builders)
            : base(model, builders)
        {
            this.HiddenLength = 1;// display all slices.
        }

        protected override void DoInitialize()
        {
            base.DoInitialize();

            {
                RenderMethod method = this.RenderUnit.Methods[0];
                ShaderProgram program = method.Program;
                // matrix.
                program.SetUniform("tex1D", this.texture1D);
                program.SetUniform("tex3D", this.texture3D);
            }
        }

        #region IRenderable 成员

        private ThreeFlags enableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children;
        public ThreeFlags EnableRendering { get { return this.enableRendering; } set { this.enableRendering = value; } }

        public void RenderBeforeChildren(RenderEventArgs arg)
        {
            ICamera camera = arg.Camera;
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();

            RenderMethod method = this.RenderUnit.Methods[0];
            ShaderProgram program = method.Program;
            // matrix.
            program.SetUniform("mvpMat", projection * view * model);
            program.SetUniform("hiddenLength", this.HiddenLength);
            program.SetUniform("showSlice", this.ShowSlice);
            method.Render();
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }

        #endregion

    }
}
