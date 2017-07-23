using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public class SpotLight : LightBase
    {
        /// <summary>
        /// 
        /// </summary>
        public vec3 Position { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public vec3 Target { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public float Angle { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public float Near { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public float Far { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="target"></param>
        /// <param name="angle">in degree.</param>
        public SpotLight(vec3 position, vec3 target, float angle, float near = 0.1f, float far = 50.0f)
        {
            if (position == target) { throw new ArgumentException(); }
            if (position - target == upVector) { upVector = new vec3(1, 1, 1); }

            this.Position = position;
            this.Target = target;
            this.Angle = angle;
            this.Near = near;
            this.Far = far;
        }

        public override mat4 GetProjectionMatrix(ShdowMappingEventArgs arg)
        {
            const float aspectRatio = 1.0f;

            mat4 projection = glm.perspective((float)(this.Angle * Math.PI / 180.0), aspectRatio, this.Near, this.Far);
            return projection;
        }

        public override mat4 GetViewMatrix(ShdowMappingEventArgs arg)
        {
            mat4 view = glm.lookAt(this.Position, this.Target, this.upVector);
            return view;
        }

        private vec3 upVector = new vec3(0, 1, 0);
    }
}
