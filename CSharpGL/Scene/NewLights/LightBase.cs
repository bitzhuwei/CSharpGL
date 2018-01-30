using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Base type of directional light, point light and spot light.
    /// </summary>
    [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
    public abstract class LightBase
    {
        //private vec3 color = new vec3(1, 1, 1);
        ///// <summary>
        ///// Light's color.
        ///// </summary>
        //public vec3 Color { get { return this.color; } set { this.color = value; } }

        private vec3 diffuse = new vec3(1, 1, 1);
        /// <summary>
        /// Diffuse intensity.
        /// </summary>
        public vec3 Diffuse { get { return this.diffuse; } set { this.diffuse = value; } }

        private vec3 specular = new vec3(1, 1, 1);
        /// <summary>
        /// Specular intensity.
        /// </summary>
        public vec3 Specular { get { return this.specular; } set { this.specular = value; } }

        /// <summary>
        /// Light's position.
        /// </summary>
        public vec3 Position { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
        public Attenuation Attenuation { get; set; }

        /// <summary>
        /// Base type of all lights.
        /// </summary>
        /// <param name="attenuation"></param>
        public LightBase(Attenuation attenuation)
        {
            this.Attenuation = attenuation;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}: Color:{1}, {2}", this.GetType().Name, this.diffuse, this.specular);
        }

    }
}
