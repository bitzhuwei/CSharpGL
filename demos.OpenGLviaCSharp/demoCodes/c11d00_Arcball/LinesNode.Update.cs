using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c11d00_Arcball {
    partial class LinesNode {
        public void MouseDown(int x, int y, int width, int height) {
            float x0 = (x - width / 2.0f) / (float)(width);
            float z0 = (y - height / 2.0f) / (float)(height);
            float yy0 = 0.5f * 0.5f - x0 * x0 - z0 * z0;
            float y0 = yy0 >= 0 ? (float)Math.Sqrt(yy0) : 0.5f;
            float diameter = this.radius * 2;
            x0 = x0 * diameter;
            y0 = y0 * diameter;
            z0 = z0 * diameter;

            this.mouseDown = true;
            this.outMouseDownPosition = new vec3(x0, y0, z0);
            this.outMouseMovePosition = new vec3(x0, y0, z0);
            if (yy0 >= 0) {
                this.inMouseDownPosition = new vec3(x0, y0, z0);
                this.inMouseMovePosition = new vec3(x0, y0, z0);
            }
            else {
                float length = (float)Math.Sqrt(x0 * x0 + z0 * z0) * 2;
                this.inMouseDownPosition = new vec3(x0 * diameter / length, y0, z0 * diameter / length);
                this.inMouseMovePosition = new vec3(x0 * diameter / length, y0, z0 * diameter / length);
            }
        }

        public void MouseMove(int x, int y, int width, int height) {
            float x0 = (x - width / 2.0f) / (float)(width);
            float z0 = (y - height / 2.0f) / (float)(height);
            float yy0 = 0.5f * 0.5f - x0 * x0 - z0 * z0;
            float y0 = yy0 >= 0 ? (float)Math.Sqrt(yy0) : 0.5f;
            float diameter = this.radius * 2;
            x0 = x0 * diameter;
            y0 = y0 * diameter;
            z0 = z0 * diameter;

            this.outMouseMovePosition = new vec3(x0, y0, z0);
            if (yy0 >= 0) {
                this.inMouseMovePosition = new vec3(x0, y0, z0);
            }
            else {
                float length = (float)Math.Sqrt(x0 * x0 + z0 * z0) * 2;
                this.inMouseMovePosition = new vec3(x0 * diameter / length, y0, z0 * diameter / length);
            }
        }

        public void MouseUp(int x, int y, int width, int height) {
            this.mouseDown = false;
            this.outMouseDownPosition = new vec3(0, 0, 0);
            this.outMouseMovePosition = new vec3(0, 0, 0);
            this.inMouseDownPosition = new vec3(0, 0, 0);
            this.inMouseMovePosition = new vec3(0, 0, 0);
        }

    }
}
