using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace CSharpGL
{
    public partial class WinGL
    {
        public override void Begin(uint mode)
        {
            OpenGL.Begin(mode);
        }

        public override void End()
        {
            OpenGL.End();
        }
    }
}