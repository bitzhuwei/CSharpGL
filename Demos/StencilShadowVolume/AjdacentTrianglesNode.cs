using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StencilShadowVolume
{
    partial class AjdacentTrianglesNode : ModernNode, IRenderable
    {

        public static AjdacentTrianglesNode Create(IBufferSource model, string position, string color, vec3 size)
        {
            var vs = new VertexShader(vertexCode);
            var fs = new FragmentShader(fragmentCode);
            var array = new ShaderArray(vs, fs);
            var map = new AttributeMap();
            map.Add("inPosition", position);
            map.Add("inColor", color);
            var builder = new RenderMethodBuilder(array, map);
            var node = new AjdacentTrianglesNode(model, builder);
            node.Initialize();
            node.ModelSize = size;

            return node;
        }

        private AjdacentTrianglesNode(IBufferSource model, params RenderMethodBuilder[] builders)
            : base(model, builders)
        { }

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

            this.RotationAngle += 1f;

            ICamera camera = arg.Camera;
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();

            var method = this.RenderUnit.Methods[0]; // the only render unit in this node.
            ShaderProgram program = method.Program;
            program.SetUniform("mvpMat", projection * view * model);

            method.Render(ControlMode.Random);
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }
    }
}
