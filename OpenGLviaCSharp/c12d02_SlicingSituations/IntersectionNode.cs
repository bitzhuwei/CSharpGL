using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c12d02_SlicingSituations
{
    partial class IntersectionNode : ModernNode, IRenderable
    {
        public static IntersectionNode Create()
        {
            // vertex buffer and index buffer.
            var model = new IntersectionModel();
            // vertex shader and fragment shader.
            var vs = new VertexShader(vertexCode);
            var fs = new FragmentShader(fragmentCode);
            var array = new ShaderArray(vs, fs);
            // which vertex buffer maps to which attribute in shader.
            var map = new AttributeMap();
            map.Add("inPosition", IntersectionModel.strPosition);
            // build a render method.
            var polygonModeSwitch = new PolygonModeSwitch(PolygonMode.Line);
            var lineWidthSwitch = new LineWidthSwitch(5);
            var offsetSwitch = new PolygonOffsetFillSwitch();
            var builder = new RenderMethodBuilder(array, map, offsetSwitch, polygonModeSwitch, lineWidthSwitch);
            // create node.
            var node = new IntersectionNode(model, builder);
            // initialize node.
            node.Initialize();

            return node;
        }

        private IntersectionNode(IBufferSource model, params RenderMethodBuilder[] builders)
            : base(model, builders)
        {
        }

        private VertexBuffer positionBuffer;
        private DrawArraysCmd drawCommand;

        protected override void DoInitialize()
        {
            base.DoInitialize();
            {
                this.positionBuffer = this.RenderUnit.Methods[0].VertexArrayObjects[0].VertexAttributes[0].Buffer;
                this.drawCommand = this.RenderUnit.Methods[0].VertexArrayObjects[0].DrawCommand as DrawArraysCmd;
            }
        }

        #region IRenderable 成员

        // render this before render children. Call RenderBeforeChildren();
        // render children.
        // not Call RenderAfterChildren();
        private ThreeFlags enableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children;
        public ThreeFlags EnableRendering
        {
            get { return enableRendering; }
            set { enableRendering = value; }
        }

        public void RenderBeforeChildren(RenderEventArgs arg)
        {
            // gets mvpMat.
            ICamera camera = arg.Camera;
            mat4 projectionMat = camera.GetProjectionMatrix();
            mat4 viewMat = camera.GetViewMatrix();
            mat4 modelMat = this.GetModelMatrix();
            mat4 mvpMat = projectionMat * viewMat * modelMat;
            // a render uint wraps everything(model data, shaders, glswitches, etc.) for rendering.
            ModernRenderUnit unit = this.RenderUnit;
            // gets render method.
            // There could be more than 1 method(vertex shader + fragment shader) to render the same model data. Thus we need an method array.
            RenderMethod method = unit.Methods[0];
            // shader program wraps vertex shader and fragment shader.
            ShaderProgram program = method.Program;
            //set value for 'uniform mat4 mvpMat'; in shader.
            program.SetUniform("mvpMat", mvpMat);
            // render the cube model via OpenGL.
            method.Render();
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }

        #endregion
    }
}
