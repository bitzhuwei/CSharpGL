using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL.Renderers
{
    public interface ITransform
    {
        mat4 ModelMatrix { get; set; }
    }
}
