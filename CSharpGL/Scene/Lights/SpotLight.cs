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
        /// Direction to the light's position.
        /// </summary>
        public vec3 Direction { get; set; }

        /// <summary>
        /// Cos(angle).
        /// </summary>
        public float CutOff { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position">light's position.</param>
        /// <param name="direction">Direction to the light's position.</param>
        /// <param name="cutOff">Cos(angle)</param>
        /// <param name="attenuation"></param>
        public SpotLight(vec3 position, vec3 direction, float cutOff, Attenuation attenuation = null)
            : base(attenuation == null ? new Attenuation(1.0f, 0.0f, 0.0f) : attenuation)
        {
            this.Position = position;
            this.Direction = direction;
            this.CutOff = cutOff;
        }

    }
}
