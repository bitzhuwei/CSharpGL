using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c11d00_Arcball
{
    partial class LinesNode : ModernNode, IRenderable
    {
        private float radius;

        public static LinesNode Create(float radius)
        {
            var vs = new VertexShader(vertexCode);
            var fs = new FragmentShader(fragmentCode);
            var array = new ShaderArray(vs, fs);
            var map = new AttributeMap();
            //map.Add("inPosition", LinesModel.strPosition);
            map.Add("inColor", LinesModel.strColor);
            //var depthTestSwitch = new DepthTestSwitch(false);
            var lineWidthSwith = new LineWidthSwitch(5);
            var builder = new RenderMethodBuilder(array, map, lineWidthSwith);

            var model = new LinesModel(radius);
            var node = new LinesNode(model, builder);
            node.radius = radius;
            node.Initialize();

            return node;
        }

        private LinesNode(IBufferSource model, params RenderMethodBuilder[] builders)
            : base(model, builders)
        {
            float length = radius / (float)Math.Sqrt(2);
            this.mouseDownPosition = new vec3(-length, length, 0);
            this.mouseMovePosition = new vec3(length, length, 0);
            this.mouseDown = false;
        }

        #region IRenderable 成员

        private ThreeFlags enableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children;
        public ThreeFlags EnableRendering { get { return this.enableRendering; } set { this.enableRendering = value; } }

        private LineStippleSwitch stippleSwitch = new LineStippleSwitch(1, 0x0F0F);
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
            program.SetUniform("mouseDownPosition", this.mouseDownPosition);
            program.SetUniform("mouseMovePosition", this.mouseMovePosition);
            bool mouseDown = this.mouseDown;
            if (!mouseDown)
            {
                this.stippleSwitch.On();
            }
            method.Render();
            if (!mouseDown)
            {
                this.stippleSwitch.Off();
            }
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }

        #endregion

        private vec3 mouseDownPosition;
        private vec3 mouseMovePosition;
        private bool mouseDown = false;

        /// <summary>
        /// Indicates wheter the mouse is down or not.
        /// </summary>
        public bool IsMouseDown { get { return this.mouseDown; } }
    }
}
