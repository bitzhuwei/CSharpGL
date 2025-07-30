using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftGLImpl {
    class DemoVert : VertexCodeBase {
        [InAttribute]
        vec3 inPosition;
        [InAttribute]
        vec3 inColor;

        [uniform]
        mat4 mvpMatrix;

        [OutAttribute]
        vec3 passColor;

        public override void main() {
            gl_Position = mvpMatrix * new vec4(inPosition, 1.0f);
            passColor = inColor;
        }
    }



}
