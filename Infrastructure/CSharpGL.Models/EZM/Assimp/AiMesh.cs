using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public class AiMesh
    {
        public vec3[] Vertexes { get; internal set; }

        public vec3[] Normals { get; internal set; }

        public vec2[] TexCoords { get; internal set; }

        public vec4[] boneWeights { get; internal set; }

        public uvec4[] boneIndexes { get; internal set; }

        public uint[] indexes { get; internal set; }

    }
}
