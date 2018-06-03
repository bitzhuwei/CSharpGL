using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c11d00_Arcball
{
    public partial class HalfSphereNode : ModernNode, IRenderable
    {

        public static HalfSphereNode Create(HalfSphere model)
        {
            var vs = new VertexShader(vertexCode);
            var fs = new FragmentShader(fragmentCode);
            var provider = new ShaderArray(vs, fs);
            var map = new AttributeMap();
            map.Add(inPosition, HalfSphere.strPosition);
            var builder = new RenderMethodBuilder(provider, map);
            var node = new HalfSphereNode(model, builder);
            node.Initialize();

            return node;
        }

        private HalfSphereNode(IBufferSource model, params RenderMethodBuilder[] builders)
            : base(model, builders)
        {
        }

        #region IRenderable 成员

        private PolygonModeSwitch polygonMode = new PolygonModeSwitch(PolygonMode.Line);
        private GLSwitch polygonOffsetState = new PolygonOffsetFillSwitch();


        private ThreeFlags enableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children | ThreeFlags.AfterChildren;
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

            ICamera camera = arg.Camera;
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();

            var method = this.RenderUnit.Methods[0]; // the only render unit in this node.
            ShaderProgram program = method.Program;
            program.SetUniform(mvpMatrix, projection * view * model);

            // render wireframe.
            polygonMode.On();
            polygonOffsetState.On();
            method.Render();
            polygonOffsetState.Off();
            polygonMode.Off();
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }

        #endregion
    }
}
