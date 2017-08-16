using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicTessellationShader
{
    class PointLight : BaseLight
    {
        public vec3 position;

        public struct Attenuation
        {
            public float constant;
            public float linear;
            public float exp;
        }

        public Attenuation attenuation;

        public PointLight()
        {
            this.position = new vec3(0, 0, 0);
            this.attenuation.constant = 1;
            this.attenuation.linear = 0;
            this.attenuation.exp = 0;
        }
    }
}
