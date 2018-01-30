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
        /// Direction from light source to object.
        /// </summary>
        public vec3 Direction { get; set; }

        /// <summary>
        /// Directional light.
        /// </summary>
        /// <param name="direction">Direction to the light's position</param>
        public DirectionalLight(vec3 direction)
            : base(null)
        {
            this.Direction = direction;
        }

    }
}
