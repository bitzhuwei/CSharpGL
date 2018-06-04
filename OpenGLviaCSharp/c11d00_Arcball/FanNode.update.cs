using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c11d00_Arcball
{
    partial class FanNode
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
            if (yy0 >= 0)
            {
                this.InMouseDownPosition = new vec3(x0, y0, z0);
                this.InMouseMovePosition = new vec3(x0, y0, z0);
            }
            else
            {
                float length = (float)Math.Sqrt(x0 * x0 + z0 * z0) * 2;
                this.InMouseDownPosition = new vec3(x0 * diameter / length, 0.01f, z0 * diameter / length);
                this.InMouseMovePosition = new vec3(x0 * diameter / length, 0.01f, z0 * diameter / length);
            }
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

            if (yy0 >= 0)
            {
                this.InMouseMovePosition = new vec3(x0, y0, z0);
            }
            else
            {
                float length = (float)Math.Sqrt(x0 * x0 + z0 * z0) * 2;
                this.InMouseMovePosition = new vec3(x0 * diameter / length, 0.01f, z0 * diameter / length);
            }
        }

        public void MouseUp(int x, int y, int width, int height)
        {
            this.mouseDown = false;
            this.InMouseDownPosition = new vec3(0, 0, 0);
            this.InMouseMovePosition = new vec3(0, 0, 0);
        }

    }
}
