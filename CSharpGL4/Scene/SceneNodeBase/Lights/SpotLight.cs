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
        public vec3 Direction { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public float Angle { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="direciton"></param>
        /// <param name="angle">in degree.</param>
        public SpotLight(vec3 position, vec3 direciton, float angle)
        {
            if (position == direciton) { throw new ArgumentException(); }
            if (position - direciton == upVector) { upVector = new vec3(1, 1, 1); }

            this.Position = position;
            this.Direction = direciton;
            this.Angle = angle;
        }

        public override mat4 GetProjectionMatrix(ShdowMappingEventArgs arg)
        {
            mat4 projection = glm.perspective((float)(this.Angle * Math.PI / 180.0), 1.0f, 0.01f, 1000f);
            return projection;
        }

        public override mat4 GetViewMatrix(ShdowMappingEventArgs arg)
        {
            mat4 view = glm.lookAt(this.Position, this.Position - this.Direction, this.upVector);
            return view;
        }

        private vec3 upVector = new vec3(0, 1, 0);
    }
}
