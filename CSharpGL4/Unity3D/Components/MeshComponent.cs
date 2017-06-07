using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// What are we going to render?
    /// </summary>
    public class MeshComponent : ComponentBase
    {
        /// <summary>
        /// What are we going to render?
        /// </summary>
        /// <param name="gameObject"></param>
        public MeshComponent(GameObject gameObject) : base(gameObject) { }

        /// <summary>
        /// 
        /// </summary>
        public IMesh Mesh { get; set; }
    }
}
