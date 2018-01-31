using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Spot light.
    /// </summary>
    public abstract class NSpotLight : LightBase
    {
        /// <summary>
        /// 
        /// </summary>
        public readonly float cutOff = (float)(Math.Cos(45.0 * 180.0 / Math.PI));

        /// <summary>
        /// 
        /// </summary>
        public readonly vec3 direction;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position">light's position.</param>
        /// <param name="direction"></param>
        /// <param name="attenuation"></param>
        public NSpotLight(vec3 position, vec3 direction, Attenuation attenuation)
            : base(attenuation == null ? new Attenuation(1.0f, 0.0f, 0.0f) : attenuation)
        {
            this.Position = position;
            this.direction = direction;
        }

    }
}
