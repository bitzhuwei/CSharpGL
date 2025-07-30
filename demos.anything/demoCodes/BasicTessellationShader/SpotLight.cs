using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicTessellationShader {
    class SpotLight : PointLight {
        public vec3 direction;
        public float cutoff;

        public SpotLight() {
            this.direction = new vec3(0, 0, 0);
            this.cutoff = 0;
        }
    }
}
