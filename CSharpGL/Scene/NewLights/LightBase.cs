using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL.NewLights
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class LightBase
    {
        private vec3 color = new vec3(1, 1, 1);
        /// <summary>
        /// 
        /// </summary>
        public vec3 Color { get { return this.color; } set { this.color = value; } }

        /// <summary>
        /// 
        /// </summary>
        public float AmbientIntensity { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public float DiffuseIntensity { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public vec3 Position { get; set; }

    }
}
