using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public abstract class GLSwitch
    {
        public GLSwitch() { }

        public abstract void On();

        public abstract void Off();
    }

}
