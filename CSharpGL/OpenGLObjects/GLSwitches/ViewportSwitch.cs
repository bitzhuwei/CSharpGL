using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public class ViewportSwitch : GLSwitch
    {
        private int[] original = new int[4];

        public ViewportSwitch()
        {
            int[] viewport = OpenGL.GetViewport();

            this.Init(viewport[0], viewport[1], viewport[2], viewport[3]);
        }

        public ViewportSwitch(int x, int y, int width, int height)
        {
            this.Init(x, y, width, height);
        }

        public ViewportSwitch(int[] viewport)
        {
            this.Init(viewport[0], viewport[1], viewport[2], viewport[3]);
        }

        private void Init(int x, int y, int width, int height)
        {
            this.X = x; this.Y = y; this.Width = width; this.Height = height;
        }

        public override string ToString()
        {
            return string.Format("glViewport({0}, {1}, {2}, {3});",
                X, Y, Width, Height);
        }

        protected override void SwitchOn()
        {
            OpenGL.GetInteger(GetTarget.Viewport, original);

            OpenGL.Viewport(X, Y, Width, Height);
        }

        protected override void SwitchOff()
        {
            OpenGL.Viewport(original[0], original[1], original[2], original[3]);
        }

        public int X { get; set; }

        public int Y { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

    }

}
