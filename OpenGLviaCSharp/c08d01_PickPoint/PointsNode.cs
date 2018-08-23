using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c08d01_PickPoint
{
    partial class PointsNode : PickableNode, IRenderable
    {
        public enum EMethod { Random, gl_VertexID, };
        public EMethod Method { get; set; }

        public static PointsNode Create(IBufferSource model, string position, string color, vec3 size)
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

            var node = new PointsNode(model, position, randomBuilder, gl_VertexIDBuilder);
            node.Initialize();
            node.ModelSize = size;

            return node;
        }

        private PointsNode(IBufferSource model, string positionNameInIBufferSource, params RenderMethodBuilder[] builders)
            : base(model, positionNameInIBufferSource, builders)
        {
            this.HighlightIndex = -1;
            this.EnableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children;
        }

        public int HighlightIndex { get; set; }
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
            program.SetUniform("highlightIndex", this.HighlightIndex);
            GL.Instance.Enable(GL.GL_VERTEX_PROGRAM_POINT_SIZE);
            method.Render();
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }

        #endregion
    }

}
