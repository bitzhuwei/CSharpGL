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
        //internal abstract Type ThisTypeCache { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="glNode"></param>
        public void Apply(GLNode glNode)
        {
            GLSnippet snippet = GLSnippetSearcher.Find(this, glNode);
            if (snippet != null)
            {
                snippet.BeforeChildren(this, glNode);
            }

            foreach (var child in glNode.Children)
            {
                this.Apply(child);
            }

            if (snippet != null)
            {
                snippet.AfterChildren(this, glNode);
            }
        }

    }
}
