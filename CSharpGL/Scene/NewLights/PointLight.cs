using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Point light.
    /// </summary>
    public sealed class PointLight : LightBase
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="attenuation"></param>
        public PointLight(vec3 position, Attenuation attenuation = null)
            : base(attenuation == null ? new Attenuation(1.0f, 0.0f, 0.0f) : attenuation)
        {
            this.Position = position;
        }

        public override mat4 GetProjectionMatrix()
        {
            throw new NotImplementedException();
        }

        public override mat4 GetViewMatrix()
        {
            throw new NotImplementedException();
        }
    }
}
