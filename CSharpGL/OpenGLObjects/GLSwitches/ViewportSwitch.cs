using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public class ViewportSwitch : GLSwitch
    {
        private int originalX;
        private int originalY;
        private int originalWidth;
        private int originalHeight;

        public ViewportSwitch()
        {
            int[] viewport = OpenGL.GetViewport();
            this.Init(viewport[0], viewport[1], viewport[2], viewport[3],
                viewport[0], viewport[1], viewport[2], viewport[3]);
        }
      
        public ViewportSwitch(int x, int y, int width, int height)
        {
            int[] viewport = OpenGL.GetViewport();

            this.Init(x, y, width, height,
                viewport[0], viewport[1], viewport[2], viewport[3]);
        }

        public ViewportSwitch(int x, int y, int width, int height,
            int originalX, int originalY, int originalWidth, int originalHeight)
        {
            this.Init(x, y, width, height,
                originalX, originalY, originalWidth, originalHeight);
        }

        private void Init(int x, int y, int width, int height,
          int originalX, int originalY, int originalWidth, int originalHeight)
        {
            this.X = x; this.Y = y; this.Width = width; this.Height = height;
            this.originalX = originalX;
            this.originalY = originalY;
            this.originalWidth = originalWidth;
            this.originalHeight = originalHeight;
        }

        public override string ToString()
        {
            return string.Format("glViewport({0}, {1}, {2}, {3});",
                X, Y, Width, Height);
        }

        protected override void SwitchOn()
        {
            OpenGL.Viewport(X, Y, Width, Height);
        }

        protected override void SwitchOff()
        {
            OpenGL.Viewport(originalX, originalY, originalWidth, originalHeight);
        }

        public int X { get; set; }

        public int Y { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

    }

}
