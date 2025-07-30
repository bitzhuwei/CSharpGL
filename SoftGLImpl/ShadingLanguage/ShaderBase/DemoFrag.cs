using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftGLImpl {
    class DemoFrag : FragmentCodeBase {
        [InAttribute]
        vec3 passColor;

        [OutAttribute]
        vec4 outColor;

        public override void main() {
            outColor = new vec4(passColor, 1.0f);
        }
    }
}
