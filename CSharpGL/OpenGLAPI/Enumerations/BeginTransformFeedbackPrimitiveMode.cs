using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    public enum BeginTransformFeedbackPrimitiveMode : uint
    {
        Points = OpenGL.GL_POINTS,
        Lines = OpenGL.GL_LINES,
        Triangles = OpenGL.GL_TRIANGLES,
    }

}
