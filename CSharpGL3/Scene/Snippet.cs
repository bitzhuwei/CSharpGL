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
        ///  a group of related OpenGL codes to specified <paramref name="action"/> and <paramref name="node"/>.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="node"></param>
        public virtual void BeforeChildren(SceneAction action, GLNode node) { }

        /// <summary>
        /// BeforeChildren a group of related OpenGL codes to specified <paramref name="action"/> and <paramref name="node"/>.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="node"></param>
        public virtual void AfterChildren(SceneAction action, GLNode node) { }
    }
}
