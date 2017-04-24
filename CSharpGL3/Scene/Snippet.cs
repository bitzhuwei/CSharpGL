using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// a group of related OpenGL codes.
    /// </summary>
    public abstract class Snippet
    {

        /// <summary>
        /// Apply a group of related OpenGL codes to specified <paramref name="action"/> and <paramref name="node"/>.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="node"></param>
        public abstract void Apply(SceneAction action, GLNode node);
    }
}
