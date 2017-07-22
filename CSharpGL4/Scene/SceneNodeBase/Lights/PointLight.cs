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

        public override void CastShadow(RenderEventArgs arg)
        {
            throw new NotImplementedException();
        }

        public vec3 WorldPosition { get; set; }
    }
}
