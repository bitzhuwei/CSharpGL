using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Action that applys to a scene made of <see cref="GLNode"/>.
    /// </summary>
    public abstract class GLAction
    {

        /// <summary>
        /// node that this action applies to.
        /// </summary>
        public GLNode AppliedNode { get; set; }

        internal abstract Type SelfTypeCache { get; }

        /// <summary>
        /// Find the wanted <see cref="GLSnippet"/> according to specified <paramref name="glNode"/>.
        /// </summary>
        /// <param name="glNode"></param>
        /// <returns></returns>
        protected abstract GLSnippet FindSnippet(GLNode glNode);

    }
}
