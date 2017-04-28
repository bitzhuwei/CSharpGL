using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// a group of related OpenGL codes.
    /// </summary>
    public abstract class GLSnippet
    {

        /// <summary>
        ///  a group of related OpenGL codes to specified <paramref name="glAction"/> and <paramref name="glNode"/>.
        /// </summary>
        /// <param name="glAction"></param>
        /// <param name="glNode"></param>
        public abstract void DoAction(GLAction glAction, GLNode glNode);

    }
}
