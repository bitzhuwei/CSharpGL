using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c11d00_Arcball
{
    partial class LinesNode
    {
        public void MouseDown(int x, int y, int width, int height)
        {
            float x0 = (x - width / 2.0f) / (float)(width);
            float z0 = (y - height / 2.0f) / (float)(height);
            float yy0 = 0.5f * 0.5f - x0 * x0 - z0 * z0;
            float y0 = yy0 >= 0 ? (float)Math.Sqrt(yy0) : 0.5f;
            float diameter = this.radius * 2;
            x0 = x0 * diameter;
            y0 = y0 * diameter;
            z0 = z0 * diameter;

            this.mouseDown = true;
            this.mouseDownPosition = new vec3(x0, y0, z0);
            this.mouseMovePosition = new vec3(x0, y0, z0);
        }

        public void MouseMove(int x, int y, int width, int height)
        {
            float x0 = (x - width / 2.0f) / (float)(width);
            float z0 = (y - height / 2.0f) / (float)(height);
            float yy0 = 0.5f * 0.5f - x0 * x0 - z0 * z0;
            float y0 = yy0 >= 0 ? (float)Math.Sqrt(yy0) : 0.5f;
            float diameter = this.radius * 2;
            x0 = x0 * diameter;
            y0 = y0 * diameter;
            z0 = z0 * diameter;

            this.mouseMovePosition = new vec3(x0, y0, z0);
        }

        public void MouseUp(int x, int y, int width, int height)
        {
            this.mouseDown = false;
            this.mouseDownPosition = new vec3(0, 0, 0);
            this.mouseMovePosition = new vec3(0, 0, 0);
        }

    }
}
