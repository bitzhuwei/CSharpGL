using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CSharpGL.Demos
{
    abstract class PickingScript : Script
    {
        public abstract void Bind();

        public abstract void Unbind();

    }
}
