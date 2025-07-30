using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c01d00_Cube {
    /// <summary>
    /// Renders a cube every time the action list works.
    /// </summary>
    partial class CubeNode : ModernNode, IRenderable {
        private ShaderStorageBuffer positionBuffer;
        private ShaderStorageBuffer colorBuffer;

        public static CubeNode Create(ShaderStorageBuffer positionBuffer, ShaderStorageBuffer colorBuffer,
            string vertexCode, string fragmentCode) {
            // model provides vertex buffer and index buffer(within an IDrawCommand).
            var model = new CubeModel();
            // vertex shader and fragment shader.
            // which vertex buffer maps to which attribute in shader.
            var program = GLProgram.Create(vertexCode, fragmentCode); System.Diagnostics.Debug.Assert(program != null);
            var map = new AttributeMap();
            //map.Add("inPosition", CubeModel.strPosition);
            //map.Add("inColor", CubeModel.strColor);
            // help to build a render method.
            var builder = new RenderMethodBuilder(program, map);
            // create node.
            var node = new CubeNode(model, builder);
            node.positionBuffer = positionBuffer;
            node.colorBuffer = colorBuffer;
            // initialize node.
            node.Initialize();

            return node;
        }

        protected override void DoInitialize() {
            base.DoInitialize();
            {
                //var shaderStorageBuffer = CubeModel.positions.GenShaderStorageBuffer(GLBuffer.Usage.StaticRead);
                //shaderStorageBuffer.Binding(this.RenderUnit.Methods[0].Program, "SSBO", 0);
                this.positionBuffer.Binding(this.RenderUnit.Methods[0].Program, "SSBO", 0);
            }
            {
                //var shaderStorageBuffer = CubeModel.colors.GenShaderStorageBuffer(GLBuffer.Usage.StaticDraw);
                //shaderStorageBuffer.Binding(this.RenderUnit.Methods[0].Program, "SSBO2", 1);
                this.colorBuffer.Binding(this.RenderUnit.Methods[0].Program, "SSBO2", 1);
            }
            this.RenderUnit.Methods[0].SwitchList.Add(new PointSizeSwitch(16));
        }

        private CubeNode(IBufferSource model, params RenderMethodBuilder[] builders)
            : base(model, builders) {
        }

        #region IRenderable 成员

        // render this before render children. Call RenderBeforeChildren();
        // render children.
        // not Call RenderAfterChildren();
        private ThreeFlags enableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children;

        public ThreeFlags EnableRendering {
            get { return enableRendering; }
            set { enableRendering = value; }
        }

        public void RenderBeforeChildren(RenderEventArgs arg) {
            // gets mvpMatrix.
            ICamera camera = arg.Camera;
            mat4 projectionMat = camera.GetProjectionMatrix();
            mat4 viewMat = camera.GetViewMatrix();
            mat4 modelMat = this.GetModelMatrix();
            mat4 mvpMatrix = projectionMat * viewMat * modelMat;
            // a render uint wraps everything(model data, shaders, glswitches, etc.) for rendering.
            ModernRenderUnit unit = this.RenderUnit;
            // gets render method.
            // There could be more than 1 method(vertex shader + fragment shader) to render the same model data. Thus we need an method array.
            RenderMethod method = unit.Methods[0];
            // shader program wraps vertex shader and fragment shader.
            GLProgram program = method.Program;
            //set value for 'uniform mat4 mvpMatrix'; in shader.
            program.SetUniform("mvpMatrix", mvpMatrix);
            // render the cube model via OpenGL.
            method.Render();
        }

        public void RenderAfterChildren(RenderEventArgs arg) {
        }

        #endregion
    }
}
