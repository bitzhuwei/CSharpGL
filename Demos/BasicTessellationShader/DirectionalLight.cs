using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicTessellationShader
{
    class DirectionalLight : BaseLight
    {
        public vec3 direction;

        public DirectionalLight()
        {
            this.direction = new vec3(0, 0, 0);
        }
    }
}
