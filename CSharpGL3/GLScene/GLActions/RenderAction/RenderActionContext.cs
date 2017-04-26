using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public class RenderActionContext
    {
        public ShaderProgram shaderProgram;
        public SortedList<Type, GLState> glStateList;

    }
}
