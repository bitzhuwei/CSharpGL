using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZeroAttributeInVertexShader
{
    partial class ZeroAttributeNode : ModernNode, IRenderable
    {
        public static ZeroAttributeNode Create()
        {
            var vs = new VertexShader(vertexShader);// not attribute in vertex shader.
            var fs = new FragmentShader(fragmentShader);
            var provider = new ShaderArray(vs, fs);
            var map = new AttributeMap();// no items in this map.
            var builder = new RenderMethodBuilder(provider, map, new PointSpriteState());
            var model = new ZeroAttributeModel(DrawMode.TriangleStrip, 0, 4);
            var node = new ZeroAttributeNode(model, builder);
            node.ModelSize = new vec3(2.05f, 2.05f, 0.01f);
            node.Initialize();

            return node;
        }

        private ZeroAttributeNode(IBufferSource model, params RenderMethodBuilder[] builders)
            : base(model, builders)
        {
        }

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
            ICamera camera = arg.CameraStack.Peek();
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();

            RenderMethod method = this.RenderUnit.Methods[0];
            ShaderProgram program = method.Program;
            program.SetUniform("mvp", projection * view * model);

            method.Render();
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }
    }
}
