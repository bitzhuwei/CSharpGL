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
        public vec3 Direction { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public float Angle { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="direciton"></param>
        /// <param name="angle"></param>
        public SpotLight(vec3 direciton, float angle)
        {
            this.Direction = direciton;
            this.Angle = angle;
        }

    }
}
