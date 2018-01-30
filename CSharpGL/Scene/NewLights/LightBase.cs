using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Base type of directional light, point light and spot light.
    /// </summary>
    public abstract class LightBase
    {
        private vec3 color = new vec3(1, 1, 1);
        /// <summary>
        /// Light's color.
        /// </summary>
        public vec3 Color { get { return this.color; } set { this.color = value; } }

        /// <summary>
        /// Diffuse intensity.
        /// </summary>
        public vec3 Diffuse { get; set; }

        /// <summary>
        /// Specular intensity.
        /// </summary>
        public vec3 Specular { get; set; }

        /// <summary>
        /// Light's position.
        /// </summary>
        public vec3 Position { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Attenuation Attenuation { get; set; }

        /// <summary>
        /// Base type of all lights.
        /// </summary>
        /// <param name="attenuation"></param>
        public LightBase(Attenuation attenuation)
        {
            if (attenuation == null) { throw new ArgumentNullException(); }

            this.Attenuation = attenuation;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("Color:{0}, Pos:{1}", this.Color, this.Position);
        }

    }
}
