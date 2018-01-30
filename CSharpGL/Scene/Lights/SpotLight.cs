using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Spot light.
    /// </summary>
    public sealed class SpotLight : LightBase
    {
        /// <summary>
        /// Where this spot light looks at.
        /// </summary>
        public vec3 Target { get; set; }

        /// <summary>
        /// Cos(angle).
        /// </summary>
        public float CutOff { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position">light's position.</param>
        /// <param name="target">Where this spot light looks at.</param>
        /// <param name="cutOff">Cos(angle). angle ranges in [0, 90]. Spot light's full angle ranges in [0, 180].</param>
        /// <param name="attenuation"></param>
        public SpotLight(vec3 position, vec3 target, float cutOff, Attenuation attenuation = null)
            : base(attenuation == null ? new Attenuation(1.0f, 0.0f, 0.0f) : attenuation)
        {
            this.Position = position;
            this.Target = target;
            this.CutOff = cutOff;
        }

    }
}
