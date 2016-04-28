using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public enum PolugonOffset : uint
    {
        Factor = GL.GL_POLYGON_OFFSET_FACTOR,// = 0x8038;
        Units = GL.GL_POLYGON_OFFSET_UNITS,// = 0x2A00;
        Point = GL.GL_POLYGON_OFFSET_POINT,// = 0x2A01;
        Line = GL.GL_POLYGON_OFFSET_LINE,// = 0x2A02;
        Fill = GL.GL_POLYGON_OFFSET_FILL,// = 0x8037;
    }
}
