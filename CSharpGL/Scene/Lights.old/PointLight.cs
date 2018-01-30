using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
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
            this.WorldPosition = position;
        }

        /// <summary>
        /// 
        /// </summary>
        public vec3 WorldPosition { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override mat4 GetProjectionMatrix()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override mat4 GetViewMatrix()
        {
            throw new NotImplementedException();
        }
    }
}
