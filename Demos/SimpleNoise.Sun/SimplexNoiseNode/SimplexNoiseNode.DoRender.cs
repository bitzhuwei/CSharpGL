using CSharpGL;
using System;

namespace SimpleNoise.Sun
{
    partial class SimplexNoiseNode
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

        private DateTime lastTime;

        public float RotateSpeed { get; set; }

        public override void RenderBeforeChildren(RenderEventArgs arg)
        {
            ICamera camera = arg.CameraStack.Peek();
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();
            var now = DateTime.Now;
            float time = (float)now.Subtract(this.lastTime).TotalMilliseconds * 0.001f;
            this.RotationAngle += this.RotateSpeed;

            RenderMethod method = this.RenderUnit.Methods[0];
            ShaderProgram program = method.Program;
            // setup uniforms
            program.SetUniform("projectionMatrix", projection);
            program.SetUniform("viewMatrix", view);
            program.SetUniform("modelMatrix", model);
            program.SetUniform("time", time * timeElapsingSpeed);
            program.SetUniform("rainDrop", this.rainDrop);
            program.SetUniform("granularity", this.granularity);

            method.Render();
        }

        public override void RenderAfterChildren(RenderEventArgs arg)
        {
        }
    }
}