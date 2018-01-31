using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Directional light.
    /// </summary>
    public sealed class DirectionalLight : LightBase
    {
        /// <summary>
        /// Direction to the light's position.
        /// </summary>
        public vec3 Direction { get; set; }

        private static readonly Attenuation useless = new Attenuation(1, 0, 0);
        /// <summary>
        /// Directional light.
        /// </summary>
        /// <param name="direction">Direction to the light's position.</param>
        public DirectionalLight(vec3 direction)
            : base(useless)
        {
            this.Direction = direction;
        }

    }
}
