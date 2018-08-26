using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c08d00_gl_VertexID
{
    partial class PointsNode : ModernNode, IRenderable
    {
        public enum EMethod { Random, gl_VertexID, };
        public EMethod Method { get; set; }

        public static PointsNode Create(IBufferSource model, string position, string color, vec3 size)
        {
            RenderMethodBuilder randomBuilder, gl_VertexIDBuilder;
            var pointSizeSwitch = new PointSizeSwitch(5);
            {
                var vs = new VertexShader(randomVert);
                var fs = new FragmentShader(randomFrag);
                var array = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add("inPosition", position);
                map.Add("inColor", color);
                randomBuilder = new RenderMethodBuilder(array, map, pointSizeSwitch);
            }
            {
                var vs = new VertexShader(gl_VertexIDVert);
                var fs = new FragmentShader(gl_VertexIDFrag);
                var array = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add("inPosition", position);
                gl_VertexIDBuilder = new RenderMethodBuilder(array, map, pointSizeSwitch);
            }

            var node = new PointsNode(model, randomBuilder, gl_VertexIDBuilder);
            node.Initialize();
            node.ModelSize = size;

            return node;
        }

        private PointsNode(IBufferSource model, params RenderMethodBuilder[] builders)
            : base(model, builders)
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
