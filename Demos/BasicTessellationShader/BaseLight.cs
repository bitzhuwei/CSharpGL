using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicTessellationShader
{
    class BaseLight
    {
        public vec3 Color;
        public float AmbientIntensity;
        public float DiffuseIntensity;

        public BaseLight()
        {
            this.Color = new vec3(0, 0, 0);
            this.AmbientIntensity = 0;
            this.DiffuseIntensity = 0;
        }

    }

}
