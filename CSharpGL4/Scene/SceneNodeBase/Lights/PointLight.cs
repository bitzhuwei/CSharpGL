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

        public override mat4 GetProjectionMatrix(ShdowMappingEventArgs arg)
        {
            throw new NotImplementedException();
        }

        public override mat4 GetViewMatrix(ShdowMappingEventArgs arg)
        {
            throw new NotImplementedException();
        }
    }
}
