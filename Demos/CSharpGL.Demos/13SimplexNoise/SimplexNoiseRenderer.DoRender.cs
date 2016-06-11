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
        private float timeElapsingSpeed = 1.0f;
        /// <summary>
        /// 时间流逝速度
        /// </summary>
        public float TimeElapsingSpeed
        {
            get { return timeElapsingSpeed; }
            set { timeElapsingSpeed = value; }
        }

        private float rainDrop = 1.0f;
        /// <summary>
        /// 雨滴效果强度
        /// </summary>
        public float RainDrop
        {
            get { return rainDrop; }
            set { rainDrop = value; }
        }

        private float granularity = 4.0f;
        /// <summary>
        /// 颗粒粒度
        /// </summary>
        public float Granularity
        {
            get { return granularity; }
            set { granularity = value; }
        }

        private float time;

        protected override void DoRender(RenderEventArgs arg)
        {
            // setup uniforms
            var now = DateTime.Now;
            //float time = (float)now.Subtract(this.lastTime).TotalMilliseconds;
            this.lastTime = now;
            time += 0.005f;
            this.SetUniform("time", time * timeElapsingSpeed);
            this.SetUniform("rainDrop", this.rainDrop);
            this.SetUniform("granularity", this.granularity);

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
