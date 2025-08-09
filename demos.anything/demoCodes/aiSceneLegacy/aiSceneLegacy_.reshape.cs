using Assimp.Unmanaged;
using Assimp;
using CSharpGL;
using demos.anything;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Import3D;
using System.Windows.Forms.Design;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.IO;
using System.Diagnostics;
using static System.Net.WebRequestMethods;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.ConstrainedExecution;
using System.Drawing.Design;
using System.Numerics;

namespace aiSceneLegacy {
    internal unsafe partial class aiSceneLegacy_ : demoCode {

        public override void reshape(GL gl, int width, int height) {
            //this.scene.camera.AspectRatio = ((float)this.canvas.Width) / ((float)this.canvas.Height);

            // Prevent A Divide By Zero By
            if (height == 0) {
                // Making Height Equal One
                height = 1;
            }

            gl.glViewport(0, 0, width, height);                    // Reset The Current Viewport

            gl.glMatrixMode(GL.GL_PROJECTION);                        // Select The Projection Matrix
            gl.glLoadIdentity();                           // Reset The Projection Matrix

            // Calculate The Aspect Ratio Of The Window
            CSharpGL.mat4 projection = glm.perspective(45.0f * (float)Math.PI / 180.0f, (GLfloat)width / (GLfloat)height, 0.1f, 1000.0f);

            //  Set the projection matrix.(projection and view matrix actually.)
            var array = (projection).ToArray();
            fixed (GLfloat* p = array) {
                gl.glMultMatrixf(p);
            }

            gl.glMatrixMode(GL.GL_MODELVIEW);                     // Select The Modelview Matrix
            gl.glLoadIdentity();                            // Reset The Modelview Matrix

        }
    }
}
