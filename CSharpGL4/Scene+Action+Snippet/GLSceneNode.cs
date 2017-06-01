using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// contains parameters for some OpenGL code.
    /// </summary>
    public abstract class GLSceneNode
    {
        internal abstract Type SelfTypeCache { get; }

        private List<GLSceneNode> children = new List<GLSceneNode>();
        /// <summary>
        /// 
        /// </summary>
        public List<GLSceneNode> Children { get { return this.children; } }

    }
}
