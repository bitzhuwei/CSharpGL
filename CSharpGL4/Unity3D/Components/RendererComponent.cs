using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// How are we going to render <see cref="MeshComponent"/>?
    /// </summary>
    public class RendererComponent : ComponentBase
    {
        /// <summary>
        /// How are we going to render <see cref="MeshComponent"/>?
        /// </summary>
        /// <param name="gameObject"></param>
        public RendererComponent(GameObject gameObject) : base(gameObject) { }

        /// <summary>
        /// 
        /// </summary>
        public IRenderer Renderer { get; set; }
    }
}
