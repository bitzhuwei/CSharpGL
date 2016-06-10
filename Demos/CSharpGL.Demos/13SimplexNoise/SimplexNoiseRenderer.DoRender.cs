using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Demos
{
    partial class SimplexNoiseRenderer 
    {

        protected override void DoRender(RenderEventArgs arg)
        {
            // setup uniforms
            var now = DateTime.Now;
            time = (float)now.Subtract(this.lastTime).TotalMilliseconds;
            this.lastTime = now;
            this.SetUniform("time", time);
           
            base.DoRender(arg);
        }
    }
}
