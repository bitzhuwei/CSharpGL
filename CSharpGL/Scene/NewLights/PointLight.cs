using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL.NewLights
{
    /// <summary>
    /// 
    /// </summary>
    public class PointLight : LightBase
    {

        private Attenuation attenuation = new Attenuation(1.0f, 0.0f, 0.0f);
        /// <summary>
        /// 
        /// </summary>
        public Attenuation Attenuation
        {
            get { return attenuation; }
            set { attenuation = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        public PointLight(vec3 position)
        {
            this.Position = position;
        }
    }
}
