using System;
using System.IO;

namespace CSharpGL.Demos
{
    internal partial class WaterRenderer
    {
        protected override void DoInitialize()
        {
            base.DoInitialize();

            this.SetUniform("factor", 100.0f);
        }
    }
}