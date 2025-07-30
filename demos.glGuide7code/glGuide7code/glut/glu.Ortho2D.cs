
using CSharpGL;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;

namespace demos.glGuide7code {
    internal static unsafe partial class glu {
        public static unsafe void Ortho2D(float left, float right, float bottom, float top) {
            var gl = GL.Current; if (gl == null) { return; }

            float[] orthoMatrix = {
                2.0f / (right - left),  0.0f,          0.0f,          0.0f,
                0.0f,                   2.0f / (top - bottom), 0.0f,          0.0f,
                0.0f,                   0.0f,          -1.0f,         0.0f,
                -(right + left) / (right - left), -(top + bottom) / (top - bottom), 0.0f, 1.0f
            };

            gl.glMatrixMode(GL.GL_PROJECTION);
            gl.glLoadMatrixf(orthoMatrix);
            gl.glMatrixMode(GL.GL_MODELVIEW);
        }
    }
}