using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public class DirectionalLight : LightBase
    {
        /// <summary>
        /// 
        /// </summary>
        public vec3 Direction { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="direction"></param>
        public DirectionalLight(vec3 direction)
        {
            this.Direction = direction;
        }
    }
}
