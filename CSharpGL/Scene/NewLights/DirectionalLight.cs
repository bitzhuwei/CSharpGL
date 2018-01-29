using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Directional light.
    /// </summary>
    public class DirectionalLight : LightBase
    {
        /// <summary>
        /// Direction from light source to object.
        /// </summary>
        public vec3 Direction { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="attenuation"></param>
        public DirectionalLight(vec3 direction, Attenuation attenuation = null)
            : base(attenuation == null ? new Attenuation(0.0f, 0.0f, 0.0f) : attenuation)
        {
            this.Direction = direction;
        }

    }
}
