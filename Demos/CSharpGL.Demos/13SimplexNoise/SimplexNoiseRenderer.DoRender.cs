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
        private float timeSpeed = 1.0f;
        public float TimeSpeed
        {
            get { return timeSpeed; }
            set { timeSpeed = value; }
        }

        private float partsFactor = 5.0f;
        public float PartsFactor
        {
            get { return partsFactor; }
            set { partsFactor = value; }
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            // setup uniforms
            var now = DateTime.Now;
            float time = (float)now.Subtract(this.lastTime).TotalMilliseconds;
            this.lastTime = now;
            this.SetUniform("time", time * timeSpeed);
            this.SetUniform("partsFactor", partsFactor);

            mat4 projection = arg.Camera.GetProjectionMat4();
            mat4 view = arg.Camera.GetViewMat4();
            mat4 model = mat4.identity();
            this.SetUniform("projectionMatrix", projection);
            this.SetUniform("viewMatrix", view);
            this.SetUniform("modelMatrix", model); 

            base.DoRender(arg);
        }
    }
}
