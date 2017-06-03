using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public class TransformComponent : ComponentBase
    {
        /// <summary>
        /// World position.
        /// </summary>
        public vec3 Position { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public vec3 Scale { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public vec3 Rotate { get; set; }
    }
}
