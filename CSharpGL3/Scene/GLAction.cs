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
        internal abstract Type ThisTypeCache { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        public void Apply(GLNode node)
        {
            Snippet snippet = SnippetSearcher.Find(this, node);
            if (snippet != null)
            {
                snippet.BeforeChildren(this, node);
            }

            foreach (var child in node.Children)
            {
                this.Apply(child);
            }

            if (snippet != null)
            {
                snippet.AfterChildren(this, node);
            }
        }

    }
}
