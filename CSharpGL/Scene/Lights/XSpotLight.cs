using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Spot light.
    /// </summary>
    public sealed class XSpotLight : NSpotLight
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position">light's position.</param>
        /// <param name="attenuation"></param>
        public XSpotLight(vec3 position, Attenuation attenuation)
            : base(position, new vec3(1, 0, 0), attenuation)
        {
        }

    }
}
