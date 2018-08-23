using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c08d03_flat
{
    partial class TrianglesNode : PickableNode, IRenderable
    {
        public enum EMethod { Random, gl_VertexID, };
        public EMethod Method { get; set; }

        public static TrianglesNode Create(IBufferSource model, string position, string color, vec3 size)
        {
            RenderMethodBuilder randomBuilder, gl_VertexIDBuilder;
            {
                var vs = new VertexShader(randomVert);
                var fs = new FragmentShader(randomFrag);
                var array = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add("inPosition", position);
                map.Add("inColor", color);
                randomBuilder = new RenderMethodBuilder(array, map);
            }
            {
                var vs = new VertexShader(gl_VertexIDVert);
                var fs = new FragmentShader(gl_VertexIDFrag);
                var array = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add("inPosition", position);
                gl_VertexIDBuilder = new RenderMethodBuilder(array, map);
            }

            var node = new TrianglesNode(model, position, randomBuilder, gl_VertexIDBuilder);
            node.Initialize();
            node.ModelSize = size;

            return node;
        }

        private TrianglesNode(IBufferSource model, string positionNameInIBufferSource, params RenderMethodBuilder[] builders)
            : base(model, positionNameInIBufferSource, builders)
        {
            this.EnableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children;
        }

        #region IRenderable 成员

        public ThreeFlags EnableRendering { get; set; }

        public void RenderBeforeChildren(RenderEventArgs arg)
        {
            ICamera camera = arg.Camera;
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();

            var method = this.RenderUnit.Methods[(int)this.Method];
            ShaderProgram program = method.Program;
            program.SetUniform("mvpMat", projection * view * model);
            method.Render();
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }

        #endregion
    }

}
