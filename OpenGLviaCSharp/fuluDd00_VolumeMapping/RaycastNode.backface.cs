using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fuluDd00_VolumeMapping
{
    public partial class RaycastNode
    {
        private const string backfaceVert = @"#version 150

in vec3 position;
in vec3 boundingBox;

out vec3 passExitPoint;

uniform mat4 mapMat;


void main()
{
    passExitPoint = boundingBox;
    gl_Position = mapMat * vec4(position, 1.0);
}
";
        private const string backfaceFrag = @"#version 150

in vec3 passExitPoint;
out vec4 FragColor;


void main()
{
    FragColor = vec4(passExitPoint, 1.0);
}
";
    }
}
