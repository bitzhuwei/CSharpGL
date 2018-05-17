using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c03d05_WindowSpace
{
    partial class RectNode : ModernNode, IRenderable
    {
        public static RectNode Create(int x, int y, int width, int height)
        {
            var model = new RectModel();
            var vs = new VertexShader(vertexCode);
            var fs = new FragmentShader(fragmentCode);
            var array = new ShaderArray(vs, fs);
            var map = new AttributeMap();
            map.Add("inPosition", RectModel.strPosition);
            map.Add("inColor", RectModel.strColor);
            var builder = new RenderMethodBuilder(array, map);

            var node = new RectNode(x, y, width, height, model, builder);
            node.Initialize();

            return node;
        }

        private RectNode(int x, int y, int width, int height, IBufferSource model, params RenderMethodBuilder[] builders)
            : base(model, builders)
        {
            this.EnableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children;
            this.scissorTestSwitch = new ScissorTestSwitch(x, y, width, height, true);
            this.viewportSwitch = new ViewportSwitch(x, y, width, height);
        }

        private ScissorTestSwitch scissorTestSwitch;
        private ViewportSwitch viewportSwitch;

        public int X
        {
            get { return this.scissorTestSwitch.X; }
            set
            {
                this.scissorTestSwitch.X = value;
                this.viewportSwitch.X = value;
            }
        }
        public int Y
        {
            get { return this.scissorTestSwitch.Y; }
            set
            {
                this.scissorTestSwitch.Y = value;
                this.viewportSwitch.Y = value;
            }
        }
        public int Width
        {
            get { return this.scissorTestSwitch.Width; }
            set
            {
                this.scissorTestSwitch.Width = value;
                this.viewportSwitch.Width = value;
            }
        }
        public int Height
        {
            get { return this.scissorTestSwitch.Height; }
            set
            {
                this.scissorTestSwitch.Height = value;
                this.viewportSwitch.Height = value;
            }
        }
        #region IRenderable 成员

        public ThreeFlags EnableRendering { get; set; }

        public void RenderBeforeChildren(RenderEventArgs arg)
        {
            this.scissorTestSwitch.On();
            this.viewportSwitch.On();
            var method = this.RenderUnit.Methods[0];
            ShaderProgram program = method.Program;
            method.Render();
            this.scissorTestSwitch.Off();
            this.viewportSwitch.Off();
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }

        #endregion
    }
}
