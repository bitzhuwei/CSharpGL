using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public interface IWorldSpace
    {
        vec3 Position { get; set; }

        vec3 Scale { get; set; }

        vec3 RotationAxls { get; set; }

        float RotationAngle { get; set; }

        vec3 Size { get; set; }
    }
}
