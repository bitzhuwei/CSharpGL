using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c13d01_QueryObject
{
    partial class DrawModesNode : PickableNode, IRenderable
    {
        public enum EMethod { Smooth, Flat, };
        public EMethod Method { get; set; }

        public DrawMode DrawMode
        {
            get
            {
                var method = this.RenderUnit.Methods[0];
                foreach (var vao in method.VertexArrayObjects)
                {
                    return vao.DrawCommand.CurrentMode;
                }

                return CSharpGL.DrawMode.Patches;
            }
            set
            {
                var method = this.RenderUnit.Methods[0];
                foreach (var vao in method.VertexArrayObjects)
                {
                    vao.DrawCommand.CurrentMode = value;
                }
            }
        }

        public static DrawModesNode Create(IBufferSource model, string position, string color, vec3 size)
        {
            RenderMethodBuilder smoothBulder, flatBuilder;
            var lineWidthSwitch = new LineWidthSwitch(7);
            {
                var vs = new VertexShader(vertexCode);
                var fs = new FragmentShader(fragmentCode);
                var array = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add("inPosition", position);
                map.Add("inColor", color);
                //var pointSizeSwitch = new PointSizeSwitch(7);
                smoothBulder = new RenderMethodBuilder(array, map, lineWidthSwitch);
            }
            {
                var vs = new VertexShader(flatVertexCode);
                var fs = new FragmentShader(flatFragmentCode);
                var array = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add("inPosition", position);
                map.Add("inColor", color);
                //var pointSizeSwitch = new PointSizeSwitch(7);
                flatBuilder = new RenderMethodBuilder(array, map, lineWidthSwitch);
            }
            var node = new DrawModesNode(model, position, smoothBulder, flatBuilder);
            node.Initialize();
            node.ModelSize = size;

            return node;
        }

        private DrawModesNode(IBufferSource model, string positionNameInIBufferSource, params RenderMethodBuilder[] builders)
            : base(model, positionNameInIBufferSource, builders)
        {
            this.EnableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children;
            this.PointSize = 15;
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
            program.SetUniform("pointSize", this.PointSize);
            GL.Instance.Enable(GL.GL_PROGRAM_POINT_SIZE);
            method.Render();
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }

        #endregion

        public int PointSize { get; set; }

    }

}
